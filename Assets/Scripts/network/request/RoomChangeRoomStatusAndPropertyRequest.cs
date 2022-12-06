using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomChangeRoomStatusAndPropertyRequest : Request {
        public int oriStatus;

        public int dstStatus;

        public PropertyValue value;

        public override string getCmd() {
            return "Room:ChangeRoomStatusAndProperty";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)108;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + RoomSerializer.getPropertyValueLength(value) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(oriStatus);
            _block.writeInt(dstStatus);
            RoomSerializer.writePropertyValue(_block,value);
        }
    }
}

