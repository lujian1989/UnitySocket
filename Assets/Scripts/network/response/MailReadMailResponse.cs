using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class MailReadMailResponse : StatusResponse {
        public Success success{ set; get; }

        public MailReadMailResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Mail:ReadMail";
        }

        public override byte getClsID() {
            return (byte)92;
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

