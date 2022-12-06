using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class AccountRegistGuestRequest : Request {
        public int version;

        public override string getCmd() {
            return "Accunt:ReogistGuest";
        }

        public override byte getClsID() {
            return (byte)100;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(version);
        }
    }
}

