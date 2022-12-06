using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallCheckEnterHallRequest : Request {
        public int hallId;

        public override string getCmd() {
            return "Hall:CheckEnterHall";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)75;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(hallId);
        }
    }
}

