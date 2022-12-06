using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomAttackRequest : Request {
        public int round;

        public int enemy;

        public int weaponId;

        public int damage;

        public override string getCmd() {
            return "Room:Attack";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)127;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(round);
            _block.writeInt(enemy);
            _block.writeInt(weaponId);
            _block.writeInt(damage);
        }
    }
}

