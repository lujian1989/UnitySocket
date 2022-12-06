using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class FriendNewApplyNotify : Notify {
        public NewApplyNotify newApplyNotify{ set; get; }

        public ApplyInfo applyInfo;

        public override string getCmd() {
            return "Friend:NewApplyNotify";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public delegate void NewApplyNotify(ApplyInfo applyInfo);

        public override void readBin(Block _block) {
            applyInfo=GateSerializer.readApplyInfo(_block);
        }

        public override void handleResult() {
            newApplyNotify?.Invoke( applyInfo );
        }

        public override Response newInstance() {
            FriendNewApplyNotify ins=new FriendNewApplyNotify();
            ins.newApplyNotify = newApplyNotify;
            return ins;
        }
    }
}

