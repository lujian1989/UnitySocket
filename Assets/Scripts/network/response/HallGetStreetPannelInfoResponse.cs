using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetStreetPannelInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public StreetPannelInfo result;

        public HallGetStreetPannelInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetStreetPannelInfo";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)38;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(StreetPannelInfo result);

        public override void readBin(Block _block) {
            result = HallSerializer.readStreetPannelInfo(_block);
        }
    }
}

