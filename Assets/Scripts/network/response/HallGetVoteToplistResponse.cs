using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetVoteToplistResponse : StatusResponse {
        public Success success{ set; get; }

        public List<VoteInfo> result;

        public HallGetVoteToplistResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetVoteToplist";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)36;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<VoteInfo> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_VoteInfo_(_block);
        }
    }
}

