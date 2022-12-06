//动态生成，不要手动修改

using NewProto;
public class Request_Test :PacketWriter
{
    public const int CLSID    =100;
    public const int METHODID =101;
    public Request_Test()
    {
        this.clsID    = CLSID;
        this.methodID = METHODID;
        this.type     = (byte)NET_CMD_TYPE.PB;
    }
    public Request_Test(Request_Test_100_101 protoData)
    {
        this.clsID    = CLSID;
        this.methodID = METHODID;
        this.type     = (byte)NET_CMD_TYPE.PB;
        SetBodyData(protoData);
    }
}
