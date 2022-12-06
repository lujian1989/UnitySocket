using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleGetActivityRewardInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public ActivityRewardInfo result;

        public RoleGetActivityRewardInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:GetActivityRewardInfo";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)23;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(ActivityRewardInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readActivityRewardInfo(_block);
        }
    }
}

