using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnDismissRoomNotify : Notify {
        public OnDismissRoomNotify onDismissRoomNotify{ set; get; }

        public override string getCmd() {
            return "Room:OnDismissRoomNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)50;
        }

        public delegate void OnDismissRoomNotify();

        public override void readBin(Block _block) {
        }

        public override void handleResult() {
            onDismissRoomNotify?.Invoke();
        }

        public override Response newInstance() {
            RoomOnDismissRoomNotify ins=new RoomOnDismissRoomNotify();
            ins.onDismissRoomNotify = onDismissRoomNotify;
            return ins;
        }
    }
}

