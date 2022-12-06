using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleGetKTVIsOpenResponse : StatusResponse {
        public Success success{ set; get; }

        public bool result;

        public RoleGetKTVIsOpenResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:GetKTVIsOpen";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)19;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(bool result);

        public override void readBin(Block _block) {
            result = _block.readBoolean();
        }
    }
}

