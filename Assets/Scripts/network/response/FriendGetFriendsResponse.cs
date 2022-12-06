using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class FriendGetFriendsResponse : StatusResponse {
        public Success success{ set; get; }

        public List<FriendInfo> result;

        public FriendGetFriendsResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Friend:GetFriends";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<FriendInfo> result);

        public override void readBin(Block _block) {
            result = GateSerializer.readList_FriendInfo_(_block);
        }
    }
}

