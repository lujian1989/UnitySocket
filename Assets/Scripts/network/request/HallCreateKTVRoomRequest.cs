using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallCreateKTVRoomRequest : Request {
        public int mapId;

        public int pwd;

        public int timeSize;

        public int roomSize;

        public string roomName;

        public string roomType;

        public int coinType;

        public bool isAutoDestroy;

        public List<PropertyValue> hallRoomInfo;

        public override string getCmd() {
            return "Hall:CreateKTVRoom";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)64;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + Serializer.IntLength + Serializer.IntLength + HallSerializer.length(roomName) + HallSerializer.length(roomType) + Serializer.IntLength + Serializer.BooleanLength + HallSerializer.getList_PropertyValue_Length(hallRoomInfo) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(mapId);
            _block.writeInt(pwd);
            _block.writeInt(timeSize);
            _block.writeInt(roomSize);
            _block.writeString(roomName);
            _block.writeString(roomType);
            _block.writeInt(coinType);
            _block.writeBoolean(isAutoDestroy);
            HallSerializer.writeList_PropertyValue_(_block,hallRoomInfo);
        }
    }
}

