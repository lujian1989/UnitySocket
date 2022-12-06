using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetActivityStatusResponse : StatusResponse {
        public Success success{ set; get; }

        public ActivityInfo result;

        public HallGetActivityStatusResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetActivityStatus";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)56;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(ActivityInfo result);

        public override void readBin(Block _block) {
            result = HallSerializer.readActivityInfo(_block);
        }
    }
}

