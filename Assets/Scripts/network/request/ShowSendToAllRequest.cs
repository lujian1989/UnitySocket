using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ShowSendToAllRequest : Request {
        public bool self;

        public short type;

        public byte[] msg;

        public override string getCmd() {
            return "Show:SendToAll";
        }

        public override byte getClsID() {
            return (byte)237;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   Serializer.BooleanLength + Serializer.ShortLength + HallSerializer.length(msg) ;
        }

        public override void writeBin(Block _block) {
            _block.writeBoolean(self);
            _block.writeShort(type);
            _block.writeByteArray(msg);
        }
    }
}

