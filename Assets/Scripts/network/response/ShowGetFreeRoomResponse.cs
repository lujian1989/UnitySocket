using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class ShowGetFreeRoomResponse : StatusResponse {
        public Success success{ set; get; }

        public HallRoomInfo result;

        public ShowGetFreeRoomResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Show:GetFreeRoom";
        }

        public override byte getClsID() {
            return (byte)237;
        }

        public override byte getMethodID() {
            return (byte)5;
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

