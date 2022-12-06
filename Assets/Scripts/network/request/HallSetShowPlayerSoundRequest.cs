using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallSetShowPlayerSoundRequest : Request {
        public PlayerSoundInfo val;

        public override string getCmd() {
            return "Hall:SetShowPlayerSound";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)12;
        }

        public override int getBinLength() {
            return   HallSerializer.getPlayerSoundInfoLength(val) ;
        }

        public override void writeBin(Block _block) {
            HallSerializer.writePlayerSoundInfo(_block,val);
        }
    }
}

