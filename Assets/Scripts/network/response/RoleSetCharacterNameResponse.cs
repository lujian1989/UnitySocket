using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleSetCharacterNameResponse : StatusResponse {
        public Success success{ set; get; }

        public RoleSetCharacterNameResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:SetCharacterName";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)6;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

