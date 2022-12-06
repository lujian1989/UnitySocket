using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomDeepEternityOverResponse : StatusResponse {
        public Success success{ set; get; }

        public DeepOverInfo result;

        public RoomDeepEternityOverResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:DeepEternityOver";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)95;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(DeepOverInfo result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readDeepOverInfo(_block);
        }
    }
}

