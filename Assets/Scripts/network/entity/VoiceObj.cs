using System.Collections.Generic;

namespace network.entity
{
    public class VoiceObj {
        public int seconds;

        public string voiceId;

        public int getSeconds() {
            return this.seconds;
        }

        public void setSeconds(int seconds) {
            this.seconds = seconds;
        }

        public string getVoiceId() {
            return this.voiceId;
        }

        public void setVoiceId(string voiceId) {
            this.voiceId = voiceId;
        }
    }
}

