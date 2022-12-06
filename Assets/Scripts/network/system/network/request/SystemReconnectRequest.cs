using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class SystemReconnectRequest : Request {
        public int userId;

        public int token;

        public int reqIdx;

        public int rspIdx;

        public override string getCmd() {
            return "System:Reconnect";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)111;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(userId);
            _block.writeInt(token);
            _block.writeInt(reqIdx);
            _block.writeInt(rspIdx);
        }
    }
}

