using System.Collections.Generic;

namespace network.entity
{
    public class BroadcastData {
        public int sendPlayerId;

        public short type;

        public byte[] msg;

        public int getSendPlayerId() {
            return this.sendPlayerId;
        }

        public void setSendPlayerId(int sendPlayerId) {
            this.sendPlayerId = sendPlayerId;
        }

        public short getType() {
            return this.type;
        }

        public void setType(short type) {
            this.type = type;
        }

        public byte[] getMsg() {
            return this.msg;
        }

        public void setMsg(byte[] msg) {
            this.msg = msg;
        }
    }
}

