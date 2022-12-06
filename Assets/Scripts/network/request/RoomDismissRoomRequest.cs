using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomDismissRoomRequest : Request {

        public override string getCmd() {
            return "Room:DismissRoom";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)89;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

