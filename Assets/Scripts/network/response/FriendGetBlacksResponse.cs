using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class FriendGetBlacksResponse : StatusResponse {
        public Success success{ set; get; }

        public List<BlackInfo> result;

        public FriendGetBlacksResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Friend:GetBlacks";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)7;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<BlackInfo> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_BlackInfo_(_block);
        }
    }
}

