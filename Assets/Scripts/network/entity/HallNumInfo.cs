using System.Collections.Generic;

namespace network.entity
{
    public class HallNumInfo {
        public int hallId;

        public int num;

        public int roomNum;

        public int getHallId() {
            return this.hallId;
        }

        public void setHallId(int hallId) {
            this.hallId = hallId;
        }

        public int getNum() {
            return this.num;
        }

        public void setNum(int num) {
            this.num = num;
        }

        public int getRoomNum() {
            return this.roomNum;
        }

        public void setRoomNum(int roomNum) {
            this.roomNum = roomNum;
        }
    }
}

