using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomHospitalMonsterAttackRequest : Request {
        public int monsterObjectId;

        public int damage;

        public override string getCmd() {
            return "Room:HospitalMonsterAttack";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)70;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(monsterObjectId);
            _block.writeInt(damage);
        }
    }
}

