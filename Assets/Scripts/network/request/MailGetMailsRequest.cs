using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class MailGetMailsRequest : Request {

        public override string getCmd() {
            return "Mail:GetMails";
        }

        public override byte getClsID() {
            return (byte)92;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override int getBinLength() {
            return 0;
        }

        public override void writeBin(Block _block) {
        }
    }
}

