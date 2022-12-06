using System.Collections.Generic;

namespace network.entity
{
    public class HallRoomDetail {
        public int roomId;

        public string roomName;

        public string roomType;

        public int curNum;

        public int maxNum;

        public bool isAutoDestroy;

        public bool isPrivate;

        public int pwd;

        public int status;

        public List<PropertyValue> properties;

        public List<PropertyValue> hallRoomProperties;

        public int needGuluCoin;

        public int[] shutups;

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

        public int getCurNum() {
            return this.curNum;
        }

        public void setCurNum(int curNum) {
            this.curNum = curNum;
        }

        public int getMaxNum() {
            return this.maxNum;
        }

        public void setMaxNum(int maxNum) {
            this.maxNum = maxNum;
        }

        public bool isIsAutoDestroy() {
            return this.isAutoDestroy;
        }

        public void setIsAutoDestroy(bool isAutoDestroy) {
            this.isAutoDestroy = isAutoDestroy;
        }

        public bool isIsPrivate() {
            return this.isPrivate;
        }

        public void setIsPrivate(bool isPrivate) {
            this.isPrivate = isPrivate;
        }

        public int getPwd() {
            return this.pwd;
        }

        public void setPwd(int pwd) {
            this.pwd = pwd;
        }

        public int getStatus() {
            return this.status;
        }

        public void setStatus(int status) {
            this.status = status;
        }

        public List<PropertyValue> getProperties() {
            return this.properties;
        }

        public void setProperties(List<PropertyValue> properties) {
            this.properties = properties;
        }

        public List<PropertyValue> getHallRoomProperties() {
            return this.hallRoomProperties;
        }

        public void setHallRoomProperties(List<PropertyValue> hallRoomProperties) {
            this.hallRoomProperties = hallRoomProperties;
        }

        public int getNeedGuluCoin() {
            return this.needGuluCoin;
        }

        public void setNeedGuluCoin(int needGuluCoin) {
            this.needGuluCoin = needGuluCoin;
        }

        public int[] getShutups() {
            return this.shutups;
        }

        public void setShutups(int[] shutups) {
            this.shutups = shutups;
        }
    }
}

