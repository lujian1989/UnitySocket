using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class PveAddGuluCoinRequest : Request {
        public int num;

        public override string getCmd() {
            return "Pve:AddGuluCoin";
        }

        public override byte getClsID() {
            return (byte)94;
        }

        public override byte getMethodID() {
            return (byte)10;
        }

        public override int getBinLength() {
            return   Serializer.IntLength ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(num);
        }
    }
}

