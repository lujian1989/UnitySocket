using System.Collections.Generic;

namespace network.entity
{
    public class AnswerInfo {
        public string name;

        public string head;

        public int playerId;

        public int gender;

        public long answerTime;

        public int characteristic;

        public string getName() {
            return this.name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public string getHead() {
            return this.head;
        }

        public void setHead(string head) {
            this.head = head;
        }

        public int getPlayerId() {
            return this.playerId;
        }

        public void setPlayerId(int playerId) {
            this.playerId = playerId;
        }

        public int getGender() {
            return this.gender;
        }

        public void setGender(int gender) {
            this.gender = gender;
        }

        public long getAnswerTime() {
            return this.answerTime;
        }

        public void setAnswerTime(long answerTime) {
            this.answerTime = answerTime;
        }

        public int getCharacteristic() {
            return this.characteristic;
        }

        public void setCharacteristic(int characteristic) {
            this.characteristic = characteristic;
        }
    }
}

