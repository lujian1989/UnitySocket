using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using network.service;
using network.request;
using network.response;
using network.notify;
using static network.NetConfig;
using System.IO;
using System.Collections;
using System.Collections.Concurrent;
using Google.Protobuf;
using UnityEngine;


namespace network
{
    public class NodeClient
    {
        public  static NodeClient ins = new NodeClient();
        public static NodeClient get(string serviceName)
        {
            return ins;
        }

        public NodeClient()
        {
            onDefaultNotify();
        }

        public void onDefaultNotify()
        {
            SystemCloseNotify closeNotify = new SystemCloseNotify();
            closeNotify.closeNotify = () => { NetManage.ins.closeNotify(); };
            onNotify(closeNotify);

            SystemKickNotify kickNotify = new SystemKickNotify();
            kickNotify.kickNotify = () => { NetManage.ins.kickNotify(); };
            onNotify(kickNotify);
            
            SystemLeaveRoomNotify leaveRoomNotify = new SystemLeaveRoomNotify();
            leaveRoomNotify.leaveRoomNotify = () => { NetManage.ins.leaveRoomNotify(); };
            onNotify(leaveRoomNotify);
            
            SystemEncryptNotify encryptNotify = new SystemEncryptNotify();
            encryptNotify.encryptNotify = (userId, iv, key) => { NetManage.ins.resetEncryptInfo(userId, iv, key); };
            onNotify(encryptNotify);

        }
        

        //接收------------------------------------------------------------------------
        // ConcurrentQueue<Block> _receivePackage = new  ConcurrentQueue<Block>();  //网络接收的包    

        public void receivePackage(Block data)
        {
            try
            {
                handleBlock(data);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                Debug.LogError(e);
                //throw;
            }
            
        }
        
        // //主线程处理
        // public void DoFrameUpdate(float deltaTime)
        // {
        //     Block message;
        //     _receivePackage.TryDequeue(out message);
        //     while (message != null)
        //     {
        //         handleBlock(message);
        //         _receivePackage.TryDequeue(out message);
        //     }
        // }

        public void handleBlock(Block block)
        {
            for (;;)
            {
                if (block.readerRemaining() < 2)
                {
                    break;
                }

       
                int cmdLenth = block.readShort()&0xffff;
                if (cmdLenth == 65535)
                {
                    cmdLenth = block.readInt();
                }
                
                int rPosition = block.readerPosition();
                int clsID = block.readByte() & 0xff;
                int methodID = block.readByte() & 0xff;

                int sn = block.readShort()&0xffff;
                int key = (sn << 16) | (clsID << 8) | methodID;
                Response rsp = null;
                Queue<Response> rsps = null;
                pool.TryGetValue(key,out rsps);
                if (rsps == null)
                {
                    continue;
                }

                rsp = rsps.Dequeue();
                // block.setReaderPosition(rPosition+cmdLenth);
                Debug.Log(cmdLenth+" block readerRemaining:"+block.readerRemaining()+"clsID:"+clsID+" methodID:"+methodID+" cmdLenth:"+cmdLenth);
                // continue;
                
                if (rsp == null)
                {
                    block.setReaderPosition(rPosition+cmdLenth);
                    Debug.Log("<--收到Msg:无法解析(err) clsID:"+clsID+" methodID:"+methodID+" size:" +cmdLenth+"  sn:"+sn);
                    continue;
                }
                
                Debug.Log("<--收到Msg:"+rsp.getCmd()+" clsID:"+clsID+" methodID:"+methodID+" size:" +cmdLenth+"  sn:"+sn);
            
                if (rsp.isNotify())
                {
                    rsp = rsp.newInstance();
                }
                else
                {
                    pool[key] = null;
                }
            
                rsp.readRsp(block);
                rsp.handleResult();
            }
           
        }

        //------------------------------------------------------------------------------------------
        public  Dictionary<int, Queue<Response>> pool = new Dictionary<int,  Queue<Response>>(); //已经发送的请求

        public void timeout()
        {
            pool.Clear();
            onDefaultNotify();
        }

        public void onNotify(Response rsp)
        {
            if (rsp == null) return;
           
            int key = ((rsp.getClsID() & 0xff) << 8) | (rsp.getMethodID() & 0xff);

            Queue<Response> responses;
            if (pool.TryGetValue(key,out responses))
            {
                responses.Enqueue(rsp);
            }
            else
            {
                responses = new Queue<Response>();
                responses.Enqueue(rsp);
                pool.Add(key,responses);
            }

            Debug.Log("rsp:" + rsp.sn + " rsp.getClsID:" + rsp.getClsID() + " rsp.getMethodID:" + rsp.getMethodID()+" key:"+key);
            
        }

        public void offNotify(int notifyID)
        {
            pool[notifyID] = null;
        }

        short id = 0;
        public void send(Request req, Response rsp)
        {
            if (rsp != null)
            {
                ++id;
                if (id == 0) ++id;
                rsp.sn=req.sn = id;
            }
            onNotify(rsp);
            Debug.Log("-->发送Msg: " + req.getCmd() + " clsID:" + req.getClsID() + " methodID:" + req.getMethodID() +
                      " size:" + req.getBinLength());
            NetManage.ins.send(req,req.getType());
        }
    }
}