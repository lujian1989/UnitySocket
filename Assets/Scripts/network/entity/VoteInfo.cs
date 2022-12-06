using System.Collections.Generic;

namespace network.entity
{
    public class VoteInfo {
        public string songName;

        public string playerName;

        public int playerId;

        public int num;

        public string head;

        public int gender;

        public long voteTime;

        public int characteristic;

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

        public int getNum() {
            return this.num;
        }

        public void setNum(int num) {
            this.num = num;
        }

        public string getHead() {
            return this.head;
        }

        public void setHead(string head) {
            this.head = head;
        }

        public int getGender() {
            return this.gender;
        }

        public void setGender(int gender) {
            this.gender = gender;
        }

        public long getVoteTime() {
            return this.voteTime;
        }

        public void setVoteTime(long voteTime) {
            this.voteTime = voteTime;
        }

        public int getCharacteristic() {
            return this.characteristic;
        }

        public void setCharacteristic(int characteristic) {
            this.characteristic = characteristic;
        }
    }
}

