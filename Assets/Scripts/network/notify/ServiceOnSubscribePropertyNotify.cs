using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class ServiceOnSubscribePropertyNotify : Notify {
        public OnSubscribePropertyNotify onSubscribePropertyNotify{ set; get; }

        public int serviceId;

        public int userId;

        public short index;

        public byte[] data;

        public override string getCmd() {
            return "Service:OnSubscribePropertyNotify";
        }

        public override byte getClsID() {
            return (byte)235;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public delegate void OnSubscribePropertyNotify(int serviceId, int userId, short index, byte[] data);

        public override void readBin(Block _block) {
            serviceId=_block.readInt();
            userId=_block.readInt();
            index=_block.readShort();
            data=_block.readByteArray();
        }

        public override void handleResult() {
            onSubscribePropertyNotify?.Invoke( serviceId ,userId ,index ,data );
        }

        public override Response newInstance() {
            ServiceOnSubscribePropertyNotify ins=new ServiceOnSubscribePropertyNotify();
            ins.onSubscribePropertyNotify = onSubscribePropertyNotify;
            return ins;
        }
    }
}

