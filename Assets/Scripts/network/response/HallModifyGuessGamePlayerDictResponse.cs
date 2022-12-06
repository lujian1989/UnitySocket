using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallModifyGuessGamePlayerDictResponse : StatusResponse {
        public Success success{ set; get; }

        public HallModifyGuessGamePlayerDictResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:ModifyGuessGamePlayerDict";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)26;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

