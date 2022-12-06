using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class KTVSongsResponse : StatusResponse {
        public Success success{ set; get; }

        public List<SongInfo> result;

        public KTVSongsResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "KTV:Songs";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<SongInfo> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_SongInfo_(_block);
        }
    }
}

