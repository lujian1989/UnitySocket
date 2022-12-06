using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomHospitalCreateMonsterRequest : Request {
        public int monsterId;

        public int point;

        public int num;

        public override string getCmd() {
            return "Room:HospitalCreateMonster";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)74;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(monsterId);
            _block.writeInt(point);
            _block.writeInt(num);
        }
    }
}

