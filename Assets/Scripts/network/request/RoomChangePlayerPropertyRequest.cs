using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomChangePlayerPropertyRequest : Request {
        public PropertyValue value;

        public override string getCmd() {
            return "Room:ChangePlayerProperty";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)116;
        }

        public override int getBinLength() {
            return   RoomSerializer.getPropertyValueLength(value) ;
        }

        public override void writeBin(Block _block) {
            RoomSerializer.writePropertyValue(_block,value);
        }
    }
}

