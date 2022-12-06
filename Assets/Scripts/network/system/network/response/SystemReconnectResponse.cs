using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class SystemReconnectResponse : StatusResponse {
        public Success success{ set; get; }

        public ReconnectResult result;

        public SystemReconnectResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "System:Reconnect";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)111;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(ReconnectResult result);

        public override void readBin(Block _block) {
            result = CoreSerializer.readReconnectResult(_block);
        }
    }
}

