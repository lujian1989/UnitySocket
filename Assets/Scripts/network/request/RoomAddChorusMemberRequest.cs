using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomAddChorusMemberRequest : Request {
        public ChorusMember memberInfo;

        public override string getCmd() {
            return "Room:AddChorusMember";
        }

        public override byte getClsID() {
            return (byte)113;
        }

        public override byte getMethodID() {
            return (byte)132;
        }

        public override int getBinLength() {
            return   RoomSerializer.getChorusMemberLength(memberInfo) ;
        }

        public override void writeBin(Block _block) {
            RoomSerializer.writeChorusMember(_block,memberInfo);
        }
    }
}

