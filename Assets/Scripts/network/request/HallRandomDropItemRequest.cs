using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallRandomDropItemRequest : Request {
        public int dropId;

        public int objId;

        public override string getCmd() {
            return "Hall:RandomDropItem";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)17;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(dropId);
            _block.writeInt(objId);
        }
    }
}

