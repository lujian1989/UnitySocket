using System.Collections.Generic;

namespace network.entity
{
    public class LevelInfo {
        public int userId;

        public int level;

        public int exp;

        public int upExp;

        public int getUserId() {
            return this.userId;
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public int getLevel() {
            return this.level;
        }

        public void setLevel(int level) {
            this.level = level;
        }

        public int getExp() {
            return this.exp;
        }

        public void setExp(int exp) {
            this.exp = exp;
        }

        public int getUpExp() {
            return this.upExp;
        }

        public void setUpExp(int upExp) {
            this.upExp = upExp;
        }
    }
}

