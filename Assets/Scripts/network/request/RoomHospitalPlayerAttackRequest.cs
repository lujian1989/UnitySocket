using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomHospitalPlayerAttackRequest : Request {
        public int weaponId;

        public int monsterObjectId;

        public int damage;

        public override string getCmd() {
            return "Room:HospitalPlayerAttack";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)65;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(weaponId);
            _block.writeInt(monsterObjectId);
            _block.writeInt(damage);
        }
    }
}

