using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class FriendBlackRequest : Request {
        public int userId;

        public override string getCmd() {
            return "Friend:Black";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)14;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(userId);
        }
    }
}

