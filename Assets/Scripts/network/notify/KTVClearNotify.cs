using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class KTVClearNotify : Notify {
        public ClearNotify clearNotify{ set; get; }

        public override string getCmd() {
            return "KTV:ClearNotify";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)9;
        }

        public delegate void ClearNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            clearNotify?.Invoke();
        }

        public override Response newInstance() {
            KTVClearNotify ins=new KTVClearNotify();
            ins.clearNotify = clearNotify;
            return ins;
        }
    }
}

