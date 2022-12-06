using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallGetRoomListByTypeRequest : Request {
        public string roomType;

        public bool isDesc;

        public override string getCmd() {
            return "Hall:GetRoomListByType";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)43;
        }

        public override int getBinLength() {
            return   HallSerializer.length(roomType) + Serializer.BooleanLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(roomType);
            _block.writeBoolean(isDesc);
        }
    }
}

