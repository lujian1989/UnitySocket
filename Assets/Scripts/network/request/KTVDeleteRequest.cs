using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class KTVDeleteRequest : Request {
        public string songId;

        public int singer;

        public override string getCmd() {
            return "KTV:Delete";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)7;
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

