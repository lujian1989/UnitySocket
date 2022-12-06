using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class BackpackUsePaperRequest : Request {
        public int id;

        public int receiver;

        public string content;

        public override string getCmd() {
            return "Backpack:UsePaper";
        }

        public override byte getClsID() {
            return (byte)88;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + GateSerializer.length(content) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(id);
            _block.writeInt(receiver);
            _block.writeString(content);
        }
    }
}

