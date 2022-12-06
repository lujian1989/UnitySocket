using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HomelandNewGramophoneMsgNotify : Notify {
        public NewGramophoneMsgNotify newGramophoneMsgNotify{ set; get; }

        public MessageObj obj;

        public override string getCmd() {
            return "Homeland:NewGramophoneMsgNotify";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public delegate void NewGramophoneMsgNotify(MessageObj obj);

        public override void readBin(Block _block) {
            obj=HallSerializer.readMessageObj(_block);
        }

        public override void handleResult() {
            newGramophoneMsgNotify?.Invoke( obj );
        }

        public override Response newInstance() {
            HomelandNewGramophoneMsgNotify ins=new HomelandNewGramophoneMsgNotify();
            ins.newGramophoneMsgNotify = newGramophoneMsgNotify;
            return ins;
        }
    }
}

