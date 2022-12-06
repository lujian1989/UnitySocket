using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class DriftBottleNewDialogueNotify : Notify {
        public NewDialogueNotify newDialogueNotify{ set; get; }

        public List<DialogueObj> objs;

        public override string getCmd() {
            return "DriftBottle:NewDialogueNotify";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)6;
        }

        public delegate void NewDialogueNotify(List<DialogueObj> objs);

        public override void readBin(Block _block) {
            objs=HallSerializer.readList_DialogueObj_(_block);
        }

        public override void handleResult() {
            newDialogueNotify?.Invoke( objs );
        }

        public override Response newInstance() {
            DriftBottleNewDialogueNotify ins=new DriftBottleNewDialogueNotify();
            ins.newDialogueNotify = newDialogueNotify;
            return ins;
        }
    }
}

