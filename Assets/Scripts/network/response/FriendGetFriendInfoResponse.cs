using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class FriendGetFriendInfoResponse : StatusResponse {
        public Success success{ set; get; }

        public FriendInfo result;

        public FriendGetFriendInfoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Friend:GetFriendInfo";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)6;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(FriendInfo result);

        public override void readBin(Block _block) {
            result = GateSerializer.readFriendInfo(_block);
        }
    }
}

