using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class AccountResetPwdRequest : Request {
        public int version;

        public string phone;

        public string password;

        public string identityCode;

        public override string getCmd() {
            return "Account:ResetPwd";
        }

        public override byte getClsID() {
            return (byte)86;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + GateSerializer.length(phone) + GateSerializer.length(password) + GateSerializer.length(identityCode) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(version);
            _block.writeString(phone);
            _block.writeString(password);
            _block.writeString(identityCode);
        }
    }
}

