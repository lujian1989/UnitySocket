using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ShopBuyItemRequest : Request {
        public long id;

        public int num;

        public override string getCmd() {
            return "Shop:BuyItem";
        }

        public override byte getClsID() {
            return (byte)96;
        }

        public override byte getMethodID() {
            return (byte)3;
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

