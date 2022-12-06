using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallOnNewRoomNotify : Notify {
        public OnNewRoomNotify onNewRoomNotify{ set; get; }

        public int hallId;

        public HallRoomInfo roomInfo;

        public override string getCmd() {
            return "Hall:OnNewRoomNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)22;
        }

        public delegate void OnNewRoomNotify(int hallId, HallRoomInfo roomInfo);

        public override void readBin(Block _block) {
            hallId=_block.readInt();
            roomInfo=HallSerializer.readHallRoomInfo(_block);
        }

        public override void handleResult() {
            onNewRoomNotify?.Invoke( hallId ,roomInfo );
        }

        public override Response newInstance() {
            HallOnNewRoomNotify ins=new HallOnNewRoomNotify();
            ins.onNewRoomNotify = onNewRoomNotify;
            return ins;
        }
    }
}

