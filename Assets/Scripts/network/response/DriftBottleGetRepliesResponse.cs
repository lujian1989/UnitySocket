using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class DriftBottleGetRepliesResponse : StatusResponse {
        public Success success{ set; get; }

        public List<ReplyObj> result;

        public DriftBottleGetRepliesResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "DriftBottle:GetReplies";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)9;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<ReplyObj> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_ReplyObj_(_block);
        }
    }
}

