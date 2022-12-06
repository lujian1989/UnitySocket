using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class KTVTopRequest : Request {
        public string songId;

        public int singer;

        public override string getCmd() {
            return "KTV:Top";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   HallSerializer.length(songId) + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(songId);
            _block.writeInt(singer);
        }
    }
}

