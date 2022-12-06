using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class SystemUserOnlineNotify : Notify {
        public UserOnlineNotify userOnlineNotify{ set; get; }

        public int userId;

        public override string getCmd() {
            return "System:UserOnlineNotify";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)120;
        }

        public delegate void UserOnlineNotify(int userId);

        public override void readBin(Block _block) {
            userId=_block.readInt();
        }

        public override void handleResult() {
            userOnlineNotify?.Invoke( userId );
        }

        public override Response newInstance() {
            SystemUserOnlineNotify ins=new SystemUserOnlineNotify();
            ins.userOnlineNotify = userOnlineNotify;
            return ins;
        }
    }
}

