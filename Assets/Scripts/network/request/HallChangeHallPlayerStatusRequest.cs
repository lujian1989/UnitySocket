using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallChangeHallPlayerStatusRequest : Request {
        public int oriStatus;

        public int dstStatus;

        public override string getCmd() {
            return "Hall:ChangeHallPlayerStatus";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)81;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(oriStatus);
            _block.writeInt(dstStatus);
        }
    }
}

