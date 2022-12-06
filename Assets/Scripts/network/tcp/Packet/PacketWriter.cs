using System;
using Google.Protobuf;
using network;
using NewProto;
using UnityEngine;
using Object = UnityEngine.Object;

public class PacketWriter : Request
{
    public byte clsID;
    public byte methodID;
    public byte isEnd;
    public byte type;
    public byte compress;
    public byte[] body;

    public override string getCmd()
    {
        return "PacktWriter";
    }

    public override byte getClsID()
    {
        return this.clsID;
    }

    public override byte getMethodID()
    {
        return this.methodID;
    }

    public override void writeBin(Block block)
    {
        block.writeRealByteArray(body);
        Debug.Log(body.Length);
    }

    public override int getBinLength()
    {
        Debug.Log(body.Length);
        return body.Length;
    }

    public override byte end()
    {
        return isEnd;
    }

    public override byte getType()
    {
        return type;
    }
    
    public override byte isCompress()
    {
        return compress;
    }

    public void SetBodyData(System.Object data)
    {
        //byte[] body = null;
        switch (type)
        {
            case (byte)NET_CMD_TYPE.OLD: //@TODO 新版本不会有新增旧协议
                break;
            case (byte)NET_CMD_TYPE.PB:
                IMessage message = data as IMessage;
                body = NetUtilcs.Serialize(message);
                break;
            case (byte)NET_CMD_TYPE.COUSTOM:
                body = (byte[])data;
                break;
            case (byte)NET_CMD_TYPE.JSON:
                break;
            
        }
        //return  body;
    }
}