using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallStartShowNotify : Notify {
        public StartShowNotify startShowNotify{ set; get; }

        public int light;

        public int sound;

        public int randNum;

        public override string getCmd() {
            return "Hall:StartShowNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)8;
        }

        public delegate void StartShowNotify(int light, int sound, int randNum);

        public override void readBin(Block _block) {
            light=_block.readInt();
            sound=_block.readInt();
            randNum=_block.readInt();
        }

        public override void handleResult() {
            startShowNotify?.Invoke( light ,sound ,randNum );
        }

        public override Response newInstance() {
            HallStartShowNotify ins=new HallStartShowNotify();
            ins.startShowNotify = startShowNotify;
            return ins;
        }
    }
}

