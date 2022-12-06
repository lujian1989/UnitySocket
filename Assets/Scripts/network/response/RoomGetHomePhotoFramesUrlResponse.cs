using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomGetHomePhotoFramesUrlResponse : StatusResponse {
        public Success success{ set; get; }

        public List<HomePhotoFramesUrl> result;

        public RoomGetHomePhotoFramesUrlResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:GetHomePhotoFramesUrl";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)83;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<HomePhotoFramesUrl> result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readList_HomePhotoFramesUrl_(_block);
        }
    }
}

