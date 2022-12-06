using Google.Protobuf;
using NewProto;
using UnityEngine;

namespace network.tcp.DataCenter
{
    public class PacketReader :Response
    {
        public IMessage protoData;
        public override void readBin(Block block)
        {
            //Response_Test_100_101 protoData = NetUtilcs.Deserialize<Response_Test_100_101>(block.getData());
            // protoData  = CreateProtoBuf.GetProtoData(id,body);
            // Debug.Log("readBin:" + protoData.Account + " "+ protoData.Password);
        }

        public override string getCmd()
        {
            return "PacketReader:pb";
        }

        public override byte getClsID()
        {
          return 100;  
        }

        public override byte getMethodID()
        {
            return 100;
        }

        public override void handleResult()
        {
           Debug.Log("handleResult");
           
        }
    }
}