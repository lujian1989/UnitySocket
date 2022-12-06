using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class DriftBottleGetUnReplyDialogueResponse : StatusResponse {
        public Success success{ set; get; }

        public ReplyDialogueObj result;

        public DriftBottleGetUnReplyDialogueResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "DriftBottle:GetUnReplyDialogue";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)7;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(ReplyDialogueObj result);

        public override void readBin(Block _block) {
            result = HallSerializer.readReplyDialogueObj(_block);
        }
    }
}

