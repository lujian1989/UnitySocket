using System.Collections.Generic;

namespace network.entity
{
    public class PlayListInfo {
        public string casterPictureKey;

        public List<AudioInfo> audioList;

        public string getCasterPictureKey() {
            return this.casterPictureKey;
        }

        public void setCasterPictureKey(string casterPictureKey) {
            this.casterPictureKey = casterPictureKey;
        }

        public List<AudioInfo> getAudioList() {
            return this.audioList;
        }

        public void setAudioList(List<AudioInfo> audioList) {
            this.audioList = audioList;
        }
    }
}

