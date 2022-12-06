using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomGetUserPhotoResponse : StatusResponse {
        public Success success{ set; get; }

        public List<UserPhoto> result;

        public RoomGetUserPhotoResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:GetUserPhoto";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)76;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<UserPhoto> result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readList_UserPhoto_(_block);
        }
    }
}

