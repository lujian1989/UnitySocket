using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoleGetRoomInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public HallAndRoom result;

        public RoleGetRoomInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Role:GetRoomInfo";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)14;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(HallAndRoom result);

        public override void readBin(Block _block) {
            result = GateSerializer.readHallAndRoom(_block);
        }
    }
}

