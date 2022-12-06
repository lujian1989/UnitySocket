using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnLeaveRoomNotify : Notify {
        public OnLeaveRoomNotify onLeaveRoomNotify{ set; get; }

        public int leavePlayerId;

        public override string getCmd() {
            return "Room:OnLeaveRoomNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)47;
        }

        public delegate void OnLeaveRoomNotify(int leavePlayerId);

        public override void readBin(Block _block) {
            leavePlayerId=_block.readInt();
        }

        public override void handleResult() {
            onLeaveRoomNotify?.Invoke( leavePlayerId );
        }

        public override Response newInstance() {
            RoomOnLeaveRoomNotify ins=new RoomOnLeaveRoomNotify();
            ins.onLeaveRoomNotify = onLeaveRoomNotify;
            return ins;
        }
    }
}

