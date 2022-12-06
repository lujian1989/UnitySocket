using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallModifyGuessGamePlayerNotify : Notify {
        public ModifyGuessGamePlayerNotify modifyGuessGamePlayerNotify{ set; get; }

        public int oper;

        public int userId;

        public int val;

        public override string getCmd() {
            return "Hall:ModifyGuessGamePlayerNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)25;
        }

        public delegate void ModifyGuessGamePlayerNotify(int oper, int userId, int val);

        public override void readBin(Block _block) {
            oper=_block.readInt();
            userId=_block.readInt();
            val=_block.readInt();
        }

        public override void handleResult() {
            modifyGuessGamePlayerNotify?.Invoke( oper ,userId ,val );
        }

        public override Response newInstance() {
            HallModifyGuessGamePlayerNotify ins=new HallModifyGuessGamePlayerNotify();
            ins.modifyGuessGamePlayerNotify = modifyGuessGamePlayerNotify;
            return ins;
        }
    }
}

