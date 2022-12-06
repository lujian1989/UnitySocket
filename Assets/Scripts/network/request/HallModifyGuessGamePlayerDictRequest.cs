using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallModifyGuessGamePlayerDictRequest : Request {
        public int oper;

        public int userId;

        public int val;

        public override string getCmd() {
            return "Hall:ModifyGuessGamePlayerDict";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)26;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(oper);
            _block.writeInt(userId);
            _block.writeInt(val);
        }
    }
}

