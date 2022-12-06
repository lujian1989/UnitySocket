using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomShutupRequest : Request {
        public byte type;

        public int playerId;

        public override string getCmd() {
            return "Room:Shutup";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)10;
        }

        public override int getBinLength() {
            return   Serializer.ByteLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeByte(type);
            _block.writeInt(playerId);
        }
    }
}

