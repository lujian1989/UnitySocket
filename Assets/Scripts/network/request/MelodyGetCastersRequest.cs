using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class MelodyGetCastersRequest : Request {
        public int topCount;

        public override string getCmd() {
            return "Melody:GetCasters";
        }

        public override byte getClsID() {
            return (byte)93;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(topCount);
        }
    }
}

