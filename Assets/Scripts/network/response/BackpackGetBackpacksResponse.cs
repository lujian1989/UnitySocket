using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class BackpackGetBackpacksResponse : StatusResponse {
        public Success success{ set; get; }

        public List<BackpackObj> result;

        public BackpackGetBackpacksResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Backpack:GetBackpacks";
        }

        public override byte getClsID() {
            return (byte)88;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<BackpackObj> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_BackpackObj_(_block);
        }
    }
}

