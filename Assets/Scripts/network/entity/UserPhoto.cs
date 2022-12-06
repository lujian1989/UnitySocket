using System.Collections.Generic;

namespace network.entity
{
    public class UserPhoto {
        public int screen_type;

        public int type;

        public string path;

        public int getScreen_type() {
            return this.screen_type;
        }

        public void setScreen_type(int screen_type) {
            this.screen_type = screen_type;
        }

        public int getType() {
            return this.type;
        }

        public void setType(int type) {
            this.type = type;
        }

        public string getPath() {
            return this.path;
        }

        public void setPath(string path) {
            this.path = path;
        }
    }
}

