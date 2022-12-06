using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleGetLevelInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public LevelInfo result;

        public RoleGetLevelInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:GetLevelInfo";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)18;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(LevelInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readLevelInfo(_block);
        }
    }
}

