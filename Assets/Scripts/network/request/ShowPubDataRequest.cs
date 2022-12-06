using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ShowPubDataRequest : Request {
        public short type;

        public byte[] msg;

        public override string getCmd() {
            return "Show:PubData";
        }

        public override byte getClsID() {
            return (byte)237;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return   Serializer.ShortLength + HallSerializer.length(msg) ;
        }

        public override void writeBin(Block _block) {
            _block.writeShort(type);
            _block.writeByteArray(msg);
        }
    }
}

