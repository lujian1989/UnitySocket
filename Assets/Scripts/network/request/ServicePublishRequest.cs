using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ServicePublishRequest : Request {
        public int serviceId;

        public short typeID;

        public byte[] data;

        public override string getCmd() {
            return "Service:Publish";
        }

        public override byte getClsID() {
            return (byte)235;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.ShortLength + HallSerializer.length(data) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(serviceId);
            _block.writeShort(typeID);
            _block.writeByteArray(data);
        }
    }
}

