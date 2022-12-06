using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class FriendConfirmRequest : Request {
        public int userId;

        public bool isAgree;

        public override string getCmd() {
            return "Friend:Confirm";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)12;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.BooleanLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(userId);
            _block.writeBoolean(isAgree);
        }
    }
}

