using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class FriendSearchRequest : Request {
        public string content;

        public override string getCmd() {
            return "Friend:Search";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   GateSerializer.length(content) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(content);
        }
    }
}

