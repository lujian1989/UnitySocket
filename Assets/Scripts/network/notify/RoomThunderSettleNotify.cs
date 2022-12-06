using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomThunderSettleNotify : Notify {
        public ThunderSettleNotify thunderSettleNotify{ set; get; }

        public ThunderAwardInfo info;

        public override string getCmd() {
            return "Room:ThunderSettleNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public delegate void ThunderSettleNotify(ThunderAwardInfo info);

        public override void readBin(Block _block) {
            info=RoomSerializer.readThunderAwardInfo(_block);
        }

        public override void handleResult() {
            thunderSettleNotify?.Invoke( info );
        }

        public override Response newInstance() {
            RoomThunderSettleNotify ins=new RoomThunderSettleNotify();
            ins.thunderSettleNotify = thunderSettleNotify;
            return ins;
        }
    }
}

