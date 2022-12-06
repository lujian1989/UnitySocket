using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomCreateSubRoomRequest : Request {
        public string roomName;

        public string roomType;

        public int maxPlayers;

        public bool isAutoDestroy;

        public bool isPrivate;

        public List<PropertyValue> hallRoomInfo;

        public override string getCmd() {
            return "Room:CreateSubRoom";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)102;
        }

        public override int getBinLength() {
            return   RoomSerializer.length(roomName) + RoomSerializer.length(roomType) + Serializer.IntLength + Serializer.BooleanLength + Serializer.BooleanLength + RoomSerializer.getList_PropertyValue_Length(hallRoomInfo) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(roomName);
            _block.writeString(roomType);
            _block.writeInt(maxPlayers);
            _block.writeBoolean(isAutoDestroy);
            _block.writeBoolean(isPrivate);
            RoomSerializer.writeList_PropertyValue_(_block,hallRoomInfo);
        }
    }
}

