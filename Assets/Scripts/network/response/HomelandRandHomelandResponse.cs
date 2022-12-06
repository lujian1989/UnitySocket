using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HomelandRandHomelandResponse : StatusResponse {
        public Success success{ set; get; }

        public RandHomeland result;

        public HomelandRandHomelandResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Homeland:RandHomeland";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(RandHomeland result);

        public override void readBin(Block _block) {
            result = HallSerializer.readRandHomeland(_block);
        }
    }
}

