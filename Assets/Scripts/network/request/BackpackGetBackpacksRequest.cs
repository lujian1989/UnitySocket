using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class BackpackGetBackpacksRequest : Request {

        public override string getCmd() {
            return "Backpack:GetBackpacks";
        }

        public override byte getClsID() {
            return (byte)88;
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

