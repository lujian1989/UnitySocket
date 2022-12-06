using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomNewGramophoneMsgNotify : Notify {
        public NewGramophoneMsgNotify newGramophoneMsgNotify{ set; get; }

        public MessageObj obj;

        public override string getCmd() {
            return "Room:NewGramophoneMsgNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)56;
        }

        public delegate void NewGramophoneMsgNotify(MessageObj obj);

        public override void readBin(Block _block) {
            obj=RoomSerializer.readMessageObj(_block);
        }

        public override void handleResult() {
            newGramophoneMsgNotify?.Invoke( obj );
        }

        public override Response newInstance() {
            RoomNewGramophoneMsgNotify ins=new RoomNewGramophoneMsgNotify();
            ins.newGramophoneMsgNotify = newGramophoneMsgNotify;
            return ins;
        }
    }
}

