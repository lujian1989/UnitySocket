using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomSaveObjectPropertiesRequest : Request {
        public int objId;

        public List<PropertyValue> values;

        public override string getCmd() {
            return "Room:SaveObjectProperties";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)30;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + RoomSerializer.getList_PropertyValue_Length(values) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(objId);
            RoomSerializer.writeList_PropertyValue_(_block,values);
        }
    }
}

