using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class SystemLeaveRoomNotify : Notify {
        public LeaveRoomNotify leaveRoomNotify{ set; get; }

        public override string getCmd() {
            return "System:LeaveRoomNotify";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)104;
        }

        public delegate void LeaveRoomNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            leaveRoomNotify?.Invoke();
        }

        public override Response newInstance() {
            SystemLeaveRoomNotify ins=new SystemLeaveRoomNotify();
            ins.leaveRoomNotify = leaveRoomNotify;
            return ins;
        }
    }
}

