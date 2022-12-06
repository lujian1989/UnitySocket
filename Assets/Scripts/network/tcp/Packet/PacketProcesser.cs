using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Google.Protobuf;
using network;
using NewProto;

public delegate void MessageProcCallback(object obj);

public class PacketProcesser
{
    public int privateKey;
    public int PublicKey ;
    public int MaxPaketSize = 10227;
    public int MaxZipSize = 256;

    public  const int BIG_PACKET_CLSID = 127;
    public  const int BIG_PACKET_METHODID = 127;

    //public Dictionary<int, MessageProcFunc> pMessageProcs = new  Dictionary<int, MessageProcFunc>();
    public Dictionary<int, Queue<MessageProcFunc>> pMessageProcs = new  Dictionary<int, Queue<MessageProcFunc>>();
    public PacketProcesser()
    {
        InitProcessFuncBinding();
    }

    // public void PacketDispatch( byte[] body, int id)
    // {
    //     if (pMessageProcs.ContainsKey(id))
    //     {
    //         IMessage msg = CreateProtoBuf.GetProtoData(id,body);
    //         MessageProcFunc mpf = (MessageProcFunc)pMessageProcs[id];
    //         if (mpf.callback != null)
    //         {
    //             mpf.callback(msg);
    //         }
    //     }
    // }
    
    public void PacketDispatch( IMessage msg, int id)
    {
        if (pMessageProcs.ContainsKey(id))
        {
            MessageProcFunc mpf = (MessageProcFunc)pMessageProcs[id].Dequeue();
            if (mpf.callback != null)
            {
                mpf.callback(msg);
            }
        }
    }
    private void InitProcessFuncBinding()
    {
        //RegisterProcForMessage((100<<8|101),TestMsg);
    }

    public void RegisterProcForMessage(int id, MessageProcCallback procFunc)
    {
        Queue<MessageProcFunc> func;
        if (pMessageProcs.TryGetValue(id,out func))
        {
            func.Enqueue( new MessageProcFunc(procFunc));
        }
        else
        {
            func = new Queue<MessageProcFunc>();
            func.Enqueue( new MessageProcFunc(procFunc));
            pMessageProcs.Add(id, func);
        }
    }
}


/// <summary>
/// 消息处理函数类
/// </summary>
public class MessageProcFunc
{
    public MessageProcCallback callback = null;

    public MessageProcFunc(MessageProcCallback callback)
    {
        this.callback = callback;
    }
}