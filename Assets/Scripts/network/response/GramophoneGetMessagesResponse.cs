using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class GramophoneGetMessagesResponse : StatusResponse {
        public Success success{ set; get; }

        public List<MessageObj> result;

        public GramophoneGetMessagesResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Gramophone:GetMessages";
        }

        public override byte getClsID() {
            return (byte)90;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<MessageObj> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_MessageObj_(_block);
        }
    }
}

