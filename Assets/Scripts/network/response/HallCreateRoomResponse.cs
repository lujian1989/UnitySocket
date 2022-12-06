using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallCreateRoomResponse : StatusResponse {
        public Success success{ set; get; }

        public int result;

        public HallCreateRoomResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:CreateRoom";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)63;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(int result);

        public override void readBin(Block _block) {
            result = _block.readInt();
        }
    }
}

