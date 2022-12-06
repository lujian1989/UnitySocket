using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomRequestFrameRequest : Request {
        public int beginFrameId;

        public int endFrameId;

        public override string getCmd() {
            return "Room:RequestFrame";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)31;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(beginFrameId);
            _block.writeInt(endFrameId);
        }
    }
}

