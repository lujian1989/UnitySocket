using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomGetThunderRoomInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public ThunderRoomInfo result;

        public RoomGetThunderRoomInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:GetThunderRoomInfo";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)78;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(ThunderRoomInfo result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readThunderRoomInfo(_block);
        }
    }
}

