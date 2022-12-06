using System.Collections.Generic;

namespace network.entity
{
    public class CasterInfo {
        public int casterId;

        public string casterName;

        public int heat;

        public int getCasterId() {
            return this.casterId;
        }

        public void setCasterId(int casterId) {
            this.casterId = casterId;
        }

        public string getCasterName() {
            return this.casterName;
        }

        public void setCasterName(string casterName) {
            this.casterName = casterName;
        }

        public int getHeat() {
            return this.heat;
        }

        public void setHeat(int heat) {
            this.heat = heat;
        }
    }
}

