using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ShopGetShopListRequest : Request {

        public override string getCmd() {
            return "Shop:GetShopList";
        }

        public override byte getClsID() {
            return (byte)96;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

