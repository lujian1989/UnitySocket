using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomGetSpecialGuestsResponse : StatusResponse {
        public Success success{ set; get; }

        public List<SpecialGuestInfo> result;

        public RoomGetSpecialGuestsResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:GetSpecialGuests";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)79;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<SpecialGuestInfo> result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readList_SpecialGuestInfo_(_block);
        }
    }
}

