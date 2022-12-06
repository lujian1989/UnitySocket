using System.Collections.Generic;

namespace network.entity
{
    public class ShopInfo {
        public int shopCode;

        public string shopName;

        public int unit;

        public int offer;

        public int label;

        public long startDt;

        public long endDt;

        public int getShopCode() {
            return this.shopCode;
        }

        public void setShopCode(int shopCode) {
            this.shopCode = shopCode;
        }

        public string getShopName() {
            return this.shopName;
        }

        public void setShopName(string shopName) {
            this.shopName = shopName;
        }

        public int getUnit() {
            return this.unit;
        }

        public void setUnit(int unit) {
            this.unit = unit;
        }

        public int getOffer() {
            return this.offer;
        }

        public void setOffer(int offer) {
            this.offer = offer;
        }

        public int getLabel() {
            return this.label;
        }

        public void setLabel(int label) {
            this.label = label;
        }

        public long getStartDt() {
            return this.startDt;
        }

        public void setStartDt(long startDt) {
            this.startDt = startDt;
        }

        public long getEndDt() {
            return this.endDt;
        }

        public void setEndDt(long endDt) {
            this.endDt = endDt;
        }
    }
}

