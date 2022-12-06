using System.Collections.Generic;

namespace network.entity
{
    public class TeamInfo {
        public int hallId;

        public int roomId;

        public int curRound;

        public int[] teamT;

        public int[] teamCT;

        public int getHallId() {
            return this.hallId;
        }

        public void setHallId(int hallId) {
            this.hallId = hallId;
        }

        public int getRoomId() {
            return this.roomId;
        }

        public void setRoomId(int roomId) {
            this.roomId = roomId;
        }

        public int getCurRound() {
            return this.curRound;
        }

        public void setCurRound(int curRound) {
            this.curRound = curRound;
        }

        public int[] getTeamT() {
            return this.teamT;
        }

        public void setTeamT(int[] teamT) {
            this.teamT = teamT;
        }

        public int[] getTeamCT() {
            return this.teamCT;
        }

        public void setTeamCT(int[] teamCT) {
            this.teamCT = teamCT;
        }
    }
}

