using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class ShopBuyItemResponse : StatusResponse {
        public Success success{ set; get; }

        public BuyResultInfo result;

        public ShopBuyItemResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Shop:BuyItem";
        }

        public override byte getClsID() {
            return (byte)96;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(BuyResultInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readBuyResultInfo(_block);
        }
    }
}

