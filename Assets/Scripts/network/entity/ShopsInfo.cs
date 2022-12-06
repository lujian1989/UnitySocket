using System.Collections.Generic;

namespace network.entity
{
    public class ShopsInfo {
        public List<ShopInfo> shops;

        public List<ShopSellInfo> shopSells;

        public List<ShopInfo> getShops() {
            return this.shops;
        }

        public void setShops(List<ShopInfo> shops) {
            this.shops = shops;
        }

        public List<ShopSellInfo> getShopSells() {
            return this.shopSells;
        }

        public void setShopSells(List<ShopSellInfo> shopSells) {
            this.shopSells = shopSells;
        }
    }
}

