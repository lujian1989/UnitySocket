using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class FriendGetApplysResponse : StatusResponse {
        public Success success{ set; get; }

        public List<ApplyInfo> result;

        public FriendGetApplysResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Friend:GetApplys";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)8;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<ApplyInfo> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_ApplyInfo_(_block);
        }
    }
}

