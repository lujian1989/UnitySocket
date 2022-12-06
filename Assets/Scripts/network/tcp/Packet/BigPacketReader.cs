using Google.Protobuf;
using network;
using network.tcp.DataCenter;
using NewProto;
using UnityEngine;


    /// <summary>
    /// 超大消息打包器
    /// </summary>
    public class BigPacketReader : PacketReader
    {
        public byte[] body;

        public override void readBin(Block block)
        {
            body = block.readRealByteArray();
        }

        public override string getCmd()
        {
            return "BigPacketReader";
        }

        public override byte getClsID()
        {
            return (byte)PacketProcesser.BIG_PACKET_CLSID;
        }

        public override byte getMethodID()
        {
            return (byte)PacketProcesser.BIG_PACKET_METHODID;
        }

        public override void handleResult()
        {
            Debug.Log("handleResult");
        }
    }
