using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomEnterRoomRequest : Request {
        public ERoomPlayer player;

        public int hallId;

        public int roomId;

        public long enterTime;

        public override string getCmd() {
            return "Room:EnterRoom";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)88;
        }

        public override int getBinLength() {
            return   RoomSerializer.getERoomPlayerLength(player) + Serializer.IntLength + Serializer.IntLength + Serializer.LongLength ;
        }

        public override void writeBin(Block _block) {
            RoomSerializer.writeERoomPlayer(_block,player);
            _block.writeInt(hallId);
            _block.writeInt(roomId);
            _block.writeLong(enterTime);
        }
    }
}

