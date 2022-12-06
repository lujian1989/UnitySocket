using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomDeleteChorusMemberRequest : Request {
        public int userId;

        public override string getCmd() {
            return "Room:DeleteChorusMember";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)94;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(userId);
        }
    }
}

