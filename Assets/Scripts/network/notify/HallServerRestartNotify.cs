using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallServerRestartNotify : Notify {
        public ServerRestartNotify serverRestartNotify{ set; get; }

        public int minute;

        public override string getCmd() {
            return "Hall:ServerRestartNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)14;
        }

        public delegate void ServerRestartNotify(int minute);

        public override void readBin(Block _block) {
            minute=_block.readInt();
        }

        public override void handleResult() {
            serverRestartNotify?.Invoke( minute );
        }

        public override Response newInstance() {
            HallServerRestartNotify ins=new HallServerRestartNotify();
            ins.serverRestartNotify = serverRestartNotify;
            return ins;
        }
    }
}

