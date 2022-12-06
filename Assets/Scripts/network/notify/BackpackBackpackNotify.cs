using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class BackpackBackpackNotify : Notify {
        public BackpackNotify backpackNotify{ set; get; }

        public BackpackObj obj;

        public override string getCmd() {
            return "Backpack:BackpackNotify";
        }

        public override byte getClsID() {
            return (byte)88;
        }

        public override byte getMethodID() {
            return (byte)6;
        }

        public delegate void BackpackNotify(BackpackObj obj);

        public override void readBin(Block _block) {
            obj=GateSerializer.readBackpackObj(_block);
        }

        public override void handleResult() {
            backpackNotify?.Invoke( obj );
        }

        public override Response newInstance() {
            BackpackBackpackNotify ins=new BackpackBackpackNotify();
            ins.backpackNotify = backpackNotify;
            return ins;
        }
    }
}

