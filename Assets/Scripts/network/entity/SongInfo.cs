using System.Collections.Generic;

namespace network.entity
{
    public class SongInfo {
        public string songId;

        public int resourceType;

        public string songName;

        public string originalSinger;

        public int singer;

        public string singerName;

        public int[] choristers;

        public string getSongId() {
            return this.songId;
        }

        public void setSongId(string songId) {
            this.songId = songId;
        }

        public int getResourceType() {
            return this.resourceType;
        }

        public void setResourceType(int resourceType) {
            this.resourceType = resourceType;
        }

        public string getSongName() {
            return this.songName;
        }

        public void setSongName(string songName) {
            this.songName = songName;
        }

        public string getOriginalSinger() {
            return this.originalSinger;
        }

        public void setOriginalSinger(string originalSinger) {
            this.originalSinger = originalSinger;
        }

        public int getSinger() {
            return this.singer;
        }

        public void setSinger(int singer) {
            this.singer = singer;
        }

        public string getSingerName() {
            return this.singerName;
        }

        public void setSingerName(string singerName) {
            this.singerName = singerName;
        }

        public int[] getChoristers() {
            return this.choristers;
        }

        public void setChoristers(int[] choristers) {
            this.choristers = choristers;
        }
    }
}

