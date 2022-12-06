using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallTitleNotify : Notify {
        public TitleNotify titleNotify{ set; get; }

        public int type;

        public int userId;

        public int titleId;

        public override string getCmd() {
            return "Hall:TitleNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)2;
        }

        public delegate void TitleNotify(int type, int userId, int titleId);

        public override void readBin(Block _block) {
            type=_block.readInt();
            userId=_block.readInt();
            titleId=_block.readInt();
        }

        public override void handleResult() {
            titleNotify?.Invoke( type ,userId ,titleId );
        }

        public override Response newInstance() {
            HallTitleNotify ins=new HallTitleNotify();
            ins.titleNotify = titleNotify;
            return ins;
        }
    }
}

