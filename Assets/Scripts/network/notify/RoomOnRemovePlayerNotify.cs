using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnRemovePlayerNotify : Notify {
        public OnRemovePlayerNotify onRemovePlayerNotify{ set; get; }

        public int removePlayerId;

        public override string getCmd() {
            return "Room:OnRemovePlayerNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)41;
        }

        public delegate void OnRemovePlayerNotify(int removePlayerId);

        public override void readBin(Block _block) {
            removePlayerId=_block.readInt();
        }

        public override void handleResult() {
            onRemovePlayerNotify?.Invoke( removePlayerId );
        }

        public override Response newInstance() {
            RoomOnRemovePlayerNotify ins=new RoomOnRemovePlayerNotify();
            ins.onRemovePlayerNotify = onRemovePlayerNotify;
            return ins;
        }
    }
}

