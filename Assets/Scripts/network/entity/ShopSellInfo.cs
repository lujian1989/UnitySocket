using System.Collections.Generic;

namespace network.entity
{
    public class ShopSellInfo {
        public int id;

        public int itemCode;

        public string itemName;

        public string itemIcon;

        public int shopCode;

        public int unit;

        public int price;

        public int activeOffer;

        public int sellNum;

        public int limitNum;

        public string model;

        public string descStr;

        public int existTime;

        public int getId() {
            return this.id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getItemCode() {
            return this.itemCode;
        }

        public void setItemCode(int itemCode) {
            this.itemCode = itemCode;
        }

        public string getItemName() {
            return this.itemName;
        }

        public void setItemName(string itemName) {
            this.itemName = itemName;
        }

        public string getItemIcon() {
            return this.itemIcon;
        }

        public void setItemIcon(string itemIcon) {
            this.itemIcon = itemIcon;
        }

        public int getShopCode() {
            return this.shopCode;
        }

        public void setShopCode(int shopCode) {
            this.shopCode = shopCode;
        }

        public int getUnit() {
            return this.unit;
        }

        public void setUnit(int unit) {
            this.unit = unit;
        }

        public int getPrice() {
            return this.price;
        }

        public void setPrice(int price) {
            this.price = price;
        }

        public int getActiveOffer() {
            return this.activeOffer;
        }

        public void setActiveOffer(int activeOffer) {
            this.activeOffer = activeOffer;
        }

        public int getSellNum() {
            return this.sellNum;
        }

        public void setSellNum(int sellNum) {
            this.sellNum = sellNum;
        }

        public int getLimitNum() {
            return this.limitNum;
        }

        public void setLimitNum(int limitNum) {
            this.limitNum = limitNum;
        }

        public string getModel() {
            return this.model;
        }

        public void setModel(string model) {
            this.model = model;
        }

        public string getDescStr() {
            return this.descStr;
        }

        public void setDescStr(string descStr) {
            this.descStr = descStr;
        }

        public int getExistTime() {
            return this.existTime;
        }

        public void setExistTime(int existTime) {
            this.existTime = existTime;
        }
    }
}

