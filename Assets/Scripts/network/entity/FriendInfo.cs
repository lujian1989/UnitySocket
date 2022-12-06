using System.Collections.Generic;

namespace network.entity
{
    public class FriendInfo {
        public int userId;

        public string name;

        public int characteristic;

        public bool online;

        public int hallId;

        public int roomId;

        public int mapId;

        public int homelandCode;

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

        public int getMapId() {
            return this.mapId;
        }

        public void setMapId(int mapId) {
            this.mapId = mapId;
        }

        public int getHomelandCode() {
            return this.homelandCode;
        }

        public void setHomelandCode(int homelandCode) {
            this.homelandCode = homelandCode;
        }

        public string getHead() {
            return this.head;
        }

        public void setHead(string head) {
            this.head = head;
        }
    }
}

