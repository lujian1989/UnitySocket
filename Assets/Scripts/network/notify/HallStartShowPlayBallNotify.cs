using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallStartShowPlayBallNotify : Notify {
        public StartShowPlayBallNotify startShowPlayBallNotify{ set; get; }

        public int randNum;

        public override string getCmd() {
            return "Hall:StartShowPlayBallNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)7;
        }

        public delegate void StartShowPlayBallNotify(int randNum);

        public override void readBin(Block _block) {
            randNum=_block.readInt();
        }

        public override void handleResult() {
            startShowPlayBallNotify?.Invoke( randNum );
        }

        public override Response newInstance() {
            HallStartShowPlayBallNotify ins=new HallStartShowPlayBallNotify();
            ins.startShowPlayBallNotify = startShowPlayBallNotify;
            return ins;
        }
    }
}

