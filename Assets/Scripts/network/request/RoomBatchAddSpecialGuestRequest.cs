using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomBatchAddSpecialGuestRequest : Request {
        public List<SpecialGuestInfo> list;

        public override string getCmd() {
            return "Room:BatchAddSpecialGuest";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)123;
        }

        public override int getBinLength() {
            return   RoomSerializer.getList_SpecialGuestInfo_Length(list) ;
        }

        public override void writeBin(Block _block) {
            RoomSerializer.writeList_SpecialGuestInfo_(_block,list);
        }
    }
}

