using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoleGetActivityRewardsRequest : Request {
        public int type;

        public int day;

        public override string getCmd() {
            return "Role:GetActivityRewards";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)27;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(type);
            _block.writeInt(day);
        }
    }
}

