using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomAiLevelNotify : Notify {
        public AiLevelNotify aiLevelNotify{ set; get; }

        public int level;

        public override string getCmd() {
            return "Room:AiLevelNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)128;
        }

        public delegate void AiLevelNotify(int level);

        public override void readBin(Block _block) {
            level=_block.readInt();
        }

        public override void handleResult() {
            aiLevelNotify?.Invoke( level );
        }

        public override Response newInstance() {
            RoomAiLevelNotify ins=new RoomAiLevelNotify();
            ins.aiLevelNotify = aiLevelNotify;
            return ins;
        }
    }
}

