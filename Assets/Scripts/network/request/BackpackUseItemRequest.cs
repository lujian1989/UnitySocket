using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class BackpackUseItemRequest : Request {
        public int id;

        public int num;

        public override string getCmd() {
            return "Backpack:UseItem";
        }

        public override byte getClsID() {
            return (byte)88;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(id);
            _block.writeInt(num);
        }
    }
}

