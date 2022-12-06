using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;
using Google.Protobuf;
using network;
using network.response;
using NewProto;


public class PacketParser
{
    private int checkSum = 0;

    public Queue<byte[]> queue  = new Queue<byte[]>();
    private int Length = 0;


    public int index = 0;
    byte[] temp = new byte[13];
    /// <summary>
    /// 解析从网络收到的完整数据包
    /// </summary>
    /// <param name="data"></param>
    public void Parse(byte[] data,int readIndex = 0,bool isEncryption= true)
    {
        Debug.Log("Parse: data.Length: " + data.Length+" key:"+DataCenter.packetProcesser.PublicKey);
        // 解析数据包头
        Debug.LogError("readIndex:"+readIndex);
        int len = ReadInt32(data, readIndex);
        Debug.LogError("len:"+len);
        readIndex += 4;
        NetUtilcs.DebugBytes(data);
        if (isEncryption) //小包不需要异或加密
        {
            data = NetUtilcs.DecodeBytes(data, DataCenter.packetProcesser.PublicKey==0?len:DataCenter.packetProcesser.PublicKey);
        }
        NetUtilcs.DebugBytes(data);
        byte type = ReadByte(data, readIndex); // 读取消息名长度
        readIndex += 1;
        byte end = ReadByte(data, readIndex); // 读取消息名长度
        readIndex += 1;
        byte compress = ReadByte(data, readIndex); // 读取消息名长度
        readIndex += 1;
        int privateKey = ReadInt32(data, readIndex);
        readIndex += 4;
        byte clsID = ReadByte(data, readIndex); // 读取消息名长度
        readIndex += 1;
        byte methodID = ReadByte(data, readIndex); // 读取消息名长度
        readIndex += 1;

       
        
        int objDataLen = len - 9 ;
     
        byte[] body = ReadBytes(data, readIndex, objDataLen); // 读取 protobuf 对象数据

        Debug.LogError("objDataLen:"+objDataLen+" len:"+len+ " bodyLenght:"+body.Length);
        if (Length == 0 && end ==0)
        {
           
            // for (int i = 0; i < 13; i++)
            // {
            //     temp[i] = data[i];
            // }
            Debug.Log("需要缓存包头:");
          
            temp[0] = data[0];
            temp[1] = data[1];
            temp[2] = data[2];
            temp[3] = data[3];
            temp[4] =type;
            temp[5] =1;
            temp[6] =compress;
            temp[7] =(byte)(privateKey & 0xFF);
            temp[8] =(byte)((privateKey >> 8) & 0xFF);
            temp[9] =(byte)((privateKey >> 16) & 0xFF);
            temp[10] =(byte)((privateKey >> 24) & 0xFF);
            temp[11] =clsID;
            temp[12] =methodID;

        }
        if (Length == 0 && end == 1 && compress == 1) 
        {
            NetUtilcs.DebugBytes(body);
            body = NetUtilcs.ZLibDotnetDecompress(body);
            Debug.LogError("需要解压");
            
            NetUtilcs.DebugBytes(body);
        }
       
        
        readIndex += objDataLen;
        Debug.LogError("readIndex:"+readIndex+" len:"+len+" type ="+type+"end ="+end+" compress:"+compress+" privateKey="+privateKey+" cls:"+clsID+" method:"+methodID );
        if (end == 1)
        {
            if ( Length != 0)
            {
                Debug.LogError("queue================："+queue.Count+" Length:"+Length);
                Length += body.Length;
                queue.Enqueue(body);
                Debug.LogError("queue================："+queue.Count);
                //Parse(queue.ToArray());
                int arrayLen = queue.Count;
                byte[] total = new byte[this.Length];
                int curLen  = 0;
                for (int i = 0; i < arrayLen; i++)
                {
                    byte[] realBody =queue.Dequeue();
                    Debug.LogError("===============realBody================");
                    NetUtilcs.DebugBytes(realBody);
                    Array.Copy(realBody,0,total,curLen,realBody.Length);
                    curLen += realBody.Length;

                }
               
                Debug.LogError("===============处理超大包================"+Length);
                byte[] tmp = BitConverter.GetBytes( Length+9 );
                Array.Reverse(tmp);
                temp[0] = tmp[0];
                temp[1] = tmp[1];
                temp[2] = tmp[2];
                temp[3] = tmp[3];
                NetUtilcs.DebugBytes(total);
                if (compress == 1)
                {
                   total = NetUtilcs.ZLibDotnetDecompress(total);
                }

                byte[] realTotal = new byte[total.Length + temp.Length];
                Array.Copy(temp,0,realTotal,0,temp.Length);
                Array.Copy(total,0,realTotal,temp.Length,total.Length);
                NetUtilcs.DebugBytes(realTotal);
                queue.Clear();
                Length = 0;
                Parse(realTotal,0,false);
                return;
            }
            else
            {
                Debug.LogError("正常处理================：Length:"+Length);
            }
        }
        else
        {
         
            Length += body.Length;
            queue.Enqueue(body);
            Debug.LogError("============塞进队列================"+Length);
            NetUtilcs.DebugBytes(body);
            return;
            
        }
        switch (type)
        {
            case (int)NET_CMD_TYPE.OLD:
            case (int)NET_CMD_TYPE.PB:
                int key = (clsID << 8) | methodID;
                Response rsp = null;
          
                Queue<Response> rsps = null;
                NodeClient.ins.pool.TryGetValue(key,out rsps);
                if (rsps == null)
                {
                    Debug.LogError(string.Format("收到消息 clsId{0} MethodId:{1} rsps == null",clsID,methodID));
                    return;
                }
                if (rsps.Count == 0)
                {
                    Debug.LogError(string.Format("收到消息 clsId{0} MethodId:{1} rsps size = 0",clsID,methodID));
                    return;
                }
                rsp = rsps.Peek();
                Debug.Log("<--收到Msg:"+rsp.getCmd()+" clsID:"+clsID+" methodID:"+methodID+" size:" +len);
                if (rsp.isNotify())
                {
                    rsp = rsp.newInstance();
                }
                else
                {
                    rsp = rsps.Dequeue();
                }
                Block block = new Block(body);
                rsp.readRsp(block);
                rsp.handleResult();
                break;
            // case (int)NET_CMD_TYPE.PB:
            //     Debug.Log("<--PBMsg:"+ clsID+ " methodID:"+methodID+ " "+index++);
            //     int keyBp = (clsID << 8 | methodID);
            //     DataCenter.packetProcesser.PacketDispatch( body, keyBp);                 
            //    
            //     
            //     
            //     // Requset_TEST_INFO_12_13 data1 = (Requset_TEST_INFO_12_13)Requset_TEST_INFO_12_13.Descriptor.Parser.ParseFrom(body);
            //     // Debug.Log(data1.KeyWord22);
            //     // object obj = DataCenter.ProtobufUtility.Deserialize(objData, messageName); // 反序列化 Protobuf 对象
            //     // DataCenter.packetProcesser.PacketDispatch(obj, messageName); // 将 protobuf 消息对象传给 PacketProcesser 进行处理和派发
            //     break;
            case (int)NET_CMD_TYPE.JSON:
                break;
            case (int)NET_CMD_TYPE.COUSTOM:
                Debug.Log("getPrivateKey===="+privateKey+" clsId:"+ clsID+ " methodID:"+methodID);
                if (clsID == 0 &&  methodID== 0)
                {
                    DataCenter.packetProcesser.privateKey = privateKey;
                    DataCenter.packetProcesser.PublicKey = privateKey;

                    Array.Reverse(body);

                    int offset = 0;
                    int[] values=new int[2];
                    for (int i = 0; i < values.Length; i++)
                    {
                        int value = (int)((body[offset] & 0xFF)
                                          | ((body[offset + 1] & 0xFF) << 8)
                                          | ((body[offset + 2] & 0xFF) << 16)
                                          | ((body[offset + 3] & 0xFF) << 24));
                        values[i] = value;
                        offset += 4;
                    }
                
                  
                    DataCenter.packetProcesser.MaxPaketSize = values[0];
                    DataCenter.packetProcesser.MaxPaketSize = values[1];
                    Debug.Log("maxPacketSize===="+DataCenter.packetProcesser.MaxPaketSize
                    + " MaxZipSize:"+DataCenter.packetProcesser.MaxZipSize);
                    
                }
                
                if (clsID == 127 &&  methodID== 127)
                {
                    Parse(body,0,false);
                }
                break;
        }

        if (readIndex< data.Length)
        {
            Debug.LogError("===============接着处理================");
            Parse(data,readIndex,false);
        }
     
    }

    private byte ReadByte(byte[] data, int from)
    {
        byte[] array = new byte[1];
        Array.Copy(data, from, array, 0, 1);
        return array[0];
    }


    private byte[] ReadBytes(byte[] data, int from, int len)
    {
        byte[] array = new byte[len];
        Array.Copy(data, from, array, 0, len);
        return array;
    }


    private ushort ReadUInt16(byte[] data, int from)
    {
        byte[] array = new byte[2];
        Array.Copy(data, from, array, 0, 2);
        Array.Reverse(array);
        ushort result = BitConverter.ToUInt16(array, 0);
        return result;
    }


    private int ReadInt32(byte[] data, int from)
    {
        byte[] array = new byte[4];
        Array.Copy(data, from, array, 0, 4);
        Array.Reverse(array);
        int result = BitConverter.ToInt32(array, 0);
        return result;
    }


    private string ReadString(byte[] data, int from, int len)
    {
        byte[] array = new byte[len];
        Array.Copy(data, from, array, 0, len);
        Array.Reverse(array);
        string result = Encoding.UTF8.GetString(array);
        return result;
    }
}