using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomThunderRoundStartNotify : Notify {
        public ThunderRoundStartNotify thunderRoundStartNotify{ set; get; }

        public int roundTime;

        public override string getCmd() {
            return "Room:ThunderRoundStartNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public delegate void ThunderRoundStartNotify(int roundTime);

        public override void readBin(Block _block) {
            roundTime=_block.readInt();
        }

        public override void handleResult() {
            thunderRoundStartNotify?.Invoke( roundTime );
        }

        public override Response newInstance() {
            RoomThunderRoundStartNotify ins=new RoomThunderRoundStartNotify();
            ins.thunderRoundStartNotify = thunderRoundStartNotify;
            return ins;
        }
    }
}

