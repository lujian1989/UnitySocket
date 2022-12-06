using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class SystemLoginRequest : Request {
        public int version;

        public int userId;

        public int token;

        public override string getCmd() {
            return "System:Login";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)110;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(version);
            _block.writeInt(userId);
            _block.writeInt(token);
        }
    }
}

