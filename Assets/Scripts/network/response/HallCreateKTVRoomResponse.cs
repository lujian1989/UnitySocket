using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallCreateKTVRoomResponse : StatusResponse {
        public Success success{ set; get; }

        public HallRoomInfo result;

        public HallCreateKTVRoomResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:CreateKTVRoom";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)64;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(HallRoomInfo result);

        public override void readBin(Block _block) {
            result = HallSerializer.readHallRoomInfo(_block);
        }
    }
}

