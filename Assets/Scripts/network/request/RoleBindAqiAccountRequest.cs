using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoleBindAqiAccountRequest : Request {
        public string aqiAccount;

        public override string getCmd() {
            return "Role:BindAqiAccount";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)26;
        }

        public override int getBinLength() {
            return   GateSerializer.length(aqiAccount) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(aqiAccount);
        }
    }
}

