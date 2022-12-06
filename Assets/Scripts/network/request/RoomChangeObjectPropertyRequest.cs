using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomChangeObjectPropertyRequest : Request {
        public int objId;

        public PropertyValue value;

        public override string getCmd() {
            return "Room:ChangeObjectProperty";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)121;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + RoomSerializer.getPropertyValueLength(value) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(objId);
            RoomSerializer.writePropertyValue(_block,value);
        }
    }
}

