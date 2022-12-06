using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomAddChorusMemberResponse : StatusResponse {
        public Success success{ set; get; }

        public RoomAddChorusMemberResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:AddChorusMember";
        }

        public override byte getClsID() {
            return (byte)113;
        }

        public override byte getMethodID() {
            return (byte)132;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

