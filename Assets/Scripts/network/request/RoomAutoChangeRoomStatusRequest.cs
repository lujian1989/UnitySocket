using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomAutoChangeRoomStatusRequest : Request {
        public int oriStatus;

        public int dstStatus;

        public int delay;

        public override string getCmd() {
            return "Room:AutoChangeRoomStatus";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)126;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(oriStatus);
            _block.writeInt(dstStatus);
            _block.writeInt(delay);
        }
    }
}

