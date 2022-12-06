using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class PveAddMaterialRequest : Request {
        public int num;

        public override string getCmd() {
            return "Pve:AddMaterial";
        }

        public override byte getClsID() {
            return (byte)94;
        }

        public override byte getMethodID() {
            return (byte)9;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(num);
        }
    }
}

