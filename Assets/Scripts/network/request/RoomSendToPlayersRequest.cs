using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomSendToPlayersRequest : Request {
        public int[] players;

        public short type;

        public byte[] msg;

        public override string getCmd() {
            return "Room:SendToPlayers";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)12;
        }

        public override int getBinLength() {
            return   RoomSerializer.length(players) + Serializer.ShortLength + RoomSerializer.length(msg) ;
        }

        public override void writeBin(Block _block) {
            _block.writeIntArray(players);
            _block.writeShort(type);
            _block.writeByteArray(msg);
        }
    }
}

