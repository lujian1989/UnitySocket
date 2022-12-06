using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetAnswerToplistResponse : StatusResponse {
        public Success success{ set; get; }

        public List<AnswerInfo> result;

        public HallGetAnswerToplistResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetAnswerToplist";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)55;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<AnswerInfo> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_AnswerInfo_(_block);
        }
    }
}

