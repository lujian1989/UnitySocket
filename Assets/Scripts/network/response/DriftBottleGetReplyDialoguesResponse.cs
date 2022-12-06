using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class DriftBottleGetReplyDialoguesResponse : StatusResponse {
        public Success success{ set; get; }

        public List<ReplyDialogueObj> result;

        public DriftBottleGetReplyDialoguesResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "DriftBottle:GetReplyDialogues";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)8;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<ReplyDialogueObj> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_ReplyDialogueObj_(_block);
        }
    }
}

