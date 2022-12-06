using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class DriftBottleSendDriftBottleRequest : Request {
        public int seconds;

        public string voiceId;

        public string content;

        public string imgUrl;

        public override string getCmd() {
            return "DriftBottle:SendDriftBottle";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + HallSerializer.length(voiceId) + HallSerializer.length(content) + HallSerializer.length(imgUrl) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(seconds);
            _block.writeString(voiceId);
            _block.writeString(content);
            _block.writeString(imgUrl);
        }
    }
}

