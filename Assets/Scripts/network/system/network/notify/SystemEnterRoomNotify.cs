using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class SystemEnterRoomNotify : Notify {
        public EnterRoomNotify enterRoomNotify{ set; get; }

        public int roomId;

        public override string getCmd() {
            return "System:EnterRoomNotify";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)121;
        }

        public delegate void EnterRoomNotify(int roomId);

        public override void readBin(Block _block) {
            roomId=_block.readInt();
        }

        public override void handleResult() {
            enterRoomNotify?.Invoke( roomId );
        }

        public override Response newInstance() {
            SystemEnterRoomNotify ins=new SystemEnterRoomNotify();
            ins.enterRoomNotify = enterRoomNotify;
            return ins;
        }
    }
}

