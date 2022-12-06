using System.Collections.Generic;

namespace network.entity
{
    public class Frame {
        public int frameId;

        public List<FrameItem> items;

        public bool isReplay;

        public int getFrameId() {
            return this.frameId;
        }

        public void setFrameId(int frameId) {
            this.frameId = frameId;
        }

        public List<FrameItem> getItems() {
            return this.items;
        }

        public void setItems(List<FrameItem> items) {
            this.items = items;
        }

        public bool isIsReplay() {
            return this.isReplay;
        }

        public void setIsReplay(bool isReplay) {
            this.isReplay = isReplay;
        }
    }
}

