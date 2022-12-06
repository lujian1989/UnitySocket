using System.Collections.Generic;

namespace network.entity
{
    public class DialogueObj {
        public int sender;

        public int bottleId;

        public int type;

        public VoiceObj voice;

        public string content;

        public string imgUrl;

        public long saveTime;

        public int getSender() {
            return this.sender;
        }

        public void setSender(int sender) {
            this.sender = sender;
        }

        public int getBottleId() {
            return this.bottleId;
        }

        public void setBottleId(int bottleId) {
            this.bottleId = bottleId;
        }

        public int getType() {
            return this.type;
        }

        public void setType(int type) {
            this.type = type;
        }

        public VoiceObj getVoice() {
            return this.voice;
        }

        public void setVoice(VoiceObj voice) {
            this.voice = voice;
        }

        public string getContent() {
            return this.content;
        }

        public void setContent(string content) {
            this.content = content;
        }

        public string getImgUrl() {
            return this.imgUrl;
        }

        public void setImgUrl(string imgUrl) {
            this.imgUrl = imgUrl;
        }

        public long getSaveTime() {
            return this.saveTime;
        }

        public void setSaveTime(long saveTime) {
            this.saveTime = saveTime;
        }
    }
}

