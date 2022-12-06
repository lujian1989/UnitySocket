using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class MelodyGetPlayListRequest : Request {
        public int casterId;

        public override string getCmd() {
            return "Melody:GetPlayList";
        }

        public override byte getClsID() {
            return (byte)93;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(casterId);
        }
    }
}

