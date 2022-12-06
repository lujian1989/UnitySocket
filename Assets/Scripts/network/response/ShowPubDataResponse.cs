using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class ShowPubDataResponse : StatusResponse {
        public Success success{ set; get; }

        public ShowPubDataResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Show:PubData";
        }

        public override byte getClsID() {
            return (byte)237;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

