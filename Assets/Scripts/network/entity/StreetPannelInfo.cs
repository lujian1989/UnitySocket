using System.Collections.Generic;

namespace network.entity
{
    public class StreetPannelInfo {
        public int type;

        public string url;

        public int getType() {
            return this.type;
        }

        public void setType(int type) {
            this.type = type;
        }

        public string getUrl() {
            return this.url;
        }

        public void setUrl(string url) {
            this.url = url;
        }
    }
}

