using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class HallChangeHallRoomStatusAndPropertyRequest : Request {
        public int oriStatus;

        public int dstStatus;

        public PropertyValue value;

        public override string getCmd() {
            return "Hall:ChangeHallRoomStatusAndProperty";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)77;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + HallSerializer.getPropertyValueLength(value) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(oriStatus);
            _block.writeInt(dstStatus);
            HallSerializer.writePropertyValue(_block,value);
        }
    }
}

