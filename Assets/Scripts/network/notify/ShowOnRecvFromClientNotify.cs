using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class ShowOnRecvFromClientNotify : Notify {
        public OnRecvFromClientNotify onRecvFromClientNotify{ set; get; }

        public int sendPlayerId;

        public short type;

        public byte[] msg;

        public override string getCmd() {
            return "Show:OnRecvFromClientNotify";
        }

        public override byte getClsID() {
            return (byte)237;
        }

        public override byte getMethodID() {
            return (byte)3;
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
            ShowOnRecvFromClientNotify ins=new ShowOnRecvFromClientNotify();
            ins.onRecvFromClientNotify = onRecvFromClientNotify;
            return ins;
        }
    }
}

