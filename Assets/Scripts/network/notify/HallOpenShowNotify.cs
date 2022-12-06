using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallOpenShowNotify : Notify {
        public OpenShowNotify openShowNotify{ set; get; }

        public override string getCmd() {
            return "Hall:OpenShowNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)20;
        }

        public delegate void OpenShowNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            openShowNotify?.Invoke();
        }

        public override Response newInstance() {
            HallOpenShowNotify ins=new HallOpenShowNotify();
            ins.openShowNotify = openShowNotify;
            return ins;
        }
    }
}

