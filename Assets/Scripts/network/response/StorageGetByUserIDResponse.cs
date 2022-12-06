using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class StorageGetByUserIDResponse : StatusResponse {
        public Success success{ set; get; }

        public byte[] result;

        public StorageGetByUserIDResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Storage:GetByUserID";
        }

        public override byte getClsID() {
            return (byte)97;
        }

        public override byte getMethodID() {
            return (byte)4;
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

