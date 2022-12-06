using System.Collections.Generic;

namespace network.entity
{
    public class Hall {
        public int hallId;

        public string token;

        public int getHallId() {
            return this.hallId;
        }

        public void setHallId(int hallId) {
            this.hallId = hallId;
        }

        public string getToken() {
            return this.token;
        }

        public void setToken(string token) {
            this.token = token;
        }
    }
}

