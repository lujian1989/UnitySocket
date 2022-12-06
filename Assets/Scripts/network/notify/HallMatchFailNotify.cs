using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallMatchFailNotify : Notify {
        public MatchFailNotify matchFailNotify{ set; get; }

        public int errorCode;

        public string info;

        public override string getCmd() {
            return "Hall:MatchFailNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)29;
        }

        public delegate void MatchFailNotify(int errorCode, string info);

        public override void readBin(Block _block) {
            errorCode=_block.readInt();
            info=_block.readString();
        }

        public override void handleResult() {
            matchFailNotify?.Invoke( errorCode ,info );
        }

        public override Response newInstance() {
            HallMatchFailNotify ins=new HallMatchFailNotify();
            ins.matchFailNotify = matchFailNotify;
            return ins;
        }
    }
}

