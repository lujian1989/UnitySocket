using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallRechargeKTVRoomRequest : Request {
        public int roomId;

        public int coinType;

        public override string getCmd() {
            return "Hall:RechargeKTVRoom";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)16;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(roomId);
            _block.writeInt(coinType);
        }
    }
}

