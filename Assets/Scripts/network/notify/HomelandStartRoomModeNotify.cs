using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HomelandStartRoomModeNotify : Notify {
        public StartRoomModeNotify startRoomModeNotify{ set; get; }

        public int roomId;

        public override string getCmd() {
            return "Homeland:StartRoomModeNotify";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public delegate void StartRoomModeNotify(int roomId);

        public override void readBin(Block _block) {
            roomId=_block.readInt();
        }

        public override void handleResult() {
            startRoomModeNotify?.Invoke( roomId );
        }

        public override Response newInstance() {
            HomelandStartRoomModeNotify ins=new HomelandStartRoomModeNotify();
            ins.startRoomModeNotify = startRoomModeNotify;
            return ins;
        }
    }
}

