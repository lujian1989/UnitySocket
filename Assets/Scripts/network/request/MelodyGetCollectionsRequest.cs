using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class MelodyGetCollectionsRequest : Request {

        public override string getCmd() {
            return "Melody:GetCollections";
        }

        public override byte getClsID() {
            return (byte)93;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

