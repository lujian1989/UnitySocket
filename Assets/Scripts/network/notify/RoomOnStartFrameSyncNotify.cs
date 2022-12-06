using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnStartFrameSyncNotify : Notify {
        public OnStartFrameSyncNotify onStartFrameSyncNotify{ set; get; }

        public override string getCmd() {
            return "Room:OnStartFrameSyncNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)38;
        }

        public delegate void OnStartFrameSyncNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            onStartFrameSyncNotify?.Invoke();
        }

        public override Response newInstance() {
            RoomOnStartFrameSyncNotify ins=new RoomOnStartFrameSyncNotify();
            ins.onStartFrameSyncNotify = onStartFrameSyncNotify;
            return ins;
        }
    }
}

