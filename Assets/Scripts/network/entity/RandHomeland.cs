using System.Collections.Generic;

namespace network.entity
{
    public class RandHomeland {
        public int userId;

        public int homelandCode;

        public int getUserId() {
            return this.userId;
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public int getHomelandCode() {
            return this.homelandCode;
        }

        public void setHomelandCode(int homelandCode) {
            this.homelandCode = homelandCode;
        }
    }
}

