using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class DriftBottleDragDriftBottleResponse : StatusResponse {
        public Success success{ set; get; }

        public DriftBottleObj result;

        public DriftBottleDragDriftBottleResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "DriftBottle:DragDriftBottle";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)12;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(DriftBottleObj result);

        public override void readBin(Block _block) {
            result = HallSerializer.readDriftBottleObj(_block);
        }
    }
}

