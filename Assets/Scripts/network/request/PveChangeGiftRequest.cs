using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class PveChangeGiftRequest : Request {
        public int sourceId;

        public int targetId;

        public override string getCmd() {
            return "Pve:ChangeGift";
        }

        public override byte getClsID() {
            return (byte)94;
        }

        public override byte getMethodID() {
            return (byte)7;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(sourceId);
            _block.writeInt(targetId);
        }
    }
}

