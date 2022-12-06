using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomKillNotify : Notify {
        public KillNotify killNotify{ set; get; }

        public KillInfo info;

        public override string getCmd() {
            return "Room:KillNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)59;
        }

        public delegate void KillNotify(KillInfo info);

        public override void readBin(Block _block) {
            info=RoomSerializer.readKillInfo(_block);
        }

        public override void handleResult() {
            killNotify?.Invoke( info );
        }

        public override Response newInstance() {
            RoomKillNotify ins=new RoomKillNotify();
            ins.killNotify = killNotify;
            return ins;
        }
    }
}

