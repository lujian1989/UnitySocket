using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallVoteRequest : Request {
        public int userId;

        public int num;

        public override string getCmd() {
            return "Hall:Vote";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(userId);
            _block.writeInt(num);
        }
    }
}

