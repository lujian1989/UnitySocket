using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleGetActivityRewardConfigResponse : StatusResponse {
        public Success success{ set; get; }

        public List<ActivityRewards> result;

        public RoleGetActivityRewardConfigResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:GetActivityRewardConfig";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)24;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<ActivityRewards> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_ActivityRewards_(_block);
        }
    }
}

