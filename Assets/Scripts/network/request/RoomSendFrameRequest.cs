using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomSendFrameRequest : Request {
        public byte[] data;

        public override string getCmd() {
            return "Room:SendFrame";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)15;
        }

        public override int getBinLength() {
            return   RoomSerializer.length(data) ;
        }

        public override void writeBin(Block _block) {
            _block.writeByteArray(data);
        }
    }
}

