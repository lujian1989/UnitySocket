using System.Collections.Generic;

namespace network.entity
{
    public class UserBottleObj {
        public int state;

        public int sendNum;

        public int replyNum;

        public int getState() {
            return this.state;
        }

        public void setState(int state) {
            this.state = state;
        }

        public int getSendNum() {
            return this.sendNum;
        }

        public void setSendNum(int sendNum) {
            this.sendNum = sendNum;
        }

        public int getReplyNum() {
            return this.replyNum;
        }

        public void setReplyNum(int replyNum) {
            this.replyNum = replyNum;
        }
    }
}

