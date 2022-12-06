using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class ShowGetPubDatasResponse : StatusResponse {
        public Success success{ set; get; }

        public List<BroadcastData> result;

        public ShowGetPubDatasResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Show:GetPubDatas";
        }

        public override byte getClsID() {
            return (byte)237;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<BroadcastData> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_BroadcastData_(_block);
        }
    }
}

