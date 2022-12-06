using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class StorageSetGlobalRequest : Request {
        public string key;

        public byte[] data;

        public override string getCmd() {
            return "Storage:SetGlobal";
        }

        public override byte getClsID() {
            return (byte)97;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override int getBinLength() {
            return   GateSerializer.length(key) + GateSerializer.length(data) ;
        }

        public override void writeBin(Block _block) {
            _block.writeString(key);
            _block.writeByteArray(data);
        }
    }
}

