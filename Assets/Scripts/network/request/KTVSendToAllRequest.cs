using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class KTVSendToAllRequest : Request {
        public int hallId;

        public int mainRoomId;

        public short type;

        public byte[] msg;

        public override string getCmd() {
            return "KTV:SendToAll";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.ShortLength + HallSerializer.length(msg) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(hallId);
            _block.writeInt(mainRoomId);
            _block.writeShort(type);
            _block.writeByteArray(msg);
        }
    }
}

