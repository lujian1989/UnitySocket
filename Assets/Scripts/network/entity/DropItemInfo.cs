using System.Collections.Generic;

namespace network.entity
{
    public class DropItemInfo {
        public int objId;

        public List<ItemObj> dropItems;

        public int getObjId() {
            return this.objId;
        }

        public void setObjId(int objId) {
            this.objId = objId;
        }

        public List<ItemObj> getDropItems() {
            return this.dropItems;
        }

        public void setDropItems(List<ItemObj> dropItems) {
            this.dropItems = dropItems;
        }
    }
}

