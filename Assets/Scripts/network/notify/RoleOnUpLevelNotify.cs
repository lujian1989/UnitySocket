using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoleOnUpLevelNotify : Notify {
        public OnUpLevelNotify onUpLevelNotify{ set; get; }

        public LevelInfo levelInfo;

        public override string getCmd() {
            return "Role:OnUpLevelNotify";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)9;
        }

        public delegate void OnUpLevelNotify(LevelInfo levelInfo);

        public override void readBin(Block _block) {
            levelInfo=GateSerializer.readLevelInfo(_block);
        }

        public override void handleResult() {
            onUpLevelNotify?.Invoke( levelInfo );
        }

        public override Response newInstance() {
            RoleOnUpLevelNotify ins=new RoleOnUpLevelNotify();
            ins.onUpLevelNotify = onUpLevelNotify;
            return ins;
        }
    }
}

