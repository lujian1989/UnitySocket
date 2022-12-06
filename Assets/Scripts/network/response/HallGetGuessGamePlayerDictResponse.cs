using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetGuessGamePlayerDictResponse : StatusResponse {
        public Success success{ set; get; }

        public List<GuessGamePlayerInfos> result;

        public HallGetGuessGamePlayerDictResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetGuessGamePlayerDict";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)51;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<GuessGamePlayerInfos> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_GuessGamePlayerInfos_(_block);
        }
    }
}

