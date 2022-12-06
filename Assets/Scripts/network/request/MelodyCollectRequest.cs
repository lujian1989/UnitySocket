using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class MelodyCollectRequest : Request {
        public int audioId;

        public bool isCollect;

        public override string getCmd() {
            return "Melody:Collect";
        }

        public override byte getClsID() {
            return (byte)93;
        }

        public override byte getMethodID() {
            return (byte)6;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.BooleanLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(audioId);
            _block.writeBoolean(isCollect);
        }
    }
}

