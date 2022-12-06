using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomAutoTrialToAllRequest : Request {
        public short type;

        public int id;

        public byte[] msg;

        public int delay;

        public override string getCmd() {
            return "Room:AutoTrialToAll";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)124;
        }

        public override int getBinLength() {
            return   Serializer.ShortLength + Serializer.IntLength + RoomSerializer.length(msg) + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeShort(type);
            _block.writeInt(id);
            _block.writeByteArray(msg);
            _block.writeInt(delay);
        }
    }
}

