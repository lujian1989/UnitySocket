using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomAutoSendToAllRequest : Request {
        public short type;

        public byte[] msg;

        public int delay;

        public override string getCmd() {
            return "Room:AutoSendToAll";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)125;
        }

        public override int getBinLength() {
            return   Serializer.ShortLength + RoomSerializer.length(msg) + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeShort(type);
            _block.writeByteArray(msg);
            _block.writeInt(delay);
        }
    }
}

