using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallCheckKTVEnterValidRequest : Request {
        public int hallId;

        public int roomId;

        public override string getCmd() {
            return "Hall:CheckKTVEnterValid";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)73;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(hallId);
            _block.writeInt(roomId);
        }
    }
}

