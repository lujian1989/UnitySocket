using System.Collections.Generic;

namespace network.entity
{
    public class ActivityRewards {
        public int day;

        public int type;

        public string rewards;

        public string icon;

        public int serie;

        public string itemSell;

        public int getDay() {
            return this.day;
        }

        public void setDay(int day) {
            this.day = day;
        }

        public int getType() {
            return this.type;
        }

        public void setType(int type) {
            this.type = type;
        }

        public string getRewards() {
            return this.rewards;
        }

        public void setRewards(string rewards) {
            this.rewards = rewards;
        }

        public string getIcon() {
            return this.icon;
        }

        public void setIcon(string icon) {
            this.icon = icon;
        }

        public int getSerie() {
            return this.serie;
        }

        public void setSerie(int serie) {
            this.serie = serie;
        }

        public string getItemSell() {
            return this.itemSell;
        }

        public void setItemSell(string itemSell) {
            this.itemSell = itemSell;
        }
    }
}

