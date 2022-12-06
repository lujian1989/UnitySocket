using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class PveGetGiftsResponse : StatusResponse {
        public Success success{ set; get; }

        public int[] result;

        public PveGetGiftsResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Pve:GetGifts";
        }

        public override byte getClsID() {
            return (byte)94;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(int[] result);

        public override void readBin(Block _block) {
            result = _block.readIntArray();
        }
    }
}

