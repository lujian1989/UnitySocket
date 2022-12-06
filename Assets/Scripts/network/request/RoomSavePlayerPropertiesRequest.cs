using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomSavePlayerPropertiesRequest : Request {
        public List<PropertyValue> values;

        public override string getCmd() {
            return "Room:SavePlayerProperties";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)25;
        }

        public override int getBinLength() {
            return   RoomSerializer.getList_PropertyValue_Length(values) ;
        }

        public override void writeBin(Block _block) {
            RoomSerializer.writeList_PropertyValue_(_block,values);
        }
    }
}

