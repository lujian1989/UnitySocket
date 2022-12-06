using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomSendToAllRequest : Request {
        public short type;

        public byte[] msg;

        public override string getCmd() {
            return "Room:SendToAll";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)14;
        }

        public override int getBinLength() {
            return   Serializer.ShortLength + RoomSerializer.length(msg) ;
        }

        public override void writeBin(Block _block) {
            _block.writeShort(type);
            _block.writeByteArray(msg);
        }
    }
}

