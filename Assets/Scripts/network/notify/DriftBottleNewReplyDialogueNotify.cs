using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class DriftBottleNewReplyDialogueNotify : Notify {
        public NewReplyDialogueNotify newReplyDialogueNotify{ set; get; }

        public ReplyDialogueObj obj;

        public override string getCmd() {
            return "DriftBottle:NewReplyDialogueNotify";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public delegate void NewReplyDialogueNotify(ReplyDialogueObj obj);

        public override void readBin(Block _block) {
            obj=HallSerializer.readReplyDialogueObj(_block);
        }

        public override void handleResult() {
            newReplyDialogueNotify?.Invoke( obj );
        }

        public override Response newInstance() {
            DriftBottleNewReplyDialogueNotify ins=new DriftBottleNewReplyDialogueNotify();
            ins.newReplyDialogueNotify = newReplyDialogueNotify;
            return ins;
        }
    }
}

