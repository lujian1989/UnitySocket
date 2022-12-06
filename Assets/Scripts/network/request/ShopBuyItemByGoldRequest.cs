using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ShopBuyItemByGoldRequest : Request {
        public long id;

        public int num;

        public override string getCmd() {
            return "Shop:BuyItemByGold";
        }

        public override byte getClsID() {
            return (byte)96;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return   Serializer.LongLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeLong(id);
            _block.writeInt(num);
        }
    }
}

