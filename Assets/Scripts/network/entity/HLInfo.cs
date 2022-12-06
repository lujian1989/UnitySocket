using System.Collections.Generic;

namespace network.entity
{
    public class HLInfo {
        public int userId;

        public string nickName;

        public string bgPicture;

        public string signature;

        public string video;

        public string audio;

        public List<HomelandLike> likes;

        public int likesNum;

        public bool likeCurHomeland;

        public int getUserId() {
            return this.userId;
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public string getNickName() {
            return this.nickName;
        }

        public void setNickName(string nickName) {
            this.nickName = nickName;
        }

        public string getBgPicture() {
            return this.bgPicture;
        }

        public void setBgPicture(string bgPicture) {
            this.bgPicture = bgPicture;
        }

        public string getSignature() {
            return this.signature;
        }

        public void setSignature(string signature) {
            this.signature = signature;
        }

        public string getVideo() {
            return this.video;
        }

        public void setVideo(string video) {
            this.video = video;
        }

        public string getAudio() {
            return this.audio;
        }

        public void setAudio(string audio) {
            this.audio = audio;
        }

        public List<HomelandLike> getLikes() {
            return this.likes;
        }

        public void setLikes(List<HomelandLike> likes) {
            this.likes = likes;
        }

        public int getLikesNum() {
            return this.likesNum;
        }

        public void setLikesNum(int likesNum) {
            this.likesNum = likesNum;
        }

        public bool isLikeCurHomeland() {
            return this.likeCurHomeland;
        }

        public void setLikeCurHomeland(bool likeCurHomeland) {
            this.likeCurHomeland = likeCurHomeland;
        }
    }
}

