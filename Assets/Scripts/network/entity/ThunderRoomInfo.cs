using System.Collections.Generic;

namespace network.entity
{
    public class ThunderRoomInfo {
        public int hallId;

        public int roomId;

        public int curRound;

        public int scoreT;

        public int scoreCT;

        public int remainTime;

        public List<ThunderMemberInfo> memberInfos;

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

        public int getScoreT() {
            return this.scoreT;
        }

        public void setScoreT(int scoreT) {
            this.scoreT = scoreT;
        }

        public int getScoreCT() {
            return this.scoreCT;
        }

        public void setScoreCT(int scoreCT) {
            this.scoreCT = scoreCT;
        }

        public int getRemainTime() {
            return this.remainTime;
        }

        public void setRemainTime(int remainTime) {
            this.remainTime = remainTime;
        }

        public List<ThunderMemberInfo> getMemberInfos() {
            return this.memberInfos;
        }

        public void setMemberInfos(List<ThunderMemberInfo> memberInfos) {
            this.memberInfos = memberInfos;
        }
    }
}

