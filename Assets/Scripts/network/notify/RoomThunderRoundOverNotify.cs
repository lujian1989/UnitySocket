using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomThunderRoundOverNotify : Notify {
        public ThunderRoundOverNotify thunderRoundOverNotify{ set; get; }

        public int winTeam;

        public int scoreT;

        public int scoreCT;

        public bool gameOver;

        public override string getCmd() {
            return "Room:ThunderRoundOverNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)5;
        }

        public delegate void ThunderRoundOverNotify(int winTeam, int scoreT, int scoreCT, bool gameOver);

        public override void readBin(Block _block) {
            winTeam=_block.readInt();
            scoreT=_block.readInt();
            scoreCT=_block.readInt();
            gameOver=_block.readBoolean();
        }

        public override void handleResult() {
            thunderRoundOverNotify?.Invoke( winTeam ,scoreT ,scoreCT ,gameOver );
        }

        public override Response newInstance() {
            RoomThunderRoundOverNotify ins=new RoomThunderRoundOverNotify();
            ins.thunderRoundOverNotify = thunderRoundOverNotify;
            return ins;
        }
    }
}

