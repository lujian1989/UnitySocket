//动态生成，不要手动修改

using network.tcp.DataCenter;
using NewProto;
using network;
public class Response_Test :PacketReader
{
    public event MessageProcCallback eventResponse;
    public const int CLSID    =100;
    public const int METHODID =101;
    public Response_Test(MessageProcCallback rsp,bool isPackToBigMsg)
    {
        eventResponse = rsp;
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
        return "Response_Test_PB CLSID:"+100+"MethodID:"+101;
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
        protoData = NetUtilcs.Deserialize<Response_Test_100_101>(block.getData());
    }
    public override void handleResult()
    {
         if (eventResponse!= null)
         {
            eventResponse((Response_Test_100_101)protoData);
         }
    }
    private void MessageProc( object obj )
    {
         if (eventResponse!= null)
         {
            eventResponse((Response_Test_100_101)protoData);
         }
    }
    public override Response newInstance()
    {
        Response_Test ins = new Response_Test();
        ins.protoData = this.protoData;
        return ins;
    }
}
