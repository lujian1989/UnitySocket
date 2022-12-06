using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class FriendNewFriendNotify : Notify {
        public NewFriendNotify newFriendNotify{ set; get; }

        public FriendInfo friendInfo;

        public override string getCmd() {
            return "Friend:NewFriendNotify";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public delegate void NewFriendNotify(FriendInfo friendInfo);

        public override void readBin(Block _block) {
            friendInfo=GateSerializer.readFriendInfo(_block);
        }

        public override void handleResult() {
            newFriendNotify?.Invoke( friendInfo );
        }

        public override Response newInstance() {
            FriendNewFriendNotify ins=new FriendNewFriendNotify();
            ins.newFriendNotify = newFriendNotify;
            return ins;
        }
    }
}

