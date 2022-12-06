using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HomelandEndRoomModeNotify : Notify {
        public EndRoomModeNotify endRoomModeNotify{ set; get; }

        public override string getCmd() {
            return "Homeland:EndRoomModeNotify";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)9;
        }

        public delegate void EndRoomModeNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            endRoomModeNotify?.Invoke();
        }

        public override Response newInstance() {
            HomelandEndRoomModeNotify ins=new HomelandEndRoomModeNotify();
            ins.endRoomModeNotify = endRoomModeNotify;
            return ins;
        }
    }
}

