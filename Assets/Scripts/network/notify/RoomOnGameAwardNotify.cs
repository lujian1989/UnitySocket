using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnGameAwardNotify : Notify {
        public OnGameAwardNotify onGameAwardNotify{ set; get; }

        public List<AwardInfo> awards;

        public override string getCmd() {
            return "Room:OnGameAwardNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)49;
        }

        public delegate void OnGameAwardNotify(List<AwardInfo> awards);

        public override void readBin(Block _block) {
            awards=RoomSerializer.readList_AwardInfo_(_block);
        }

        public override void handleResult() {
            onGameAwardNotify?.Invoke( awards );
        }

        public override Response newInstance() {
            RoomOnGameAwardNotify ins=new RoomOnGameAwardNotify();
            ins.onGameAwardNotify = onGameAwardNotify;
            return ins;
        }
    }
}

