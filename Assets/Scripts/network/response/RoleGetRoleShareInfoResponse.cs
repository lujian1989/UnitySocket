using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleGetRoleShareInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public RoleShareInfo result;

        public RoleGetRoleShareInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:GetRoleShareInfo";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)15;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(RoleShareInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readRoleShareInfo(_block);
        }
    }
}

