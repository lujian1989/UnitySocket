using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.response
{
    public class RoomRequestFrameResponse : StatusResponse {
        public Success success{ set; get; }

        public List<Frame> result;

        public RoomRequestFrameResponse(Success susccess, Fail fail) {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd() {
            return "Room:RequestFrame";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)31;
        }

        public override void doSuccess() {
            success?.Invoke(result);
        }

        public delegate void Success(List<Frame> result);

        public override void readBin(Block _block) {
            result = RoomSerializer.readList_Frame_(_block);
        }
    }
}

