using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnRecvFromTrialNotify : Notify {
        public OnRecvFromTrialNotify onRecvFromTrialNotify{ set; get; }

        public int sendPlayerId;

        public short type;

        public int id;

        public byte[] msg;

        public override string getCmd() {
            return "Room:OnRecvFromTrialNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)42;
        }

        public delegate void OnRecvFromTrialNotify(int sendPlayerId, short type, int id, byte[] msg);

        public override void readBin(Block _block) {
            sendPlayerId=_block.readInt();
            type=_block.readShort();
            id=_block.readInt();
            msg=_block.readByteArray();
        }

        public override void handleResult() {
            onRecvFromTrialNotify?.Invoke( sendPlayerId ,type ,id ,msg );
        }

        public override Response newInstance() {
            RoomOnRecvFromTrialNotify ins=new RoomOnRecvFromTrialNotify();
            ins.onRecvFromTrialNotify = onRecvFromTrialNotify;
            return ins;
        }
    }
}

