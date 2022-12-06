using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class ServiceOnSubscribeNotify : Notify {
        public OnSubscribeNotify onSubscribeNotify{ set; get; }

        public int serviceId;

        public int userId;

        public short typeID;

        public byte[] data;

        public override string getCmd() {
            return "Service:OnSubscribeNotify";
        }

        public override byte getClsID() {
            return (byte)235;
        }

        public override byte getMethodID() {
            return (byte)6;
        }

        public delegate void OnSubscribeNotify(int serviceId, int userId, short typeID, byte[] data);

        public override void readBin(Block _block) {
            serviceId=_block.readInt();
            userId=_block.readInt();
            typeID=_block.readShort();
            data=_block.readByteArray();
        }

        public override void handleResult() {
            onSubscribeNotify?.Invoke( serviceId ,userId ,typeID ,data );
        }

        public override Response newInstance() {
            ServiceOnSubscribeNotify ins=new ServiceOnSubscribeNotify();
            ins.onSubscribeNotify = onSubscribeNotify;
            return ins;
        }
    }
}

