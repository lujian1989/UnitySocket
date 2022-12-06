using System.Collections.Generic;

namespace network.entity
{
    public class UserWeaponInfo {
        public int id;

        public int level;

        public int getId() {
            return this.id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getLevel() {
            return this.level;
        }

        public void setLevel(int level) {
            this.level = level;
        }
    }
}

