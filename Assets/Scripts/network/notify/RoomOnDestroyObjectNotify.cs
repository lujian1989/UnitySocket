using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnDestroyObjectNotify : Notify {
        public OnDestroyObjectNotify onDestroyObjectNotify{ set; get; }

        public int objId;

        public override string getCmd() {
            return "Room:OnDestroyObjectNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)51;
        }

        public delegate void OnDestroyObjectNotify(int objId);

        public override void readBin(Block _block) {
            objId=_block.readInt();
        }

        public override void handleResult() {
            onDestroyObjectNotify?.Invoke( objId );
        }

        public override Response newInstance() {
            RoomOnDestroyObjectNotify ins=new RoomOnDestroyObjectNotify();
            ins.onDestroyObjectNotify = onDestroyObjectNotify;
            return ins;
        }
    }
}

