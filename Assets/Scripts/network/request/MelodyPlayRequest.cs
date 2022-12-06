using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class MelodyPlayRequest : Request {
        public int audioId;

        public override string getCmd() {
            return "Melody:Play";
        }

        public override byte getClsID() {
            return (byte)93;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(audioId);
        }
    }
}

