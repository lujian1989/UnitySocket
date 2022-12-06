//动态生成，不要手动修改

using System;
using Google.Protobuf;
using network;
using network.tcp.DataCenter;
using NewProto;


public class Request_Test : PacketWriter
{
    public const int CLSID = 100;
    public const int METHODID = 101;
    
    public Request_Test()
    {
        this.clsID = CLSID;
        this.methodID = METHODID;
        this.type = (byte)NET_CMD_TYPE.PB;
    }
    
    public Request_Test(Request_Test_100_101 protoData)
    {
        this.clsID = CLSID;
        this.methodID = METHODID;
        this.type = (byte)NET_CMD_TYPE.PB;
        SetBodyData(protoData);
    }
}

public class Response_Test : PacketReader
{
    public event MessageProcCallback eventResponse;
    public const int CLSID = 100;
    public const int METHODID = 101;
   
    public Response_Test(MessageProcCallback rsp,bool isPackToBigMsg )
    {
        eventResponse = rsp;
        // DataCenter.packetProcesser.RegisterProcForMessage((CLSID<<8|METHODID),rsp);
        if (isPackToBigMsg)
        {
            NodeClient.ins.onNotify(this);
        }
    }
    public Response_Test()
    {
    }
    public override string getCmd()
    {
        return "Response_Test_PB CLSID:"+CLSID+"MethodID:"+METHODID;
    }
    public override byte getClsID()
    {
        return CLSID;  
    }
    public override byte getMethodID()
    {
        return METHODID;
    }
    public override void readBin(Block block)
    {
        protoData  = CreateProtoBuf.GetProtoData(CLSID<<8|METHODID,block.getData());
    }
    public override void handleResult()
    {
        //DataCenter.packetProcesser.PacketDispatch(protoData,CLSID<<8|METHODID);
        if (eventResponse!= null)
        {
            eventResponse((Response_Test_100_101)protoData);
        }
        
    }
    public override Response newInstance() {
        Response_Test ins=new Response_Test();
        ins.protoData = this.protoData;
        DataCenter.packetProcesser.RegisterProcForMessage((CLSID<<8|METHODID),MessageProc);
        return ins;
    }
    
    private void MessageProc( object obj ) {
        if (eventResponse!= null)
        {
            eventResponse((Response_Test_100_101)obj);
        }
    }
}