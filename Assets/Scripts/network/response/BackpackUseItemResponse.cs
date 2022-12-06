using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class BackpackUseItemResponse : StatusResponse {
        public Success success{ set; get; }

        public BackpackObj result;

        public BackpackUseItemResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Backpack:UseItem";
        }

        public override byte getClsID() {
            return (byte)88;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(BackpackObj result);

        public override void readBin(Block _block) {
            result = GateSerializer.readBackpackObj(_block);
        }
    }
}

