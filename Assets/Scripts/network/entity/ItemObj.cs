using System.Collections.Generic;

namespace network.entity
{
    public class ItemObj {
        public int itemId;

        public int count;

        public int getItemId() {
            return this.itemId;
        }

        public void setItemId(int itemId) {
            this.itemId = itemId;
        }

        public int getCount() {
            return this.count;
        }

        public void setCount(int count) {
            this.count = count;
        }
    }
}

