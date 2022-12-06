using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomChangePlayerStatusAndPropertyRequest : Request {
        public int playerStatus;

        public PropertyValue value;

        public override string getCmd() {
            return "Room:ChangePlayerStatusAndProperty";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)113;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + RoomSerializer.getPropertyValueLength(value) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(playerStatus);
            RoomSerializer.writePropertyValue(_block,value);
        }
    }
}

