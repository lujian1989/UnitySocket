using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class MailNewMailNotify : Notify {
        public NewMailNotify newMailNotify{ set; get; }

        public MailObj mail;

        public override string getCmd() {
            return "Mail:NewMailNotify";
        }

        public override byte getClsID() {
            return (byte)92;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public delegate void NewMailNotify(MailObj mail);

        public override void readBin(Block _block) {
            mail=GateSerializer.readMailObj(_block);
        }

        public override void handleResult() {
            newMailNotify?.Invoke( mail );
        }

        public override Response newInstance() {
            MailNewMailNotify ins=new MailNewMailNotify();
            ins.newMailNotify = newMailNotify;
            return ins;
        }
    }
}

