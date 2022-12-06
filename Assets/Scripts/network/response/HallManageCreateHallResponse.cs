using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallManageCreateHallResponse : StatusResponse {
        public Success success{ set; get; }

        public Hall result;

        public HallManageCreateHallResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "HallManage:CreateHall";
        }

        public override byte getClsID() {
            return (byte)91;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(Hall result);

        public override void readBin(Block _block) {
            result = GateSerializer.readHall(_block);
        }
    }
}

