using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallCheckEnterRoomResponse : StatusResponse {
        public Success success{ set; get; }

        public HallCheckEnterRoomResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:CheckEnterRoom";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)74;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

