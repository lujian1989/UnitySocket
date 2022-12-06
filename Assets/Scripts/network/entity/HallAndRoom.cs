using System.Collections.Generic;

namespace network.entity
{
    public class HallAndRoom {
        public int hallId;

        public int roomId;

        public int getHallId() {
            return this.hallId;
        }

        public void setHallId(int hallId) {
            this.hallId = hallId;
        }

        public int getRoomId() {
            return this.roomId;
        }

        public void setRoomId(int roomId) {
            this.roomId = roomId;
        }
    }
}

