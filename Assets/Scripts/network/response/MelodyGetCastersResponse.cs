using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class MelodyGetCastersResponse : StatusResponse {
        public Success success{ set; get; }

        public List<CasterInfo> result;

        public MelodyGetCastersResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Melody:GetCasters";
        }

        public override byte getClsID() {
            return (byte)93;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<CasterInfo> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_CasterInfo_(_block);
        }
    }
}

