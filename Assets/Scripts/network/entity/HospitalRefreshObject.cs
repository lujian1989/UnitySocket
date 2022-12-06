using System.Collections.Generic;

namespace network.entity
{
    public class HospitalRefreshObject {
        public int levelNum;

        public List<HospitalMonsterObject> monsters;

        public int getLevelNum() {
            return this.levelNum;
        }

        public void setLevelNum(int levelNum) {
            this.levelNum = levelNum;
        }

        public List<HospitalMonsterObject> getMonsters() {
            return this.monsters;
        }

        public void setMonsters(List<HospitalMonsterObject> monsters) {
            this.monsters = monsters;
        }
    }
}

