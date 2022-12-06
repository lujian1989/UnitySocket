using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class PveGetUpWeaponCostResponse : StatusResponse {
        public Success success{ set; get; }

        public UpWeaponCostInfo result;

        public PveGetUpWeaponCostResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Pve:GetUpWeaponCost";
        }

        public override byte getClsID() {
            return (byte)94;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(UpWeaponCostInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readUpWeaponCostInfo(_block);
        }
    }
}

