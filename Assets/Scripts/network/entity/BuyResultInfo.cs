using System.Collections.Generic;

namespace network.entity
{
    public class BuyResultInfo {
        public int itemCode;

        public int num;

        public int validTime;

        public int getItemCode() {
            return this.itemCode;
        }

        public void setItemCode(int itemCode) {
            this.itemCode = itemCode;
        }

        public int getNum() {
            return this.num;
        }

        public void setNum(int num) {
            this.num = num;
        }

        public int getValidTime() {
            return this.validTime;
        }

        public void setValidTime(int validTime) {
            this.validTime = validTime;
        }
    }
}

