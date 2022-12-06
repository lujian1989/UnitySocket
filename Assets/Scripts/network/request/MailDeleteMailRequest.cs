using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class MailDeleteMailRequest : Request {
        public int id;

        public override string getCmd() {
            return "Mail:DeleteMail";
        }

        public override byte getClsID() {
            return (byte)92;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(id);
        }
    }
}

