//动态生成，不要手动修改

using NewProto;
using Google.Protobuf;
namespace NewProto
{
    public static class CreateProtoBuf
    {
        public static IMessage GetProtoData(int protoId, byte[] msgData)
        {
            switch (protoId)
            {
                case Response_Test.CLSID<<8 | Response_Test.METHODID:
                    return NetUtilcs.Deserialize<Response_Test_100_101>(msgData);
                default:
                    return null;
            }
         }
    }
}
