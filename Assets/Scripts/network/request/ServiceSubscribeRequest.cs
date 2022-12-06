using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ServiceSubscribeRequest : Request {
        public int serviceId;

        public override string getCmd() {
            return "Service:Subscribe";
        }

        public override byte getClsID() {
            return (byte)235;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(serviceId);
        }
    }
}

