using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomModifyRoomInfoRequest : Request {
        public string roomName;

        public bool isPrivate;

        public string customProperties;

        public bool isForbidJoin;

        public override string getCmd() {
            return "Room:ModifyRoomInfo";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)57;
        }

        public override int getBinLength() {
            return   RoomSerializer.length(roomName) + Serializer.BooleanLength + RoomSerializer.length(customProperties) + Serializer.BooleanLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(roomName);
            _block.writeBoolean(isPrivate);
            _block.writeString(customProperties);
            _block.writeBoolean(isForbidJoin);
        }
    }
}

