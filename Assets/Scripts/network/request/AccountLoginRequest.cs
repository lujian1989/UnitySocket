using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class AccountLoginRequest : Request {
        public int version;

        public string phone;

        public string password;

        public override string getCmd() {
            return "Account:Login";
        }

        public override byte getClsID() {
            return (byte)86;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + GateSerializer.length(phone) + GateSerializer.length(password) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(version);
            _block.writeString(phone);
            _block.writeString(password);
        }
    }
}

