using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallKickoutFromKTVRoomRequest : Request {
        public int playerId;

        public override string getCmd() {
            return "Hall:KickoutFromKTVRoom";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)34;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(playerId);
        }
    }
}

