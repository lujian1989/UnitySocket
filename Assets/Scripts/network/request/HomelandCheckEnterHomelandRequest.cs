using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HomelandCheckEnterHomelandRequest : Request {
        public int userId;

        public override string getCmd() {
            return "Homeland:CheckEnterHomeland";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)11;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(userId);
        }
    }
}

