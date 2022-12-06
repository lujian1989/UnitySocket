using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOpenActivity1Notify : Notify {
        public OpenActivity1Notify openActivity1Notify{ set; get; }

        public bool oper;

        public string url;

        public int mainRoomId;

        public override string getCmd() {
            return "Room:OpenActivity1Notify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)35;
        }

        public delegate void OpenActivity1Notify(bool oper, string url, int mainRoomId);

        public override void readBin(Block _block) {
            oper=_block.readBoolean();
            url=_block.readString();
            mainRoomId=_block.readInt();
        }

        public override void handleResult() {
            openActivity1Notify?.Invoke( oper ,url ,mainRoomId );
        }

        public override Response newInstance() {
            RoomOpenActivity1Notify ins=new RoomOpenActivity1Notify();
            ins.openActivity1Notify = openActivity1Notify;
            return ins;
        }
    }
}

