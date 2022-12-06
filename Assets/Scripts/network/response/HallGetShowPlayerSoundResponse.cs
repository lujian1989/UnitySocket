using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetShowPlayerSoundResponse : StatusResponse {
        public Success success{ set; get; }

        public PlayerSoundInfo result;

        public HallGetShowPlayerSoundResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetShowPlayerSound";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)40;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(PlayerSoundInfo result);

        public override void readBin(Block _block) {
            result = HallSerializer.readPlayerSoundInfo(_block);
        }
    }
}

