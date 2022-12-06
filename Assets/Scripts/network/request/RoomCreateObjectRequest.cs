using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomCreateObjectRequest : Request {
        public string name;

        public int oriStatus;

        public List<PropertyValue> values;

        public override string getCmd() {
            return "Room:CreateObject";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)104;
        }

        public override int getBinLength() {
            return   RoomSerializer.length(name) + Serializer.IntLength + RoomSerializer.getList_PropertyValue_Length(values) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(name);
            _block.writeInt(oriStatus);
            RoomSerializer.writeList_PropertyValue_(_block,values);
        }
    }
}

