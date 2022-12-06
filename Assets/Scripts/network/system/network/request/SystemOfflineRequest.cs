using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class SystemOfflineRequest : Request {

        public override string getCmd() {
            return "System:Offline";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)123;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

