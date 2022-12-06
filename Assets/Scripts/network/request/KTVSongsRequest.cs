using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class KTVSongsRequest : Request {
        public int hallId;

        public int mainRoomId;

        public override string getCmd() {
            return "KTV:Songs";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(hallId);
            _block.writeInt(mainRoomId);
        }
    }
}

