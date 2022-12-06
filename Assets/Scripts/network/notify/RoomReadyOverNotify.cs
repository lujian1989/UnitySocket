using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomReadyOverNotify : Notify {
        public ReadyOverNotify readyOverNotify{ set; get; }

        public int hallId;

        public int roomId;

        public override string getCmd() {
            return "Room:ReadyOverNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)34;
        }

        public delegate void ReadyOverNotify(int hallId, int roomId);

        public override void readBin(Block _block) {
            hallId=_block.readInt();
            roomId=_block.readInt();
        }

        public override void handleResult() {
            readyOverNotify?.Invoke( hallId ,roomId );
        }

        public override Response newInstance() {
            RoomReadyOverNotify ins=new RoomReadyOverNotify();
            ins.readyOverNotify = readyOverNotify;
            return ins;
        }
    }
}

