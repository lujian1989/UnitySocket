using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.request
{
    public class AccountDeviceIdLoginRequest : Request {
        public int version;

        public string deviceId;

        public override string getCmd() {
            return "Account:DeviceIdLogin";
        }

        public override byte getClsID() {
            return (byte)86;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override int getBinLength() {
            return   Serializer.IntLength + GateSerializer.length(deviceId) ;
        }

        public override void writeBin(Block _block) {
            _block.writeInt(version);
            _block.writeString(deviceId);
        }
    }
}

