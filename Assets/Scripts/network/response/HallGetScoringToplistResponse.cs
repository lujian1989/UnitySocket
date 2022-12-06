using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetScoringToplistResponse : StatusResponse {
        public Success success{ set; get; }

        public List<ScoringInfo> result;

        public HallGetScoringToplistResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetScoringToplist";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)42;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<ScoringInfo> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_ScoringInfo_(_block);
        }
    }
}

