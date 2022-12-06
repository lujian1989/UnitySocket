using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class SystemKickNotify : Notify {
        public KickNotify kickNotify{ set; get; }

        public override string getCmd() {
            return "System:KickNotify";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)103;
        }

        public delegate void KickNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            kickNotify?.Invoke();
        }

        public override Response newInstance() {
            SystemKickNotify ins=new SystemKickNotify();
            ins.kickNotify = kickNotify;
            return ins;
        }
    }
}

