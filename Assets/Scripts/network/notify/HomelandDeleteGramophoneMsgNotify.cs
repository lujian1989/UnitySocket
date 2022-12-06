using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HomelandDeleteGramophoneMsgNotify : Notify {
        public DeleteGramophoneMsgNotify deleteGramophoneMsgNotify{ set; get; }

        public int owner;

        public int id;

        public override string getCmd() {
            return "Homeland:DeleteGramophoneMsgNotify";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)10;
        }

        public delegate void DeleteGramophoneMsgNotify(int owner, int id);

        public override void readBin(Block _block) {
            owner=_block.readInt();
            id=_block.readInt();
        }

        public override void handleResult() {
            deleteGramophoneMsgNotify?.Invoke( owner ,id );
        }

        public override Response newInstance() {
            HomelandDeleteGramophoneMsgNotify ins=new HomelandDeleteGramophoneMsgNotify();
            ins.deleteGramophoneMsgNotify = deleteGramophoneMsgNotify;
            return ins;
        }
    }
}

