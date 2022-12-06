using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class SystemPingpongResponse : StatusResponse {
        public Success success{ set; get; }

        public SystemPingpongResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "System:Pingpong";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)112;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

