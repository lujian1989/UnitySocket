using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ServicePublishPropertyRequest : Request {
        public int serviceId;

        public short index;

        public byte[] data;

        public override string getCmd() {
            return "Service:PublishProperty";
        }

        public override byte getClsID() {
            return (byte)235;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.ShortLength + HallSerializer.length(data) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(serviceId);
            _block.writeShort(index);
            _block.writeByteArray(data);
        }
    }
}

