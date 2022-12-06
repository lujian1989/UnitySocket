using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class StorageGetByUserIDRequest : Request {
        public int userID;

        public string key;

        public override string getCmd() {
            return "Storage:GetByUserID";
        }

        public override byte getClsID() {
            return (byte)97;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + GateSerializer.length(key) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(userID);
            _block.writeString(key);
        }
    }
}

