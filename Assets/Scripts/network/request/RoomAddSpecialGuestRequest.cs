using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomAddSpecialGuestRequest : Request {
        public SpecialGuestInfo guestInfo;

        public override string getCmd() {
            return "Room:AddSpecialGuest";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)130;
        }

        public override int getBinLength() {
            return   RoomSerializer.getSpecialGuestInfoLength(guestInfo) ;
        }

        public override void writeBin(Block _block) {
            RoomSerializer.writeSpecialGuestInfo(_block,guestInfo);
        }
    }
}

