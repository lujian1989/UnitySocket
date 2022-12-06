using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomGetFreeSubRoomRequest : Request {
        public int hallId;

        public int roomId;

        public string roomType;

        public override string getCmd() {
            return "Room:GetFreeSubRoom";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)84;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + RoomSerializer.length(roomType) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(hallId);
            _block.writeInt(roomId);
            _block.writeString(roomType);
        }
    }
}

