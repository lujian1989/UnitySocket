using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class DriftBottleDeleteDriftBottleRequest : Request {
        public int bottleId;

        public override string getCmd() {
            return "DriftBottle:DeleteDriftBottle";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)13;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(bottleId);
        }
    }
}

