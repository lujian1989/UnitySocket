using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallManageCreateHallRequest : Request {
        public string hallName;

        public string hallType;

        public override string getCmd() {
            return "HallManage:CreateHall";
        }

        public override byte getClsID() {
            return (byte)91;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override int getBinLength() {
            return   GateSerializer.length(hallName) + GateSerializer.length(hallType) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(hallName);
            _block.writeString(hallType);
        }
    }
}

