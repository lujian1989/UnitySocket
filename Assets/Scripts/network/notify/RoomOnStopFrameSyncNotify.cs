using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnStopFrameSyncNotify : Notify {
        public OnStopFrameSyncNotify onStopFrameSyncNotify{ set; get; }

        public override string getCmd() {
            return "Room:OnStopFrameSyncNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)37;
        }

        public delegate void OnStopFrameSyncNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            onStopFrameSyncNotify?.Invoke();
        }

        public override Response newInstance() {
            RoomOnStopFrameSyncNotify ins=new RoomOnStopFrameSyncNotify();
            ins.onStopFrameSyncNotify = onStopFrameSyncNotify;
            return ins;
        }
    }
}

