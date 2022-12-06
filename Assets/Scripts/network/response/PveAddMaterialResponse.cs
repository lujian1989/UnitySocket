using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class PveAddMaterialResponse : StatusResponse {
        public Success success{ set; get; }

        public PveAddMaterialResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Pve:AddMaterial";
        }

        public override byte getClsID() {
            return (byte)94;
        }

        public override byte getMethodID() {
            return (byte)9;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

