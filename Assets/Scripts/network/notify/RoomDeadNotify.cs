using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomDeadNotify : Notify {
        public DeadNotify deadNotify{ set; get; }

        public int deaderUserId;

        public override string getCmd() {
            return "Room:DeadNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)98;
        }

        public delegate void DeadNotify(int deaderUserId);

        public override void readBin(Block _block) {
            deaderUserId=_block.readInt();
        }

        public override void handleResult() {
            deadNotify?.Invoke( deaderUserId );
        }

        public override Response newInstance() {
            RoomDeadNotify ins=new RoomDeadNotify();
            ins.deadNotify = deadNotify;
            return ins;
        }
    }
}

