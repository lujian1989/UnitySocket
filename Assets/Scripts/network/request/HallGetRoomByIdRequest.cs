using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallGetRoomByIdRequest : Request {
        public int roomId;

        public override string getCmd() {
            return "Hall:GetRoomById";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)46;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(roomId);
        }
    }
}

