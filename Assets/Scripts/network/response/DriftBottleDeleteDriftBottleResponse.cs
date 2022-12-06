using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class DriftBottleDeleteDriftBottleResponse : StatusResponse {
        public Success success{ set; get; }

        public DriftBottleDeleteDriftBottleResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "DriftBottle:DeleteDriftBottle";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)13;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

