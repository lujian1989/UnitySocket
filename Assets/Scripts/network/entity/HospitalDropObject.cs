using System.Collections.Generic;

namespace network.entity
{
    public class HospitalDropObject {
        public int dropObjectId;

        public int monsterObjectId;

        public int itemId;

        public int point;

        public int getDropObjectId() {
            return this.dropObjectId;
        }

        public void setDropObjectId(int dropObjectId) {
            this.dropObjectId = dropObjectId;
        }

        public int getMonsterObjectId() {
            return this.monsterObjectId;
        }

        public void setMonsterObjectId(int monsterObjectId) {
            this.monsterObjectId = monsterObjectId;
        }

        public int getItemId() {
            return this.itemId;
        }

        public void setItemId(int itemId) {
            this.itemId = itemId;
        }

        public int getPoint() {
            return this.point;
        }

        public void setPoint(int point) {
            this.point = point;
        }
    }
}

