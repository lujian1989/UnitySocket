using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoleSetCharacterNameRequest : Request {
        public string name;

        public override string getCmd() {
            return "Role:SetCharacterName";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)6;
        }

        public override int getBinLength() {
            return   GateSerializer.length(name) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(name);
        }
    }
}

