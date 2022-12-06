using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class SystemCloseNotify : Notify {
        public CloseNotify closeNotify{ set; get; }

        public override string getCmd() {
            return "System:CloseNotify";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)102;
        }

        public delegate void CloseNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            closeNotify?.Invoke();
        }

        public override Response newInstance() {
            SystemCloseNotify ins=new SystemCloseNotify();
            ins.closeNotify = closeNotify;
            return ins;
        }
    }
}

