using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomChangeObjectStatusRequest : Request {
        public int objId;

        public int oriStatus;

        public int dstStatus;

        public override string getCmd() {
            return "Room:ChangeObjectStatus";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)120;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(objId);
            _block.writeInt(oriStatus);
            _block.writeInt(dstStatus);
        }
    }
}

