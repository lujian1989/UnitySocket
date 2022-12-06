using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomGetFreeSubRoomResponse : StatusResponse {
        public Success success{ set; get; }

        public SubERoom result;

        public RoomGetFreeSubRoomResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:GetFreeSubRoom";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)84;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(SubERoom result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readSubERoom(_block);
        }
    }
}

