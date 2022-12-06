using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallKeepMatchRequest : Request {
        public int hallId;

        public int oldMapId;

        public int oldRoomId;

        public override string getCmd() {
            return "Hall:KeepMatch";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)35;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(hallId);
            _block.writeInt(oldMapId);
            _block.writeInt(oldRoomId);
        }
    }
}

