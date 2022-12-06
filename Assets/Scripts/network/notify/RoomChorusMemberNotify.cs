using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomChorusMemberNotify : Notify {
        public ChorusMemberNotify chorusMemberNotify{ set; get; }

        public int oper;

        public List<ChorusMember> memberInfos;

        public override string getCmd() {
            return "Room:ChorusMemberNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)107;
        }

        public delegate void ChorusMemberNotify(int oper, List<ChorusMember> memberInfos);

        public override void readBin(Block _block) {
            oper=_block.readInt();
            memberInfos=RoomSerializer.readList_ChorusMember_(_block);
        }

        public override void handleResult() {
            chorusMemberNotify?.Invoke( oper ,memberInfos );
        }

        public override Response newInstance() {
            RoomChorusMemberNotify ins=new RoomChorusMemberNotify();
            ins.chorusMemberNotify = chorusMemberNotify;
            return ins;
        }
    }
}

