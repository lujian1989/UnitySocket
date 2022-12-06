using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomHospitalSavePlayerRequest : Request {
        public int type;

        public int target;

        public int addHp;

        public override string getCmd() {
            return "Room:HospitalSavePlayer";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)61;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(type);
            _block.writeInt(target);
            _block.writeInt(addHp);
        }
    }
}

