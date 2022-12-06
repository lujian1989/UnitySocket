using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class SystemEnterHallNotify : Notify {
        public EnterHallNotify enterHallNotify{ set; get; }

        public int hallId;

        public override string getCmd() {
            return "System:EnterHallNotify";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)122;
        }

        public delegate void EnterHallNotify(int hallId);

        public override void readBin(Block _block) {
            hallId=_block.readInt();
        }

        public override void handleResult() {
            enterHallNotify?.Invoke( hallId );
        }

        public override Response newInstance() {
            SystemEnterHallNotify ins=new SystemEnterHallNotify();
            ins.enterHallNotify = enterHallNotify;
            return ins;
        }
    }
}

