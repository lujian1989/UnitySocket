using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class KTVOperateNotify : Notify {
        public OperateNotify operateNotify{ set; get; }

        public int type;

        public List<SongInfo> song;

        public override string getCmd() {
            return "KTV:OperateNotify";
        }

        public override byte getClsID() {
            return (byte)234;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public delegate void OperateNotify(int type, List<SongInfo> song);

        public override void readBin(Block _block) {
            type=_block.readInt();
            song=HallSerializer.readList_SongInfo_(_block);
        }

        public override void handleResult() {
            operateNotify?.Invoke( type ,song );
        }

        public override Response newInstance() {
            KTVOperateNotify ins=new KTVOperateNotify();
            ins.operateNotify = operateNotify;
            return ins;
        }
    }
}

