using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class SystemLeaveHallResponse : StatusResponse {
        public Success success{ set; get; }

        public SystemLeaveHallResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "System:LeaveHall";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)124;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

