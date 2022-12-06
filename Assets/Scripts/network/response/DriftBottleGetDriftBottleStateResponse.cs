using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class DriftBottleGetDriftBottleStateResponse : StatusResponse {
        public Success success{ set; get; }

        public UserBottleObj result;

        public DriftBottleGetDriftBottleStateResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "DriftBottle:GetDriftBottleState";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)10;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(UserBottleObj result);

        public override void readBin(Block _block) {
            result = HallSerializer.readUserBottleObj(_block);
        }
    }
}

