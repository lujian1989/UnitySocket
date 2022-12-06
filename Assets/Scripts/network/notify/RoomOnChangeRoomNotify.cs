using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnChangeRoomNotify : Notify {
        public OnChangeRoomNotify onChangeRoomNotify{ set; get; }

        public ERoom room;

        public override string getCmd() {
            return "Room:OnChangeRoomNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)53;
        }

        public delegate void OnChangeRoomNotify(ERoom room);

        public override void readBin(Block _block) {
            room=RoomSerializer.readERoom(_block);
        }

        public override void handleResult() {
            onChangeRoomNotify?.Invoke( room );
        }

        public override Response newInstance() {
            RoomOnChangeRoomNotify ins=new RoomOnChangeRoomNotify();
            ins.onChangeRoomNotify = onChangeRoomNotify;
            return ins;
        }
    }
}

