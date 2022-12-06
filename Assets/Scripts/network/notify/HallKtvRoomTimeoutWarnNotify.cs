using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallKtvRoomTimeoutWarnNotify : Notify {
        public KtvRoomTimeoutWarnNotify ktvRoomTimeoutWarnNotify{ set; get; }

        public long leftTime;

        public int timeSize;

        public int roomSize;

        public override string getCmd() {
            return "Hall:KtvRoomTimeoutWarnNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)32;
        }

        public delegate void KtvRoomTimeoutWarnNotify(long leftTime, int timeSize, int roomSize);

        public override void readBin(Block _block) {
            leftTime=_block.readLong();
            timeSize=_block.readInt();
            roomSize=_block.readInt();
        }

        public override void handleResult() {
            ktvRoomTimeoutWarnNotify?.Invoke( leftTime ,timeSize ,roomSize );
        }

        public override Response newInstance() {
            HallKtvRoomTimeoutWarnNotify ins=new HallKtvRoomTimeoutWarnNotify();
            ins.ktvRoomTimeoutWarnNotify = ktvRoomTimeoutWarnNotify;
            return ins;
        }
    }
}

