using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class ShopGetShopListResponse : StatusResponse {
        public Success success{ set; get; }

        public ShopsInfo result;

        public ShopGetShopListResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Shop:GetShopList";
        }

        public override byte getClsID() {
            return (byte)96;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(ShopsInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readShopsInfo(_block);
        }
    }
}

