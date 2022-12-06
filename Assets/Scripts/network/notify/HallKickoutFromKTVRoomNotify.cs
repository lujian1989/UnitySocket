using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallKickoutFromKTVRoomNotify : Notify {
        public KickoutFromKTVRoomNotify kickoutFromKTVRoomNotify{ set; get; }

        public override string getCmd() {
            return "Hall:KickoutFromKTVRoomNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)33;
        }

        public delegate void KickoutFromKTVRoomNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            kickoutFromKTVRoomNotify?.Invoke();
        }

        public override Response newInstance() {
            HallKickoutFromKTVRoomNotify ins=new HallKickoutFromKTVRoomNotify();
            ins.kickoutFromKTVRoomNotify = kickoutFromKTVRoomNotify;
            return ins;
        }
    }
}

