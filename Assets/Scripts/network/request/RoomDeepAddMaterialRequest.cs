using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomDeepAddMaterialRequest : Request {
        public int level;

        public int num;

        public override string getCmd() {
            return "Room:DeepAddMaterial";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)96;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(level);
            _block.writeInt(num);
        }
    }
}

