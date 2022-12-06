using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallStartAnswerNotify : Notify {
        public StartAnswerNotify startAnswerNotify{ set; get; }

        public long beginTime;

        public override string getCmd() {
            return "Hall:StartAnswerNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)9;
        }

        public delegate void StartAnswerNotify(long beginTime);

        public override void readBin(Block _block) {
            beginTime=_block.readLong();
        }

        public override void handleResult() {
            startAnswerNotify?.Invoke( beginTime );
        }

        public override Response newInstance() {
            HallStartAnswerNotify ins=new HallStartAnswerNotify();
            ins.startAnswerNotify = startAnswerNotify;
            return ins;
        }
    }
}

