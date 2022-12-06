using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class ServiceSubscribeResponse : StatusResponse {
        public Success success{ set; get; }

        public ServiceSubscribeResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Service:Subscribe";
        }

        public override byte getClsID() {
            return (byte)235;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override void doSuccess() {
            success?.Invoke();
        }

        public delegate void Success();

        public override void readBin(Block _block) {
        }
    }
}

