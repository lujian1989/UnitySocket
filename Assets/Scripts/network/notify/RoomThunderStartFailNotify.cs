using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomThunderStartFailNotify : Notify {
        public ThunderStartFailNotify thunderStartFailNotify{ set; get; }

        public override string getCmd() {
            return "Room:ThunderStartFailNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public delegate void ThunderStartFailNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            thunderStartFailNotify?.Invoke();
        }

        public override Response newInstance() {
            RoomThunderStartFailNotify ins=new RoomThunderStartFailNotify();
            ins.thunderStartFailNotify = thunderStartFailNotify;
            return ins;
        }
    }
}

