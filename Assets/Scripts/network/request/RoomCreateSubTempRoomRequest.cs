using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomCreateSubTempRoomRequest : Request {
        public int maxPlayers;

        public override string getCmd() {
            return "Room:CreateSubTempRoom";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)100;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(maxPlayers);
        }
    }
}

