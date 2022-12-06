using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class ShowGetFreeRoomRequest : Request {
        public int mainRoomId;

        public override string getCmd() {
            return "Show:GetFreeRoom";
        }

        public override byte getClsID() {
            return (byte)237;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(mainRoomId);
        }
    }
}

