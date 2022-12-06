using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallCreateTutorialRoomRequest : Request {
        public string roomName;

        public string roomType;

        public int maxPlayers;

        public bool isAutoDestroy;

        public bool isPrivate;

        public List<PropertyValue> hallRoomInfo;

        public override string getCmd() {
            return "Hall:CreateTutorialRoom";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)62;
        }

        public override int getBinLength() {
            return   HallSerializer.length(roomName) + HallSerializer.length(roomType) + Serializer.IntLength + Serializer.BooleanLength + Serializer.BooleanLength + HallSerializer.getList_PropertyValue_Length(hallRoomInfo) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(roomName);
            _block.writeString(roomType);
            _block.writeInt(maxPlayers);
            _block.writeBoolean(isAutoDestroy);
            _block.writeBoolean(isPrivate);
            HallSerializer.writeList_PropertyValue_(_block,hallRoomInfo);
        }
    }
}

