using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallAddToInternalListResponse : StatusResponse {
        public Success success{ set; get; }

        public AnswerInfo result;

        public HallAddToInternalListResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:AddToInternalList";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)85;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(AnswerInfo result);

        public override void readBin(Block _block) {
            result = HallSerializer.readAnswerInfo(_block);
        }
    }
}

