using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class FriendFriendInfoNotify : Notify {
        public FriendInfoNotify friendInfoNotify{ set; get; }

        public FriendInfo friendInfo;

        public override string getCmd() {
            return "Friend:FriendInfoNotify";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)9;
        }

        public delegate void FriendInfoNotify(FriendInfo friendInfo);

        public override void readBin(Block _block) {
            friendInfo=GateSerializer.readFriendInfo(_block);
        }

        public override void handleResult() {
            friendInfoNotify?.Invoke( friendInfo );
        }

        public override Response newInstance() {
            FriendFriendInfoNotify ins=new FriendFriendInfoNotify();
            ins.friendInfoNotify = friendInfoNotify;
            return ins;
        }
    }
}

