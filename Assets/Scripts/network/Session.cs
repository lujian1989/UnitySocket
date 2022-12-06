using System;
using System.Collections;
using UnityEngine;

namespace network
{
    public class Session
    {
        public enum State
        {
            Init, //初始状态
            Work, //工作状态
            Offline //离线状态
        };

        public int sessionID = -1;
        public bool isClient;
        public State state;

        public long startTime;
        public int msgReadTime, msgWriteTime;

        public Session()
        {
            this.sessionID = -1;
            this.isClient = true;

            startTime = currentTimeMillis();
            msgReadTime = 0;
            msgWriteTime = -100000;

            state = State.Init;
            sndBuf = new SessionSndBuf(this);
            rcvBuf = new SessionRcvBuf(this);
        }
        
        public long currentTimeMillis()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }

        public int getCurTime()
        {
            return (int) (currentTimeMillis() - startTime);
        }


        private int connectCount = 0;
        public void DoFrameUpdate(float deltaTime)
        {
            switch (state)
            {
                case State.Init:
                    int curTime = getCurTime();
                    if (curTime-msgReadTime>= NetConfig.ConnectTimeout)
                    {
                        offline();
                    }else if (curTime - msgWriteTime >= NetConfig.ConnectReqTime)
                    {
                        ++connectCount;
                        if (connectCount == NetConfig.ChangeChannelCount)
                        {
                            NetManage.ins.changeChannel(true);
                            connectCount = 1;
                        }
                        sendConnectReq();
                        msgWriteTime = curTime;
                        if(NetConfig.ISLOG)Debug.Log("-->初始化:请求连接:-------------- 时间:"+curTime);
                    }

                    break;
                case State.Work:
                    curTime = getCurTime();
     
                    if (curTime - msgReadTime > NetConfig.SessionTimeout)
                    {
                        if(NetConfig.ISLOG)Debug.Log("---------------------------------------------offline---------------");
                        offline();
                        enterOfflineState();
                    }else if (curTime - msgReadTime > 10000)
                    {
                        if (curTime - msgWriteTime > NetConfig.IdleReqTime)
                        {
                            if(NetConfig.ISLOG)Debug.Log("-->工作中:保持连接:-------------- 时间:"+curTime);
                            sendPingReq();
                            msgWriteTime = curTime;
                        }
                        
                        NetManage.ins.timeout10Notify();
                    } 
                    else if (curTime - msgReadTime > 5000)
                    {
                        if (curTime - msgWriteTime > 2000)
                        {
                            sendPingReq();
                            msgWriteTime = curTime;
                        }
                        
                        NetManage.ins.timeout5Notify();
                    } 
                    else if (curTime - msgReadTime > 2500)
                    {
                        if (curTime - msgWriteTime > 2000)
                        {
                            sendPingReq();
                            msgWriteTime = curTime;
                        }
                        
                        NetManage.ins.timeout2Notify();
                    }else
                    {
                        NetManage.ins.timeoutReset();
                        if (curTime - msgWriteTime > 1000)
                        {
                            sendPingReq();
                            msgWriteTime = curTime;
                        }
                    } 
                    
                    
             
                    
                    break;
                case State.Offline:
                    break;
            }

            flush();
        }

        int nextFlushTs = int.MaxValue;
        public void flush()
        {
            int ts = (int) getCurTime();
            if (!needFlush&&ts<nextFlushTs)
            {
                return;
            }

            if (!needFlush)
            {
                if(NetConfig.ISLOG)Debug.Log("自动触发 flush:"+nextFlushTs);
            }
            
            int nextTs = 1000000;
            
            short una = (short) rcvBuf.rcvNxt;
            short bits = (short) rcvBuf.getBits();
            
            if(NetConfig.ISLOG)Debug.Log("-------------flush start 时间:"+ts+" una:"+una+" bits:"+bits);

            int queueSize = sndQueue.Count;
            int bufSize = sndBuf.freeSize();
            if (bufSize > 0 && queueSize > 0)
            {
                int min = queueSize < bufSize ? queueSize : bufSize;
                if(NetConfig.ISLOG)Debug.Log(" sndQueue->sndBuf size:"+min);
                for (int i = 0; i < min; ++i)
                {
                    Segment seg = (Segment) sndQueue.Dequeue();
                    seg.sn = (short) sndBuf.sndNxt;
                    sndBuf.put(seg);
                }
            }

            int suna = sndBuf.sndUna;
            int snxt = sndBuf.sndNxt;

            if (snxt < suna)
                snxt += (1 << 16);

            bool hasSendSeg = false;
            Block ioBuf = requireIOBuf();
            int timeout;
            
            if(NetConfig.ISLOG)Debug.Log(" 待处理队列 sndUna:"+suna+" sndNxt:"+snxt);
            for (int i = suna; i < snxt; ++i)
            {
                Segment seg = sndBuf.pool[i & 0xf] as Segment;

                if (seg == null) continue;
                
                if (seg.xmit == 0)
                {
                    ++seg.xmit;
                    timeout = 200;
                    ioBuf = encodeSegment(ioBuf, seg, ts, una, bits);
                    seg.resendts = ts + timeout;
                    hasSendSeg = true;
                    if(NetConfig.ISLOG)Debug.Log("   -->第一次处理队列ID:"+seg.sn+" 索引: " + (i&0xf) +" 当前时间:"+ ts + "  下次发送时间:"+ seg.resendts);
                }
                else if (seg.resendts <= ts)
                {
                    ++seg.xmit;
                    timeout = seg.xmit * 200;
                    if (timeout > 950)
                    {
                        timeout = 950;
                    }
                    
                    ioBuf = encodeSegment(ioBuf, seg, ts, una, bits);
                    seg.resendts = ts + timeout;
                    hasSendSeg = true;
                    if(NetConfig.ISLOG)Debug.Log("   <--第"+seg.xmit+"次处理队列ID:" +seg.sn+" 索引: " + (i&0xf) +" 当前时间:"+ ts + "  下次发送时间:"+ seg.resendts);
                }
                else
                {
                    timeout = seg.resendts - ts;
                }

                nextTs = nextTs < timeout ? nextTs : timeout;
                
            }

            if (!hasSendSeg)
            {
                encodePong(ioBuf, ts, una, bits);
                if(NetConfig.ISLOG)Debug.Log(" <--当前没有消息:发送pong消息");
            }
            
            NetManage.ins.output(ioBuf);
            nextFlushTs = ts +nextTs;
            if(NetConfig.ISLOG)Debug.Log("-------------flush end-------------nextFlushTs:"+nextFlushTs);

            needFlush = false;
        }


        public Block encodeSegment(Block block, Segment seg, int ts, short una, short ackFlg)
        {
            if (block.readerRemaining() == 0)
            {
                encodeMainSegment(block, seg, ts, una, ackFlg);
            }
            else
            {
                block = encodeAttachSegment(block, seg, ts, una, ackFlg);
            }

            return block;
        }

        public void encodeMainSegment(Block block, Segment seg, int ts, short una, short ackFlg)
        {
            block.writeShort(15 + seg.data.readerRemaining());

            int cmd = (getProxyType() << 6) | 5;
            if (!isClient) cmd |= 1 << 4;
            if (seg.frag != 0) cmd |= 1 << 5;
            block.writeByte(cmd);

            block.writeInt(sessionID);
            block.writeInt(ts);
            block.writeShort(una);
            block.writeShort(ackFlg);
            block.writeShort(seg.sn);

            int rIndex = seg.data.readerPosition();
            block.writeBlock(seg.data);
            seg.data.setReaderPosition(rIndex);
        }

        public Block encodeAttachSegment(Block block, Segment seg, int ts, short una, short ackFlg)
        {
            int needSize = seg.data.readerRemaining() + 13;
            if (needSize + block.readerRemaining() > NetConfig.MTU)
            {
                NetManage.ins.output(block);
                block = requireIOBuf();
                encodeMainSegment(block, seg, ts, una, ackFlg);
                return block;
            }

            block.writeShort(11 + seg.data.readerRemaining());
            int cmd = (getProxyType() << 6) | 6;
            if (!isClient) cmd |= 1 << 4;
            if (seg.frag != 0) cmd |= 1 << 5;
            block.writeByte(cmd);
            block.writeInt(sessionID);
            block.writeInt(ts);
            block.writeShort(seg.sn);
            
            int rIndex = seg.data.readerPosition();
            block.writeBlock(seg.data);
            seg.data.setReaderPosition(rIndex);
            return block;
        }

        public void encodePing(Block block, int ts, short una, short ackFlg)
        {
            block.writeShort(13);
            int cmd = (getProxyType() << 6) | 3;
            if (!isClient) cmd |= 1 << 4;
            block.writeByte(cmd);
            block.writeInt(sessionID);
            block.writeInt(ts);
            block.writeShort(una);
            block.writeShort(ackFlg);
        }


        public void encodePong(Block block, int ts, short una, short ackFlg)
        {
            block.writeShort(13);
            int cmd = (getProxyType() << 6) | 4;
            if (!isClient) cmd |= 1 << 4;
            block.writeByte(cmd);
            block.writeInt(sessionID);
            block.writeInt(ts);
            block.writeShort(una);
            block.writeShort(ackFlg);
        }


        public void encodeConnectReq(Block block)
        {
            block.writeShort(9);
            int cmd = (getProxyType() << 6) | 1;
            if (!isClient) cmd |= 1 << 4;
            block.writeByte(cmd);
            block.writeInt(sessionID);
            block.writeInt(getCurTime());
        }

        public void encodeConnectRsp(Block block)
        {
            block.writeShort(9);
            int cmd = (getProxyType() << 6) | 2;
            if (!isClient) cmd |= 1 << 4;
            block.writeByte(cmd);
            block.writeInt(sessionID);
            block.writeInt(getCurTime());
        }


        public int getProxyType()
        {
            return 0;
        }

        public Block requireIOBuf()
        {
            Block buf = new Block(NetConfig.MTU);
            return buf;
        }


        public State getState()
        {
            return this.state;
        }


        private void enterInitState()
        {
            this.state = State.Init;
        }

        private void enterWorkState()
        {
            this.state = State.Work;
        }

        private void enterOfflineState()
        {
            this.state = State.Offline;
        }

        public void sendConnectReq()
        {
            Block data = new Block(11);
            encodeConnectReq(data);
            NetManage.ins.output(data);
        }
        
        public void sendPingReq()
        {
            Block data = new Block(15);
            int ts =  getCurTime();
            short una =  (short)rcvBuf.rcvNxt;
            short bits = (short)rcvBuf.getBits();
            encodePing(data, ts, una, bits);
            NetManage.ins.output(data);
        }

        public void offline()
        {
            NetManage.ins.offline();
        }


        //输出--------------------------------------------------
        public Queue sndQueue = new Queue();
        public Queue rcvQueue = new Queue();
        public Segment lastSndSegment;
        
        class SessionSndBuf : SndBuf<Segment>
        {
            
            private Session session;
            public SessionSndBuf(Session session)
            {
                this.session = session;
            }
                
            public override void release(Segment t)
            {
                if(NetConfig.ISLOG)Debug.Log(" 消息已确认,丢弃:"+t.sn);
                if (session.sndQueue.Count != 0)
                {
                    session.flushEvent();
                }
            }
        };

        private SessionSndBuf sndBuf;

        class SessionRcvBuf : RcvBuf<Segment>
        {
            private Session session;

            public SessionRcvBuf(Session session)
            {
                this.session = session;
            }

            public override void sequence(short sn, Segment seg)
            {
                if (seg.frag != 0)
                {
                    if(NetConfig.ISLOG)Debug.Log("--> rcvBuf:收到分包:"+ sn);
                    session.rcvQueue.Enqueue(seg);
                }
                else if (session.rcvQueue.Count != 0)
                {
                    if(NetConfig.ISLOG)Debug.Log("--> rcvBuf:处理分包: 大小"+ session.rcvQueue.Count);
                    session.rcvQueue.Enqueue(seg);
                    session.handleRcvQueue();
                }
                else
                {
                    if(NetConfig.ISLOG)Debug.Log("-->  rcvBuf:非分包:直接处理:"+ sn);
                    session.handleRcvData(seg.data);
                }
            }
        };

        private SessionRcvBuf rcvBuf;

        protected void handleRcvQueue()
        {
            int poolSize = rcvQueue.Count;
            Block allbuf = new Block(poolSize * NetConfig.MSS);
            for (int i = 0; i < poolSize; ++i)
            {
                allbuf.writeBlock(((Segment) rcvQueue.Dequeue()).data);
            }

            handleRcvData(allbuf);
        }

        public void handleRcvData(Block data)
        {
            if(NetConfig.ISLOG)Debug.Log("<--处理收到的数据   数据大小 :"+ data.readerRemaining());
            NodeClient.ins.receivePackage(data);
        }

        public void msgRead()
        {
            msgWriteTime = msgReadTime = getCurTime();
        }

        public void input(Block block)
        {
            int len, cmd, sendType, sessionID, ts;
            bool isClientSend, isFrag;
            short una, bits, sn;
            Block buf;
            Segment seg;

            int msgCount = 0;
            for (;;)
            {
                if (block.readerRemaining() <= 0)     return;
                
                len = block.readShort();
                if(NetConfig.ISLOG) Debug.Log("  处理Segment: "+(msgCount++)+" len:"+len);
                if (len > block.readerRemaining())
                {
                    if (block.readerRemaining() >=5)
                    {
                        cmd = block.readByte() & 0xff;
                        sendType = cmd >> 6;
                        isClientSend = (cmd & (1 << 4)) == 0;
                        isFrag = (cmd & (1 << 5)) != 0;

                        sessionID = block.readInt();

                        Debug.Log("收到的指令长度大于数据长度" + len + " " + block.readerRemaining() + " cmd:" + (cmd & 0xf) + "sessionID:"+ sessionID);

                    }
                    else
                    {
                        Debug.Log("收到的指令长度大于数据长度" + len + " " + block.readerRemaining());
                    }
                ;
                    return;
                }
                cmd = block.readByte() & 0xff;
                sendType = cmd >> 6;
                isClientSend = (cmd & (1 << 4)) == 0;
                isFrag = (cmd & (1 << 5)) != 0;

                sessionID = block.readInt();
                ts = block.readInt();

                msgRead();
                enterWorkState();

                switch (cmd & 0xf)
                {
                    case 1:
                        //sendConnectRsp();
                        break;
                    case 2:
                        if(NetConfig.ISLOG)Debug.Log("<--收到连接响应:-------- 时间:"+getCurTime()+" sessionID:"+sessionID);
                        this.sessionID = sessionID;
                        flushEvent();
                        break;
                    case 3:
                        una = block.readShort();
                        bits = block.readShort();
                        if (sessionID != this.sessionID) continue;
                        sndBuf.ack(ts, una, bits);
                        
                        flushEvent();
                        Debug.Log("<--收到ping请求:-------- 时间:"+getCurTime()+" sessionID:"+sessionID+" una:"+una+" bits:"+bits+" ts:"+ts);
                        break;
                    case 4:
                        una = block.readShort();
                        bits = block.readShort();
                        
                        if (sessionID != this.sessionID) continue;
                        sndBuf.ack(ts, una, bits);
                        if(NetConfig.ISLOG)Debug.Log("<--收到响应请求:-------- 时间:"+getCurTime()+" sessionID:"+sessionID+" una:"+una+" bits:"+bits+" ts:"+ts);
                        break;
                    case 5:
                        una = block.readShort();
                        bits = block.readShort();

                        sn = block.readShort();
                        buf = new Block(len - 15);
                        buf.writeBlock(block);

                        if (sessionID != this.sessionID) continue;
                        sndBuf.ack(ts, una, bits);
                        
                        seg = Segment.createSegment(buf);
                        seg.frag = (short) (isFrag ? 1 : 0);
                        rcvBuf.put(sn, seg);
                        flushEvent();
                        if(NetConfig.ISLOG)Debug.Log("<--收到主片段:-------- 时间:"+getCurTime()+" sessionID:"+sessionID+" size:"+buf.readerRemaining()+" una:"+una+" bits:"+bits+" ts:"+ts);
                        break;
                    case 6:
                        sn = block.readShort();
                        buf = new Block(len - 11);
                        buf.writeBlock(block);
                        
                        if (sessionID != this.sessionID) continue;

                        seg = Segment.createSegment(buf);
                        seg.frag = (short) (isFrag ? 1 : 0);

                        rcvBuf.put(sn, seg);
                        flushEvent();
                        if(NetConfig.ISLOG)Debug.Log("<--收到附带片段:-------- 时间:"+getCurTime()+" sessionID:"+sessionID+" size:"+buf.readerRemaining());
                        break;
                    default:

                        return;
                }
            }
        }

        private bool needFlush = false;

        public void flushEvent()
        {
            needFlush = true;
        }

        public void output(Request req)
        {
            if(state == State.Init) msgReadTime = getCurTime(); //初始化的时候 发送消息时 进行延时----------
            int length = req.getBinLength() + 4;
            
            int len = length + 2;

            if (length >= 65535)
            {
                len += 4;
            }
            
            
            int count = 0;
            if (len <= NetConfig.MSS)
            {
                count = 1;
            }
            else
            {
                count = (len + NetConfig.MSS - 1) / NetConfig.MSS;
            }

            Block buf;
            if (count == 1)
            {
                Segment seg;
                if (sndQueue.Count > 0 && lastSndSegment.frag==0 && lastSndSegment.data.writerRemaining()  >= len)
                {
                    seg = lastSndSegment;
                    buf = seg.data;
                }
                else
                {
                    buf = new Block(NetConfig.MSS);
                    seg = Segment.createSegment(buf);
                    sndQueue.Enqueue(seg);
                    lastSndSegment = seg;
                }

                buf.writeShort(length);
                buf.writeByte(req.getClsID());
                buf.writeByte(req.getMethodID());
                buf.writeShort(req.sn);
                req.writeBin(buf);
            }
            else
            {
                buf = new Block(len);

                if (length >= 65535)
                {
                    buf.writeShort(65535);
                    buf.writeInt(length);
                }
                else
                {
                    buf.writeShort(length);
                }

                buf.writeByte(req.getClsID());
                buf.writeByte(req.getMethodID());
                buf.writeShort(req.sn);
                req.writeBin(buf);

                for (int i = 0; i < count; i++)
                {
                    int size = len > NetConfig.MSS ? NetConfig.MSS : len;
                    Block segBlock = new Block(size);
                    segBlock.writeBlock(buf);
                    Segment seg = Segment.createSegment(segBlock);
                    seg.frag = (short) (count - i - 1);
                    sndQueue.Enqueue(seg);
                    len = buf.readerRemaining();
                    lastSndSegment = seg;
                }
            }

           if(state== State.Work) flushEvent();
        }


        //-------------------------------------------------------
    }

    public class Segment
    {
        public short sn; // 序号
        public short frag; // 分包序列号

        public int resendts; // 发送时间
        public byte xmit; // 发送次数

        public Block data; // 数据

        public Segment()
        {
        }

        public void recycle(bool releaseBuf)
        {
            sn = 0;
            frag = 0;
            resendts = 0;
            xmit = 0;

            data = null;
        }

        public static Segment createSegment(Block buf)
        {
            Segment seg = new Segment();
            seg.data = buf;
            return seg;
        }
    }
}