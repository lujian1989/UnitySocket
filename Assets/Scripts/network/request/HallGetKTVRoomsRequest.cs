using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallGetKTVRoomsRequest : Request {
        public int pageNo;

        public int pageSize;

        public string roomType;

        public bool isDesc;

        public override string getCmd() {
            return "Hall:GetKTVRooms";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)48;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + HallSerializer.length(roomType) + Serializer.BooleanLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(pageNo);
            _block.writeInt(pageSize);
            _block.writeString(roomType);
            _block.writeBoolean(isDesc);
        }
    }
}

