using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HomelandGetHomelandInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public HLInfo result;

        public HomelandGetHomelandInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Homeland:GetHomelandInfo";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)6;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(HLInfo result);

        public override void readBin(Block _block) {
            result = HallSerializer.readHLInfo(_block);
        }
    }
}

