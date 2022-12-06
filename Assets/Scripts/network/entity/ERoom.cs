using System.Collections.Generic;

namespace network.entity
{
    public class ERoom {
        public int roomId;

        public string roomName;

        public string roomType;

        public CreateRoomType createType;

        public bool isSubRoom;

        public int status;

        public List<PropertyValue> properties;

        public int owner;

        public bool isPrivate;

        public int maxPlayers;

        public bool isForbidJoin;

        public List<ERoomPlayer> playerList;

        public List<ERoomObject> objectList;

        public List<ERoomTeam> teamList;

        public string routeId;

        public long createTime;

        public FrameSyncState frameSyncState;

        public int frameRate;

        public long startGameTime;

        public List<PropertyValue> hallRoomProperties;

        public int aiId;

        public long enterTime;

        public bool readyOver;

        public List<SpecialGuestInfo> specialGuests;

        public long hospitalStartTime;

        public int hospitalInitHp;

        public long hospitalEnterTime;

        public int hospitalLevelNum;

        public List<ERoomObject> hospitalObjectList;

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

        public CreateRoomType getCreateType() {
            return this.createType;
        }

        public void setCreateType(CreateRoomType createType) {
            this.createType = createType;
        }

        public bool isIsSubRoom() {
            return this.isSubRoom;
        }

        public void setIsSubRoom(bool isSubRoom) {
            this.isSubRoom = isSubRoom;
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

        public int getMaxPlayers() {
            return this.maxPlayers;
        }

        public void setMaxPlayers(int maxPlayers) {
            this.maxPlayers = maxPlayers;
        }

        public bool isIsForbidJoin() {
            return this.isForbidJoin;
        }

        public void setIsForbidJoin(bool isForbidJoin) {
            this.isForbidJoin = isForbidJoin;
        }

        public List<ERoomPlayer> getPlayerList() {
            return this.playerList;
        }

        public void setPlayerList(List<ERoomPlayer> playerList) {
            this.playerList = playerList;
        }

        public List<ERoomObject> getObjectList() {
            return this.objectList;
        }

        public void setObjectList(List<ERoomObject> objectList) {
            this.objectList = objectList;
        }

        public List<ERoomTeam> getTeamList() {
            return this.teamList;
        }

        public void setTeamList(List<ERoomTeam> teamList) {
            this.teamList = teamList;
        }

        public string getRouteId() {
            return this.routeId;
        }

        public void setRouteId(string routeId) {
            this.routeId = routeId;
        }

        public long getCreateTime() {
            return this.createTime;
        }

        public void setCreateTime(long createTime) {
            this.createTime = createTime;
        }

        public FrameSyncState getFrameSyncState() {
            return this.frameSyncState;
        }

        public void setFrameSyncState(FrameSyncState frameSyncState) {
            this.frameSyncState = frameSyncState;
        }

        public int getFrameRate() {
            return this.frameRate;
        }

        public void setFrameRate(int frameRate) {
            this.frameRate = frameRate;
        }

        public long getStartGameTime() {
            return this.startGameTime;
        }

        public void setStartGameTime(long startGameTime) {
            this.startGameTime = startGameTime;
        }

        public List<PropertyValue> getHallRoomProperties() {
            return this.hallRoomProperties;
        }

        public void setHallRoomProperties(List<PropertyValue> hallRoomProperties) {
            this.hallRoomProperties = hallRoomProperties;
        }

        public int getAiId() {
            return this.aiId;
        }

        public void setAiId(int aiId) {
            this.aiId = aiId;
        }

        public long getEnterTime() {
            return this.enterTime;
        }

        public void setEnterTime(long enterTime) {
            this.enterTime = enterTime;
        }

        public bool isReadyOver() {
            return this.readyOver;
        }

        public void setReadyOver(bool readyOver) {
            this.readyOver = readyOver;
        }

        public List<SpecialGuestInfo> getSpecialGuests() {
            return this.specialGuests;
        }

        public void setSpecialGuests(List<SpecialGuestInfo> specialGuests) {
            this.specialGuests = specialGuests;
        }

        public long getHospitalStartTime() {
            return this.hospitalStartTime;
        }

        public void setHospitalStartTime(long hospitalStartTime) {
            this.hospitalStartTime = hospitalStartTime;
        }

        public int getHospitalInitHp() {
            return this.hospitalInitHp;
        }

        public void setHospitalInitHp(int hospitalInitHp) {
            this.hospitalInitHp = hospitalInitHp;
        }

        public long getHospitalEnterTime() {
            return this.hospitalEnterTime;
        }

        public void setHospitalEnterTime(long hospitalEnterTime) {
            this.hospitalEnterTime = hospitalEnterTime;
        }

        public int getHospitalLevelNum() {
            return this.hospitalLevelNum;
        }

        public void setHospitalLevelNum(int hospitalLevelNum) {
            this.hospitalLevelNum = hospitalLevelNum;
        }

        public List<ERoomObject> getHospitalObjectList() {
            return this.hospitalObjectList;
        }

        public void setHospitalObjectList(List<ERoomObject> hospitalObjectList) {
            this.hospitalObjectList = hospitalObjectList;
        }
    }
}

