using System.Collections.Generic;

namespace network.entity
{
    public class PlayerSoundInfo {
        public float hostSound;

        public float playerSound;

        public float getHostSound() {
            return this.hostSound;
        }

        public void setHostSound(float hostSound) {
            this.hostSound = hostSound;
        }

        public float getPlayerSound() {
            return this.playerSound;
        }

        public void setPlayerSound(float playerSound) {
            this.playerSound = playerSound;
        }
    }
}

