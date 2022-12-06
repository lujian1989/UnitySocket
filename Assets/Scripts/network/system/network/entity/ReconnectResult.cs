using System.Collections.Generic;

namespace network.entity
{
    public class ReconnectResult {
        public int realReqIdx;

        public int token;

        public int getRealReqIdx() {
            return this.realReqIdx;
        }

        public void setRealReqIdx(int realReqIdx) {
            this.realReqIdx = realReqIdx;
        }

        public int getToken() {
            return this.token;
        }

        public void setToken(int token) {
            this.token = token;
        }
    }
}

