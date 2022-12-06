using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomDeleteChorusMemberResponse : StatusResponse {
        public Success success{ set; get; }

        public RoomDeleteChorusMemberResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:DeleteChorusMember";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)94;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

