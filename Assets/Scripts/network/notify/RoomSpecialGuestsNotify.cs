using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomSpecialGuestsNotify : Notify {
        public SpecialGuestsNotify specialGuestsNotify{ set; get; }

        public int oper;

        public List<SpecialGuestInfo> guestInfos;

        public override string getCmd() {
            return "Room:SpecialGuestsNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)9;
        }

        public delegate void SpecialGuestsNotify(int oper, List<SpecialGuestInfo> guestInfos);

        public override void readBin(Block _block) {
            oper=_block.readInt();
            guestInfos=RoomSerializer.readList_SpecialGuestInfo_(_block);
        }

        public override void handleResult() {
            specialGuestsNotify?.Invoke( oper ,guestInfos );
        }

        public override Response newInstance() {
            RoomSpecialGuestsNotify ins=new RoomSpecialGuestsNotify();
            ins.specialGuestsNotify = specialGuestsNotify;
            return ins;
        }
    }
}

