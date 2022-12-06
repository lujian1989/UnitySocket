using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class BackpackDeleteItemRequest : Request {
        public int id;

        public override string getCmd() {
            return "Backpack:DeleteItem";
        }

        public override byte getClsID() {
            return (byte)88;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(id);
        }
    }
}

