using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallCheckKTVFreeActivityOpenResponse : StatusResponse {
        public Success success{ set; get; }

        public long result;

        public HallCheckKTVFreeActivityOpenResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:CheckKTVFreeActivityOpen";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)72;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(long result);

        public override void readBin(Block _block) {
            result = _block.readLong();
        }
    }
}

