using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ServiceCenterAutoCreateAndGetServiceRequest : Request {
        public string name;

        public override string getCmd() {
            return "ServiceCenter:AutoCreateAndGetService";
        }

        public override byte getClsID() {
            return (byte)236;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return   HallSerializer.length(name) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(name);
        }
    }
}

