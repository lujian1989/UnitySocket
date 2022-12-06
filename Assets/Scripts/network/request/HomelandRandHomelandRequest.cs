using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HomelandRandHomelandRequest : Request {

        public override string getCmd() {
            return "Homeland:RandHomeland";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

