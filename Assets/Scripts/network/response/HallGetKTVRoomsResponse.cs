using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class HallGetKTVRoomsResponse : StatusResponse {
        public Success success{ set; get; }

        public List<HallRoomInfo> result;

        public HallGetKTVRoomsResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Hall:GetKTVRooms";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)48;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<HallRoomInfo> result);

        public override void readBin(Block _block) {
            result = HallSerializer.readList_HallRoomInfo_(_block);
        }
    }
}

