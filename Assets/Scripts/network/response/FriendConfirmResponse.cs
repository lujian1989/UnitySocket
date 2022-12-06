using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class FriendConfirmResponse : StatusResponse {
        public Success success{ set; get; }

        public FriendConfirmResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Friend:Confirm";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)12;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

