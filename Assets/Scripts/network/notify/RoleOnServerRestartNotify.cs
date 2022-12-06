using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoleOnServerRestartNotify : Notify {
        public OnServerRestartNotify onServerRestartNotify{ set; get; }

        public int minute;

        public override string getCmd() {
            return "Role:OnServerRestartNotify";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)10;
        }

        public delegate void OnServerRestartNotify(int minute);

        public override void readBin(Block _block) {
            minute=_block.readInt();
        }

        public override void handleResult() {
            onServerRestartNotify?.Invoke( minute );
        }

        public override Response newInstance() {
            RoleOnServerRestartNotify ins=new RoleOnServerRestartNotify();
            ins.onServerRestartNotify = onServerRestartNotify;
            return ins;
        }
    }
}

