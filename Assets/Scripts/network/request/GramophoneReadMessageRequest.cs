using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class GramophoneReadMessageRequest : Request {
        public int id;

        public override string getCmd() {
            return "Gramophone:ReadMessage";
        }

        public override byte getClsID() {
            return (byte)90;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(id);
        }
    }
}

