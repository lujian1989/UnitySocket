using System.Collections.Generic;

namespace network.entity
{
    public class OnlineGuluCoinInfo {
        public int guluCoin;

        public long createGuluTime;

        public int getGuluCoin() {
            return this.guluCoin;
        }

        public void setGuluCoin(int guluCoin) {
            this.guluCoin = guluCoin;
        }

        public long getCreateGuluTime() {
            return this.createGuluTime;
        }

        public void setCreateGuluTime(long createGuluTime) {
            this.createGuluTime = createGuluTime;
        }
    }
}

