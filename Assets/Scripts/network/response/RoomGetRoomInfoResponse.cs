using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomGetRoomInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public ERoom result;

        public RoomGetRoomInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:GetRoomInfo";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)81;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(ERoom result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readERoom(_block);
        }
    }
}

