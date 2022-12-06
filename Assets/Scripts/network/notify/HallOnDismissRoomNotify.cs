using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallOnDismissRoomNotify : Notify {
        public OnDismissRoomNotify onDismissRoomNotify{ set; get; }

        public int hallId;

        public int roomId;

        public override string getCmd() {
            return "Hall:OnDismissRoomNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)23;
        }

        public delegate void OnDismissRoomNotify(int hallId, int roomId);

        public override void readBin(Block _block) {
            hallId=_block.readInt();
            roomId=_block.readInt();
        }

        public override void handleResult() {
            onDismissRoomNotify?.Invoke( hallId ,roomId );
        }

        public override Response newInstance() {
            HallOnDismissRoomNotify ins=new HallOnDismissRoomNotify();
            ins.onDismissRoomNotify = onDismissRoomNotify;
            return ins;
        }
    }
}

