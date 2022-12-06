using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomGetRoomDetailResponse : StatusResponse {
        public Success success{ set; get; }

        public HallRoomDetail result;

        public RoomGetRoomDetailResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:GetRoomDetail";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)82;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(HallRoomDetail result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readHallRoomDetail(_block);
        }
    }
}

