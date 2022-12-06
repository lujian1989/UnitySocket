using System.Collections.Generic;

namespace network.entity
{
    public class HomePageInfo {
        public List<HallRoomInfo> hallRoomInfos;

        public List<HallNumInfo> hallNumInfos;

        public List<HallRoomInfo> getHallRoomInfos() {
            return this.hallRoomInfos;
        }

        public void setHallRoomInfos(List<HallRoomInfo> hallRoomInfos) {
            this.hallRoomInfos = hallRoomInfos;
        }

        public List<HallNumInfo> getHallNumInfos() {
            return this.hallNumInfos;
        }

        public void setHallNumInfos(List<HallNumInfo> hallNumInfos) {
            this.hallNumInfos = hallNumInfos;
        }
    }
}

