using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class DriftBottleReplyDriftBottleRequest : Request {
        public int bottleId;

        public int seconds;

        public string voiceId;

        public string content;

        public string imgUrl;

        public override string getCmd() {
            return "DriftBottle:ReplyDriftBottle";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + HallSerializer.length(voiceId) + HallSerializer.length(content) + HallSerializer.length(imgUrl) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(bottleId);
            _block.writeInt(seconds);
            _block.writeString(voiceId);
            _block.writeString(content);
            _block.writeString(imgUrl);
        }
    }
}

