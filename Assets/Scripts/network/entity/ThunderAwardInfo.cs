using System.Collections.Generic;

namespace network.entity
{
    public class ThunderAwardInfo {
        public int mvpId;

        public int winTeam;

        public List<MemberSettleInfo> settleT;

        public List<MemberSettleInfo> settleCT;

        public int getMvpId() {
            return this.mvpId;
        }

        public void setMvpId(int mvpId) {
            this.mvpId = mvpId;
        }

        public int getWinTeam() {
            return this.winTeam;
        }

        public void setWinTeam(int winTeam) {
            this.winTeam = winTeam;
        }

        public List<MemberSettleInfo> getSettleT() {
            return this.settleT;
        }

        public void setSettleT(List<MemberSettleInfo> settleT) {
            this.settleT = settleT;
        }

        public List<MemberSettleInfo> getSettleCT() {
            return this.settleCT;
        }

        public void setSettleCT(List<MemberSettleInfo> settleCT) {
            this.settleCT = settleCT;
        }
    }
}

