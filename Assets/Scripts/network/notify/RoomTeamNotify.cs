using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomTeamNotify : Notify {
        public TeamNotify teamNotify{ set; get; }

        public TeamInfo info;

        public override string getCmd() {
            return "Room:TeamNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)6;
        }

        public delegate void TeamNotify(TeamInfo info);

        public override void readBin(Block _block) {
            info=RoomSerializer.readTeamInfo(_block);
        }

        public override void handleResult() {
            teamNotify?.Invoke( info );
        }

        public override Response newInstance() {
            RoomTeamNotify ins=new RoomTeamNotify();
            ins.teamNotify = teamNotify;
            return ins;
        }
    }
}

