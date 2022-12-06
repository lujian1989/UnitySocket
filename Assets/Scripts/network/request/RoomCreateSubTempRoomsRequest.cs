using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomCreateSubTempRoomsRequest : Request {
        public int num;

        public int maxPlayers;

        public override string getCmd() {
            return "Room:CreateSubTempRooms";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)99;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(num);
            _block.writeInt(maxPlayers);
        }
    }
}

