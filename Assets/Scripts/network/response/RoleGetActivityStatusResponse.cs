using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleGetActivityStatusResponse : StatusResponse {
        public Success success{ set; get; }

        public ActivityStatus result;

        public RoleGetActivityStatusResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:GetActivityStatus";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)22;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(ActivityStatus result);

        public override void readBin(Block _block) {
            result = GateSerializer.readActivityStatus(_block);
        }
    }
}

