using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomAiIdChangedNotify : Notify {
        public AiIdChangedNotify aiIdChangedNotify{ set; get; }

        public int aiCmdId;

        public int ServerTime;

        public override string getCmd() {
            return "Room:AiIdChangedNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)129;
        }

        public delegate void AiIdChangedNotify(int aiCmdId, int ServerTime);

        public override void readBin(Block _block) {
            aiCmdId=_block.readInt();
            ServerTime=_block.readInt();
        }

        public override void handleResult() {
            aiIdChangedNotify?.Invoke( aiCmdId ,ServerTime );
        }

        public override Response newInstance() {
            RoomAiIdChangedNotify ins=new RoomAiIdChangedNotify();
            ins.aiIdChangedNotify = aiIdChangedNotify;
            return ins;
        }
    }
}

