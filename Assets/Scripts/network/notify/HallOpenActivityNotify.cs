using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallOpenActivityNotify : Notify {
        public OpenActivityNotify openActivityNotify{ set; get; }

        public bool oper;

        public string url;

        public int mainRoomId;

        public override string getCmd() {
            return "Hall:OpenActivityNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)21;
        }

        public delegate void OpenActivityNotify(bool oper, string url, int mainRoomId);

        public override void readBin(Block _block) {
            oper=_block.readBoolean();
            url=_block.readString();
            mainRoomId=_block.readInt();
        }

        public override void handleResult() {
            openActivityNotify?.Invoke( oper ,url ,mainRoomId );
        }

        public override Response newInstance() {
            HallOpenActivityNotify ins=new HallOpenActivityNotify();
            ins.openActivityNotify = openActivityNotify;
            return ins;
        }
    }
}

