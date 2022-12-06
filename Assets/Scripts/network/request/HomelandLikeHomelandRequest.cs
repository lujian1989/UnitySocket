using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HomelandLikeHomelandRequest : Request {
        public int homelandId;

        public bool like;

        public override string getCmd() {
            return "Homeland:LikeHomeland";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.BooleanLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(homelandId);
            _block.writeBoolean(like);
        }
    }
}

