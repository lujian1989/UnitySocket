using System.Collections.Generic;

namespace network.entity
{
    public class ScoringInfo {
        public string songName;

        public string playerName;

        public int playerId;

        public int score;

        public int rank;

        public long scoreTime;

        public string getSongName() {
            return this.songName;
        }

        public void setSongName(string songName) {
            this.songName = songName;
        }

        public string getPlayerName() {
            return this.playerName;
        }

        public void setPlayerName(string playerName) {
            this.playerName = playerName;
        }

        public int getPlayerId() {
            return this.playerId;
        }

        public void setPlayerId(int playerId) {
            this.playerId = playerId;
        }

        public int getScore() {
            return this.score;
        }

        public void setScore(int score) {
            this.score = score;
        }

        public int getRank() {
            return this.rank;
        }

        public void setRank(int rank) {
            this.rank = rank;
        }

        public long getScoreTime() {
            return this.scoreTime;
        }

        public void setScoreTime(long scoreTime) {
            this.scoreTime = scoreTime;
        }
    }
}

