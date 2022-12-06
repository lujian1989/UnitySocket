using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class FriendCancelBlackRequest : Request {
        public int userId;

        public override string getCmd() {
            return "Friend:CancelBlack";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)13;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(userId);
        }
    }
}

