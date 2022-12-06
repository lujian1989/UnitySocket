using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallSetTitleRequest : Request {
        public int type;

        public int userId;

        public int titleId;

        public override string getCmd() {
            return "Hall:SetTitle";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)11;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(type);
            _block.writeInt(userId);
            _block.writeInt(titleId);
        }
    }
}

