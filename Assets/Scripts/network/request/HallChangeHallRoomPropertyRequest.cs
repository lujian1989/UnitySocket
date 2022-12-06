using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallChangeHallRoomPropertyRequest : Request {
        public PropertyValue value;

        public override string getCmd() {
            return "Hall:ChangeHallRoomProperty";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)79;
        }

        public override int getBinLength() {
            return   HallSerializer.getPropertyValueLength(value) ;
        }

        public override void writeBin(Block _block) {
            HallSerializer.writePropertyValue(_block,value);
        }
    }
}

