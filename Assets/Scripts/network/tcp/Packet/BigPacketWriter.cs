using System;
using Google.Protobuf;
using network;
using NewProto;
using UnityEngine;
using Object = UnityEngine.Object;

public class BigPacketWriter : PacketWriter
{
    public const int CLSID = PacketProcesser.BIG_PACKET_CLSID;
    public const int METHODID = PacketProcesser.BIG_PACKET_METHODID;
    
    public BigPacketWriter()
    {
        this.clsID = CLSID;
        this.methodID = METHODID;
        this.type = (byte)NET_CMD_TYPE.COUSTOM;
    }
    
    public BigPacketWriter(byte[] data)
    {
        this.clsID = CLSID;
        this.methodID = METHODID;
        this.type = (byte)NET_CMD_TYPE.COUSTOM;
        SetBodyData(data);
    }
}