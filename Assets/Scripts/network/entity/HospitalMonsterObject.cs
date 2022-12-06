using System.Collections.Generic;

namespace network.entity
{
    public class HospitalMonsterObject {
        public int monsterObjectId;

        public int monsterId;

        public int point;

        public int hp;

        public int getMonsterObjectId() {
            return this.monsterObjectId;
        }

        public void setMonsterObjectId(int monsterObjectId) {
            this.monsterObjectId = monsterObjectId;
        }

        public int getMonsterId() {
            return this.monsterId;
        }

        public void setMonsterId(int monsterId) {
            this.monsterId = monsterId;
        }

        public int getPoint() {
            return this.point;
        }

        public void setPoint(int point) {
            this.point = point;
        }

        public int getHp() {
            return this.hp;
        }

        public void setHp(int hp) {
            this.hp = hp;
        }
    }
}

