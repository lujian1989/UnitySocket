using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class PveGetWeaponsResponse : StatusResponse {
        public Success success{ set; get; }

        public List<UserWeaponInfo> result;

        public PveGetWeaponsResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Pve:GetWeapons";
        }

        public override byte getClsID() {
            return (byte)94;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<UserWeaponInfo> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_UserWeaponInfo_(_block);
        }
    }
}

