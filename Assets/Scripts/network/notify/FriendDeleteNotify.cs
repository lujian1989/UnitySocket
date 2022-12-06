using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class FriendDeleteNotify : Notify {
        public DeleteNotify deleteNotify{ set; get; }

        public int delUserId;

        public override string getCmd() {
            return "Friend:DeleteNotify";
        }

        public override byte getClsID() {
            return (byte)89;
        }

        public override byte getMethodID() {
            return (byte)10;
        }

        public delegate void DeleteNotify(int delUserId);

        public override void readBin(Block _block) {
            delUserId=_block.readInt();
        }

        public override void handleResult() {
            deleteNotify?.Invoke( delUserId );
        }

        public override Response newInstance() {
            FriendDeleteNotify ins=new FriendDeleteNotify();
            ins.deleteNotify = deleteNotify;
            return ins;
        }
    }
}

