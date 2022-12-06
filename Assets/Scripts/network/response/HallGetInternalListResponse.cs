using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetInternalListResponse : StatusResponse {
        public Success success{ set; get; }

        public List<AnswerInfo> result;

        public HallGetInternalListResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetInternalList";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)49;
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

