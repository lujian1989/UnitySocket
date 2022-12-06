using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HomelandLeaveHomelandRequest : Request {

        public override string getCmd() {
            return "Homeland:LeaveHomeland";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

