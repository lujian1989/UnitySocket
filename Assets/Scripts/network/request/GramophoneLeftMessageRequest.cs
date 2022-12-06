using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class GramophoneLeftMessageRequest : Request {
        public int owner;

        public int seconds;

        public string voiceId;

        public override string getCmd() {
            return "Gramophone:LeftMessage";
        }

        public override byte getClsID() {
            return (byte)90;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + GateSerializer.length(voiceId) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(owner);
            _block.writeInt(seconds);
            _block.writeString(voiceId);
        }
    }
}

