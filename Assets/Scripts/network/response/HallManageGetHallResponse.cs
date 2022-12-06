using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallManageGetHallResponse : StatusResponse {
        public Success success{ set; get; }

        public Hall result;

        public HallManageGetHallResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "HallManage:GetHall";
        }

        public override byte getClsID() {
            return (byte)91;
        }

        public override byte getMethodID() {
            return (byte)1;
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

