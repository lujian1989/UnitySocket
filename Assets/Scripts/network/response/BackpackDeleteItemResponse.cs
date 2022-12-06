using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class BackpackDeleteItemResponse : StatusResponse {
        public Success success{ set; get; }

        public BackpackDeleteItemResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Backpack:DeleteItem";
        }

        public override byte getClsID() {
            return (byte)88;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

