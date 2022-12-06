using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HomelandLeaveHomelandResponse : StatusResponse {
        public Success success{ set; get; }

        public HomelandLeaveHomelandResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Homeland:LeaveHomeland";
        }

        public override byte getClsID() {
            return (byte)233;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

