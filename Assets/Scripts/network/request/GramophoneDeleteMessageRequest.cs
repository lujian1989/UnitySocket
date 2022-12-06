using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class GramophoneDeleteMessageRequest : Request {
        public int owner;

        public int id;

        public override string getCmd() {
            return "Gramophone:DeleteMessage";
        }

        public override byte getClsID() {
            return (byte)90;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(owner);
            _block.writeInt(id);
        }
    }
}

