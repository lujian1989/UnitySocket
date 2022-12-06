using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomChangePlayerStatusAndPropertiesRequest : Request {
        public int playerStatus;

        public List<PropertyValue> values;

        public override string getCmd() {
            return "Room:ChangePlayerStatusAndProperties";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)114;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + RoomSerializer.getList_PropertyValue_Length(values) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(playerStatus);
            RoomSerializer.writeList_PropertyValue_(_block,values);
        }
    }
}

