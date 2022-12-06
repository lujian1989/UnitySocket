using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallGetStreetPannelInfoRequest : Request {

        public override string getCmd() {
            return "Hall:GetStreetPannelInfo";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)38;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

