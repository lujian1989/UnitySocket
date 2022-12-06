using System.Collections.Generic;

namespace network.entity
{
    public class AudioInfo {
        public int audioId;

        public string audioKey;

        public string audioName;

        public int audioDuration;

        public long uploadTime;

        public bool isCollected;

        public bool isLiked;

        public int playCount;

        public int likeCount;

        public int getAudioId() {
            return this.audioId;
        }

        public void setAudioId(int audioId) {
            this.audioId = audioId;
        }

        public string getAudioKey() {
            return this.audioKey;
        }

        public void setAudioKey(string audioKey) {
            this.audioKey = audioKey;
        }

        public string getAudioName() {
            return this.audioName;
        }

        public void setAudioName(string audioName) {
            this.audioName = audioName;
        }

        public int getAudioDuration() {
            return this.audioDuration;
        }

        public void setAudioDuration(int audioDuration) {
            this.audioDuration = audioDuration;
        }

        public long getUploadTime() {
            return this.uploadTime;
        }

        public void setUploadTime(long uploadTime) {
            this.uploadTime = uploadTime;
        }

        public bool isIsCollected() {
            return this.isCollected;
        }

        public void setIsCollected(bool isCollected) {
            this.isCollected = isCollected;
        }

        public bool isIsLiked() {
            return this.isLiked;
        }

        public void setIsLiked(bool isLiked) {
            this.isLiked = isLiked;
        }

        public int getPlayCount() {
            return this.playCount;
        }

        public void setPlayCount(int playCount) {
            this.playCount = playCount;
        }

        public int getLikeCount() {
            return this.likeCount;
        }

        public void setLikeCount(int likeCount) {
            this.likeCount = likeCount;
        }
    }
}

