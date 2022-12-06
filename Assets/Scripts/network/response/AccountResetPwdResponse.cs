using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class AccountResetPwdResponse : StatusResponse {
        public Success success{ set; get; }

        public AccountResetPwdResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Account:ResetPwd";
        }

        public override byte getClsID() {
            return (byte)86;
        }

        public override byte getMethodID() {
            return (byte)1;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

