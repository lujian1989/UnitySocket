using System.Collections.Generic;

namespace network.entity
{
    public class HallRoomInfo {
        public int hallId;

        public int roomId;

        public string roomName;

        public string roomType;

        public int owner;

        public int maxNum;

        public int curNum;

        public int specialNum;

        public bool isAutoDestroy;

        public bool isPrivate;

        public int pwd;

        public int status;

        public List<PropertyValue> hallRoomInfo;

        public List<HallPlayerInfo> playerList;

        public int randomInt;

        public int needGuluCoin;

        public int[] shutups;

        public bool isMatchRoom;

        public int mapId;

        public int isWork;

        public bool isSystemRoom;

        public int mainRoomId;

        public int index;

        public bool isTutorialRoom;

        public bool isKTVPrivateRoom;

        public long ktvTimeoutMs;

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

        public int getMaxNum() {
            return this.maxNum;
        }

        public void setMaxNum(int maxNum) {
            this.maxNum = maxNum;
        }

        public int getCurNum() {
            return this.curNum;
        }

        public void setCurNum(int curNum) {
            this.curNum = curNum;
        }

        public int getSpecialNum() {
            return this.specialNum;
        }

        public void setSpecialNum(int specialNum) {
            this.specialNum = specialNum;
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

        public List<PropertyValue> getHallRoomInfo() {
            return this.hallRoomInfo;
        }

        public void setHallRoomInfo(List<PropertyValue> hallRoomInfo) {
            this.hallRoomInfo = hallRoomInfo;
        }

        public List<HallPlayerInfo> getPlayerList() {
            return this.playerList;
        }

        public void setPlayerList(List<HallPlayerInfo> playerList) {
            this.playerList = playerList;
        }

        public int getRandomInt() {
            return this.randomInt;
        }

        public void setRandomInt(int randomInt) {
            this.randomInt = randomInt;
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

        public bool isIsMatchRoom() {
            return this.isMatchRoom;
        }

        public void setIsMatchRoom(bool isMatchRoom) {
            this.isMatchRoom = isMatchRoom;
        }

        public int getMapId() {
            return this.mapId;
        }

        public void setMapId(int mapId) {
            this.mapId = mapId;
        }

        public int getIsWork() {
            return this.isWork;
        }

        public void setIsWork(int isWork) {
            this.isWork = isWork;
        }

        public bool isIsSystemRoom() {
            return this.isSystemRoom;
        }

        public void setIsSystemRoom(bool isSystemRoom) {
            this.isSystemRoom = isSystemRoom;
        }

        public int getMainRoomId() {
            return this.mainRoomId;
        }

        public void setMainRoomId(int mainRoomId) {
            this.mainRoomId = mainRoomId;
        }

        public int getIndex() {
            return this.index;
        }

        public void setIndex(int index) {
            this.index = index;
        }

        public bool isIsTutorialRoom() {
            return this.isTutorialRoom;
        }

        public void setIsTutorialRoom(bool isTutorialRoom) {
            this.isTutorialRoom = isTutorialRoom;
        }

        public bool isIsKTVPrivateRoom() {
            return this.isKTVPrivateRoom;
        }

        public void setIsKTVPrivateRoom(bool isKTVPrivateRoom) {
            this.isKTVPrivateRoom = isKTVPrivateRoom;
        }

        public long getKtvTimeoutMs() {
            return this.ktvTimeoutMs;
        }

        public void setKtvTimeoutMs(long ktvTimeoutMs) {
            this.ktvTimeoutMs = ktvTimeoutMs;
        }
    }
}

