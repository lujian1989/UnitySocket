using System.Collections.Generic;

namespace network.entity
{
    public class SubERoom {
        public int roomId;

        public string roomName;

        public string roomType;

        public int owner;

        public bool isPrivate;

        public bool isAutoDestroy;

        public int maxPlayers;

        public List<PropertyValue> hallRoomProperties;

        public int getRoomId() {
            return this.roomId;
        }

        public void setRoomId(int roomId) {
            this.roomId = roomId;
        }

        public string getRoomName() {
            return this.roomName;
        }

        public void setRoomName(string roomName) {
            this.roomName = roomName;
        }

        public string getRoomType() {
            return this.roomType;
        }

        public void setRoomType(string roomType) {
            this.roomType = roomType;
        }

        public int getOwner() {
            return this.owner;
        }

        public void setOwner(int owner) {
            this.owner = owner;
        }

        public bool isIsPrivate() {
            return this.isPrivate;
        }

        public void setIsPrivate(bool isPrivate) {
            this.isPrivate = isPrivate;
        }

        public bool isIsAutoDestroy() {
            return this.isAutoDestroy;
        }

        public void setIsAutoDestroy(bool isAutoDestroy) {
            this.isAutoDestroy = isAutoDestroy;
        }

        public int getMaxPlayers() {
            return this.maxPlayers;
        }

        public void setMaxPlayers(int maxPlayers) {
            this.maxPlayers = maxPlayers;
        }

        public List<PropertyValue> getHallRoomProperties() {
            return this.hallRoomProperties;
        }

        public void setHallRoomProperties(List<PropertyValue> hallRoomProperties) {
            this.hallRoomProperties = hallRoomProperties;
        }
    }
}

