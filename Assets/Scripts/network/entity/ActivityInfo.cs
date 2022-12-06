using System.Collections.Generic;

namespace network.entity
{
    public class ActivityInfo {
        public bool oper;

        public string url;

        public int mainRoomId;

        public bool isOper() {
            return this.oper;
        }

        public void setOper(bool oper) {
            this.oper = oper;
        }

        public string getUrl() {
            return this.url;
        }

        public void setUrl(string url) {
            this.url = url;
        }

        public int getMainRoomId() {
            return this.mainRoomId;
        }

        public void setMainRoomId(int mainRoomId) {
            this.mainRoomId = mainRoomId;
        }
    }
}

