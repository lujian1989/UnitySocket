using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class KTVSendToOthersResponse : StatusResponse {
        public Success success{ set; get; }

        public KTVSendToOthersResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "KTV:SendToOthers";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

