using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetHomePageInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public HomePageInfo result;

        public HallGetHomePageInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetHomePageInfo";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)50;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(HomePageInfo result);

        public override void readBin(Block _block) {
            result = HallSerializer.readHomePageInfo(_block);
        }
    }
}

