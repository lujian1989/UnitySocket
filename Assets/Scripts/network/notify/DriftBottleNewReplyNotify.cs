using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class DriftBottleNewReplyNotify : Notify {
        public NewReplyNotify newReplyNotify{ set; get; }

        public ReplyObj obj;

        public override string getCmd() {
            return "DriftBottle:NewReplyNotify";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public delegate void NewReplyNotify(ReplyObj obj);

        public override void readBin(Block _block) {
            obj=HallSerializer.readReplyObj(_block);
        }

        public override void handleResult() {
            newReplyNotify?.Invoke( obj );
        }

        public override Response newInstance() {
            DriftBottleNewReplyNotify ins=new DriftBottleNewReplyNotify();
            ins.newReplyNotify = newReplyNotify;
            return ins;
        }
    }
}

