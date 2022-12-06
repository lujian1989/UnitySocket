using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomSaveRoomStatusResponse : StatusResponse {
        public Success success{ set; get; }

        public RoomSaveRoomStatusResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:SaveRoomStatus";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)18;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

