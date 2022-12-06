using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleGetOnlineGuluCoinResponse : StatusResponse {
        public Success success{ set; get; }

        public OnlineGuluCoinInfo result;

        public RoleGetOnlineGuluCoinResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:GetOnlineGuluCoin";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)17;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(OnlineGuluCoinInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readOnlineGuluCoinInfo(_block);
        }
    }
}

