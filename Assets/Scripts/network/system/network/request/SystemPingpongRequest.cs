using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class SystemPingpongRequest : Request {

        public override string getCmd() {
            return "System:Pingpong";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)112;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

