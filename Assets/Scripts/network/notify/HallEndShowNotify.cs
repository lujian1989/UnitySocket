using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallEndShowNotify : Notify {
        public EndShowNotify endShowNotify{ set; get; }

        public override string getCmd() {
            return "Hall:EndShowNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)60;
        }

        public delegate void EndShowNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            endShowNotify?.Invoke();
        }

        public override Response newInstance() {
            HallEndShowNotify ins=new HallEndShowNotify();
            ins.endShowNotify = endShowNotify;
            return ins;
        }
    }
}

