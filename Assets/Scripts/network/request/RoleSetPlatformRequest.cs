using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoleSetPlatformRequest : Request {
        public string platform;

        public override string getCmd() {
            return "Role:SetPlatform";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override int getBinLength() {
            return   GateSerializer.length(platform) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(platform);
        }
    }
}

