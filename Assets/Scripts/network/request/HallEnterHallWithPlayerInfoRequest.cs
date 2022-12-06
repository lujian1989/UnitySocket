using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallEnterHallWithPlayerInfoRequest : Request {
        public int hallId;

        public HallPlayerInfo player;

        public override string getCmd() {
            return "Hall:EnterHallWithPlayerInfo";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)58;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + HallSerializer.getHallPlayerInfoLength(player) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(hallId);
            HallSerializer.writeHallPlayerInfo(_block,player);
        }
    }
}

