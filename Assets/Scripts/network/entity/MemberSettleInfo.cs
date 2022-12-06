using System.Collections.Generic;

namespace network.entity
{
    public class MemberSettleInfo {
        public int userId;

        public int rank;

        public int killNum;

        public int deadNum;

        public int guluCoin;

        public string tip;

        public int getUserId() {
            return this.userId;
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public int getRank() {
            return this.rank;
        }

        public void setRank(int rank) {
            this.rank = rank;
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

        public int getGuluCoin() {
            return this.guluCoin;
        }

        public void setGuluCoin(int guluCoin) {
            this.guluCoin = guluCoin;
        }

        public string getTip() {
            return this.tip;
        }

        public void setTip(string tip) {
            this.tip = tip;
        }
    }
}

