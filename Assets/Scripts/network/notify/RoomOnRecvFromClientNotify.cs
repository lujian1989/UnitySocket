using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnRecvFromClientNotify : Notify {
        public OnRecvFromClientNotify onRecvFromClientNotify{ set; get; }

        public int sendPlayerId;

        public short type;

        public byte[] msg;

        public override string getCmd() {
            return "Room:OnRecvFromClientNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)43;
        }

        public delegate void OnRecvFromClientNotify(int sendPlayerId, short type, byte[] msg);

        public override void readBin(Block _block) {
            sendPlayerId=_block.readInt();
            type=_block.readShort();
            msg=_block.readByteArray();
        }

        public override void handleResult() {
            onRecvFromClientNotify?.Invoke( sendPlayerId ,type ,msg );
        }

        public override Response newInstance() {
            RoomOnRecvFromClientNotify ins=new RoomOnRecvFromClientNotify();
            ins.onRecvFromClientNotify = onRecvFromClientNotify;
            return ins;
        }
    }
}

