using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class StorageGetGlobalResponse : StatusResponse {
        public Success success{ set; get; }

        public byte[] result;

        public StorageGetGlobalResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Storage:GetGlobal";
        }

        public override byte getClsID() {
            return (byte)97;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(byte[] result);

        public override void readBin(Block _block) {
            result = _block.readByteArray();
        }
    }
}

