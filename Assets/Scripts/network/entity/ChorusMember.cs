using System.Collections.Generic;

namespace network.entity
{
    public class ChorusMember {
        public string name;

        public int playerId;

        public string head;

        public int gender;

        public long addTime;

        public int characteristic;

        public string getName() {
            return this.name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public int getPlayerId() {
            return this.playerId;
        }

        public void setPlayerId(int playerId) {
            this.playerId = playerId;
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

        public long getAddTime() {
            return this.addTime;
        }

        public void setAddTime(long addTime) {
            this.addTime = addTime;
        }

        public int getCharacteristic() {
            return this.characteristic;
        }

        public void setCharacteristic(int characteristic) {
            this.characteristic = characteristic;
        }
    }
}

