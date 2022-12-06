using System.Collections.Generic;

namespace network.entity
{
    public class FrameItem {
        public int playerId;

        public byte[] data;

        public int getPlayerId() {
            return this.playerId;
        }

        public void setPlayerId(int playerId) {
            this.playerId = playerId;
        }

        public byte[] getData() {
            return this.data;
        }

        public void setData(byte[] data) {
            this.data = data;
        }
    }
}

