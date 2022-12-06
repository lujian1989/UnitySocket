using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomSetHomePhotoFramesUrlRequest : Request {
        public int itemCode;

        public string url;

        public override string getCmd() {
            return "Room:SetHomePhotoFramesUrl";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)11;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + RoomSerializer.length(url) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(itemCode);
            _block.writeString(url);
        }
    }
}

