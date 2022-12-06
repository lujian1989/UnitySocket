using System.Collections.Generic;

namespace network.entity
{
    public class ApplyInfo {
        public int userId;

        public string name;

        public int characteristic;

        public bool online;

        public string head;

        public int getUserId() {
            return this.userId;
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public string getName() {
            return this.name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public int getCharacteristic() {
            return this.characteristic;
        }

        public void setCharacteristic(int characteristic) {
            this.characteristic = characteristic;
        }

        public bool isOnline() {
            return this.online;
        }

        public void setOnline(bool online) {
            this.online = online;
        }

        public string getHead() {
            return this.head;
        }

        public void setHead(string head) {
            this.head = head;
        }
    }
}

