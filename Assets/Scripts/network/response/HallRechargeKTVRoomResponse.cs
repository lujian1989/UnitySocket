using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallRechargeKTVRoomResponse : StatusResponse {
        public Success success{ set; get; }

        public long result;

        public HallRechargeKTVRoomResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:RechargeKTVRoom";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)16;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(long result);

        public override void readBin(Block _block) {
            result = _block.readLong();
        }
    }
}

