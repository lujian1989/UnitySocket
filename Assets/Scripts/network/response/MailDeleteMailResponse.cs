using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class MailDeleteMailResponse : StatusResponse {
        public Success success{ set; get; }

        public MailDeleteMailResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Mail:DeleteMail";
        }

        public override byte getClsID() {
            return (byte)92;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

