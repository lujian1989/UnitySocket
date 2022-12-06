using System.Collections.Generic;

namespace network.entity
{
    public class AwardInfo {
        public int userId;

        public int rank;

        public int guluCoin;

        public string tip;

        public int score;

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

        public int getScore() {
            return this.score;
        }

        public void setScore(int score) {
            this.score = score;
        }
    }
}

