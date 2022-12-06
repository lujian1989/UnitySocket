using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class DriftBottleGetDriftBottleStateRequest : Request {

        public override string getCmd() {
            return "DriftBottle:GetDriftBottleState";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)10;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

