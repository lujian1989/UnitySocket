using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class MelodyGetPlayListResponse : StatusResponse {
        public Success success{ set; get; }

        public PlayListInfo result;

        public MelodyGetPlayListResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Melody:GetPlayList";
        }

        public override byte getClsID() {
            return (byte)93;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(PlayListInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readPlayListInfo(_block);
        }
    }
}

