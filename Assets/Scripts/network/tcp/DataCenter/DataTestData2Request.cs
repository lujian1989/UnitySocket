using network.entity;
using UnityEngine;

namespace network.response
{
    public class DataTestData2Request: Request
    {
        public string str = "helloSever!";
        public override string getCmd() {
            return "Data:DataTestData2Request";
        }

        public override byte getClsID() {
            return (byte)100;
        }

        public override byte getMethodID() {
            return (byte)100;
        }

        public override int getBinLength() {
            return Serializer.length(str);
        }

        public override void writeBin(Block _block) {
            _block.writeString(str);
        }
    }
}