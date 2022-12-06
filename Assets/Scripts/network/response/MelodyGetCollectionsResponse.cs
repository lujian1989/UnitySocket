using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class MelodyGetCollectionsResponse : StatusResponse {
        public Success success{ set; get; }

        public List<CollectionInfo> result;

        public MelodyGetCollectionsResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Melody:GetCollections";
        }

        public override byte getClsID() {
            return (byte)93;
        }

        public override byte getMethodID() {
            return (byte)4;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<CollectionInfo> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_CollectionInfo_(_block);
        }
    }
}

