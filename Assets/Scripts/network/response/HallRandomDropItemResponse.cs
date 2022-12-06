using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallRandomDropItemResponse : StatusResponse {
        public Success success{ set; get; }

        public DropItemInfo result;

        public HallRandomDropItemResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:RandomDropItem";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)17;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(DropItemInfo result);

        public override void readBin(Block _block) {
            result = HallSerializer.readDropItemInfo(_block);
        }
    }
}

