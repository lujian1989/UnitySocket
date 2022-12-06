using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomGetChorusMembersResponse : StatusResponse {
        public Success success{ set; get; }

        public List<ChorusMember> result;

        public RoomGetChorusMembersResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:GetChorusMembers";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)85;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<ChorusMember> result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readList_ChorusMember_(_block);
        }
    }
}

