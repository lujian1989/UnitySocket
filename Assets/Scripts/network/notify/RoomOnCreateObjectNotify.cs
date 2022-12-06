using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnCreateObjectNotify : Notify {
        public OnCreateObjectNotify onCreateObjectNotify{ set; get; }

        public ERoomObject obj;

        public override string getCmd() {
            return "Room:OnCreateObjectNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)52;
        }

        public delegate void OnCreateObjectNotify(ERoomObject obj);

        public override void readBin(Block _block) {
            obj=RoomSerializer.readERoomObject(_block);
        }

        public override void handleResult() {
            onCreateObjectNotify?.Invoke( obj );
        }

        public override Response newInstance() {
            RoomOnCreateObjectNotify ins=new RoomOnCreateObjectNotify();
            ins.onCreateObjectNotify = onCreateObjectNotify;
            return ins;
        }
    }
}

