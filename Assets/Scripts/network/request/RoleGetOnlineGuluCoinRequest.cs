using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoleGetOnlineGuluCoinRequest : Request {

        public override string getCmd() {
            return "Role:GetOnlineGuluCoin";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)17;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

