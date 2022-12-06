using System.Collections.Generic;

namespace network.entity
{
    public class HomelandLike {
        public int id;

        public string nickName;

        public int headPic;

        public long likeTime;

        public string head;

        public int getId() {
            return this.id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public string getNickName() {
            return this.nickName;
        }

        public void setNickName(string nickName) {
            this.nickName = nickName;
        }

        public int getHeadPic() {
            return this.headPic;
        }

        public void setHeadPic(int headPic) {
            this.headPic = headPic;
        }

        public long getLikeTime() {
            return this.likeTime;
        }

        public void setLikeTime(long likeTime) {
            this.likeTime = likeTime;
        }

        public string getHead() {
            return this.head;
        }

        public void setHead(string head) {
            this.head = head;
        }
    }
}

