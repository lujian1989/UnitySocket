using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class RoomCreateObjectsRequest : Request {
        public List<ERoomObject> objs;

        public override string getCmd() {
            return "Room:CreateObjects";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)103;
        }

        public override int getBinLength() {
            return   RoomSerializer.getList_ERoomObject_Length(objs) ;
        }

        public override void writeBin(Block _block) {
            RoomSerializer.writeList_ERoomObject_(_block,objs);
        }
    }
}

