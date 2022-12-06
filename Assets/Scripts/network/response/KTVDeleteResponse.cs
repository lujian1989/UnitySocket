using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class KTVDeleteResponse : StatusResponse {
        public Success success{ set; get; }

        public KTVDeleteResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "KTV:Delete";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)7;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

