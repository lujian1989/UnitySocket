using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class DriftBottleGetDialoguesResponse : StatusResponse {
        public Success success{ set; get; }

        public List<DialogueObj> result;

        public DriftBottleGetDialoguesResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "DriftBottle:GetDialogues";
        }

        public override byte getClsID() {
            return (byte)231;
        }

        public override byte getMethodID() {
            return (byte)11;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<DialogueObj> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_DialogueObj_(_block);
        }
    }
}

