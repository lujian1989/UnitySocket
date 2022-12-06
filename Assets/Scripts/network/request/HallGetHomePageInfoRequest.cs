using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallGetHomePageInfoRequest : Request {
        public int pageNo;

        public int pageSize;

        public string roomType;

        public bool isDesc;

        public int[] hallIds;

        public override string getCmd() {
            return "Hall:GetHomePageInfo";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)50;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + HallSerializer.length(roomType) + Serializer.BooleanLength + HallSerializer.length(hallIds) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(pageNo);
            _block.writeInt(pageSize);
            _block.writeString(roomType);
            _block.writeBoolean(isDesc);
            _block.writeIntArray(hallIds);
        }
    }
}

