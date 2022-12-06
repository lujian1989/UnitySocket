using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomSaveRoomStatusAndPropertiesRequest : Request {
        public int oriStatus;

        public int dstStatus;

        public List<PropertyValue> values;

        public override string getCmd() {
            return "Room:SaveRoomStatusAndProperties";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)17;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + Serializer.IntLength + RoomSerializer.getList_PropertyValue_Length(values) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(oriStatus);
            _block.writeInt(dstStatus);
            RoomSerializer.writeList_PropertyValue_(_block,values);
        }
    }
}

