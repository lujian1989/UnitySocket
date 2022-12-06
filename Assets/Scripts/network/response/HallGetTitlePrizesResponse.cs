using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetTitlePrizesResponse : StatusResponse {
        public Success success{ set; get; }

        public List<TitlePrizeInfo> result;

        public HallGetTitlePrizesResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetTitlePrizes";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)37;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<TitlePrizeInfo> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_TitlePrizeInfo_(_block);
        }
    }
}

