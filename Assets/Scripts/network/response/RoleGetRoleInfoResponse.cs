using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleGetRoleInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public RoleInfo result;

        public RoleGetRoleInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:GetRoleInfo";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)16;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(RoleInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readRoleInfo(_block);
        }
    }
}

