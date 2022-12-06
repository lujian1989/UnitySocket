using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ServiceCenterTestRequest : Request {
        public int[] data;

        public override string getCmd() {
            return "ServiceCenter:Test";
        }

        public override byte getClsID() {
            return (byte)236;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   HallSerializer.length(data) ;
        }

        public override void writeBin(Block _block) {
            _block.writeIntArray(data);
        }
    }
}

