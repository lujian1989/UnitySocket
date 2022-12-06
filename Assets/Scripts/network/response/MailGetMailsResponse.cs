using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class MailGetMailsResponse : StatusResponse {
        public Success success{ set; get; }

        public List<MailObj> result;

        public MailGetMailsResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Mail:GetMails";
        }

        public override byte getClsID() {
            return (byte)92;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<MailObj> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_MailObj_(_block);
        }
    }
}

