using System.Collections.Generic;

namespace network.entity
{
    public class ThunderMemberInfo {
        public int userId;

        public int team;

        public int killNum;

        public int deadNum;

        public bool deaded;

        public int getUserId() {
            return this.userId;
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public int getTeam() {
            return this.team;
        }

        public void setTeam(int team) {
            this.team = team;
        }

        public int getKillNum() {
            return this.killNum;
        }

        public void setKillNum(int killNum) {
            this.killNum = killNum;
        }

        public int getDeadNum() {
            return this.deadNum;
        }

        public void setDeadNum(int deadNum) {
            this.deadNum = deadNum;
        }

        public bool isDeaded() {
            return this.deaded;
        }

        public void setDeaded(bool deaded) {
            this.deaded = deaded;
        }
    }
}

