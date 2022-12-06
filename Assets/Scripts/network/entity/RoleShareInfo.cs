using System.Collections.Generic;

namespace network.entity
{
    public class RoleShareInfo {
        public int userId;

        public string name;

        public int characteristic;

        public int level;

        public int guest;

        public int homelandCode;

        public int gender;

        public int titleId;

        public short permission;

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

        public int getLevel() {
            return this.level;
        }

        public void setLevel(int level) {
            this.level = level;
        }

        public int getGuest() {
            return this.guest;
        }

        public void setGuest(int guest) {
            this.guest = guest;
        }

        public int getHomelandCode() {
            return this.homelandCode;
        }

        public void setHomelandCode(int homelandCode) {
            this.homelandCode = homelandCode;
        }

        public int getGender() {
            return this.gender;
        }

        public void setGender(int gender) {
            this.gender = gender;
        }

        public int getTitleId() {
            return this.titleId;
        }

        public void setTitleId(int titleId) {
            this.titleId = titleId;
        }

        public short getPermission() {
            return this.permission;
        }

        public void setPermission(short permission) {
            this.permission = permission;
        }

        public string getHead() {
            return this.head;
        }

        public void setHead(string head) {
            this.head = head;
        }
    }
}

