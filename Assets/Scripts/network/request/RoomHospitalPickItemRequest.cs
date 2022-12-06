using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomHospitalPickItemRequest : Request {
        public int monsterObjectId;

        public int dropObjectId;

        public override string getCmd() {
            return "Room:HospitalPickItem";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)67;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(monsterObjectId);
            _block.writeInt(dropObjectId);
        }
    }
}

