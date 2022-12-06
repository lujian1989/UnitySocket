using System.Collections.Generic;

namespace network.entity
{
    public class CollectionInfo {
        public int audioId;

        public string audioKey;

        public string audioName;

        public int audioDuration;

        public int casterId;

        public string casterName;

        public string casterPictureKey;

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

        public int getCasterId() {
            return this.casterId;
        }

        public void setCasterId(int casterId) {
            this.casterId = casterId;
        }

        public string getCasterName() {
            return this.casterName;
        }

        public void setCasterName(string casterName) {
            this.casterName = casterName;
        }

        public string getCasterPictureKey() {
            return this.casterPictureKey;
        }

        public void setCasterPictureKey(string casterPictureKey) {
            this.casterPictureKey = casterPictureKey;
        }
    }
}

