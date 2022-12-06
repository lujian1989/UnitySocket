using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnJoinRoomNotify : Notify {
        public OnJoinRoomNotify onJoinRoomNotify{ set; get; }

        public ERoomPlayer joinPlayer;

        public override string getCmd() {
            return "Room:OnJoinRoomNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)48;
        }

        public delegate void OnJoinRoomNotify(ERoomPlayer joinPlayer);

        public override void readBin(Block _block) {
            joinPlayer=RoomSerializer.readERoomPlayer(_block);
        }

        public override void handleResult() {
            onJoinRoomNotify?.Invoke( joinPlayer );
        }

        public override Response newInstance() {
            RoomOnJoinRoomNotify ins=new RoomOnJoinRoomNotify();
            ins.onJoinRoomNotify = onJoinRoomNotify;
            return ins;
        }
    }
}

