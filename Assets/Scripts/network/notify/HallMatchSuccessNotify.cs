using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallMatchSuccessNotify : Notify {
        public MatchSuccessNotify matchSuccessNotify{ set; get; }

        public HallRoomInfo room;

        public override string getCmd() {
            return "Hall:MatchSuccessNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)28;
        }

        public delegate void MatchSuccessNotify(HallRoomInfo room);

        public override void readBin(Block _block) {
            room=HallSerializer.readHallRoomInfo(_block);
        }

        public override void handleResult() {
            matchSuccessNotify?.Invoke( room );
        }

        public override Response newInstance() {
            HallMatchSuccessNotify ins=new HallMatchSuccessNotify();
            ins.matchSuccessNotify = matchSuccessNotify;
            return ins;
        }
    }
}

