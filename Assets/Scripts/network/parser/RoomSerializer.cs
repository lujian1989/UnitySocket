using System.Collections.Generic;
using network.entity;

namespace network.parser
{
    public class RoomSerializer : Serializer {

        public static void writePropertyValue(Block block, PropertyValue data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeByte(data.getIndex());
            block.writeByteArray(data.getProperties());
        }

        public static int getPropertyValueLength(PropertyValue propertyValue) {
            if(propertyValue==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + Serializer.ByteLength + RoomSerializer.length(propertyValue.getProperties()) ;
        }

        public static void writeList_PropertyValue_(Block block, List<PropertyValue> data) {
            if(data==null) {
                block.writeShort(-1);
                return ;
            }
            block.writeShort(data.Count);
            foreach(PropertyValue bo in data) {
                RoomSerializer.writePropertyValue(block,bo);
            }
        }

        public static int getList_PropertyValue_Length(List<PropertyValue> data) {
            if(data==null)return 2;
            int length=2;
            foreach(PropertyValue propertyValue in data) {
                length+=RoomSerializer.getPropertyValueLength(propertyValue);
            }
            return length;
        }

        public static void writeERoomPlayer(Block block, ERoomPlayer data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeInt(data.getPlayerId());
            block.writeString(data.getName());
            block.writeInt(data.getStatus());
            RoomSerializer.writeList_PropertyValue_(block,data.getProperties());
        }

        public static int getERoomPlayerLength(ERoomPlayer eRoomPlayer) {
            if(eRoomPlayer==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + Serializer.IntLength + RoomSerializer.length(eRoomPlayer.getName()) + Serializer.IntLength + RoomSerializer.getList_PropertyValue_Length(eRoomPlayer.getProperties()) ;
        }

        public static void writeList_ERoomObject_(Block block, List<ERoomObject> data) {
            if(data==null) {
                block.writeShort(-1);
                return ;
            }
            block.writeShort(data.Count);
            foreach(ERoomObject bo in data) {
                RoomSerializer.writeERoomObject(block,bo);
            }
        }

        public static void writeERoomObject(Block block, ERoomObject data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeInt(data.getObjectId());
            block.writeString(data.getName());
            block.writeInt(data.getStatus());
            RoomSerializer.writeList_PropertyValue_(block,data.getProperties());
        }

        public static int getList_ERoomObject_Length(List<ERoomObject> data) {
            if(data==null)return 2;
            int length=2;
            foreach(ERoomObject eRoomObject in data) {
                length+=RoomSerializer.getERoomObjectLength(eRoomObject);
            }
            return length;
        }

        public static int getERoomObjectLength(ERoomObject eRoomObject) {
            if(eRoomObject==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + Serializer.IntLength + RoomSerializer.length(eRoomObject.getName()) + Serializer.IntLength + RoomSerializer.getList_PropertyValue_Length(eRoomObject.getProperties()) ;
        }

        public static void writeList_SpecialGuestInfo_(Block block, List<SpecialGuestInfo> data) {
            if(data==null) {
                block.writeShort(-1);
                return ;
            }
            block.writeShort(data.Count);
            foreach(SpecialGuestInfo bo in data) {
                RoomSerializer.writeSpecialGuestInfo(block,bo);
            }
        }

        public static void writeSpecialGuestInfo(Block block, SpecialGuestInfo data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeString(data.getName());
            block.writeInt(data.getPlayerId());
            block.writeString(data.getHead());
            block.writeInt(data.getGender());
            block.writeInt(data.getCharacteristic());
        }

        public static int getList_SpecialGuestInfo_Length(List<SpecialGuestInfo> data) {
            if(data==null)return 2;
            int length=2;
            foreach(SpecialGuestInfo specialGuestInfo in data) {
                length+=RoomSerializer.getSpecialGuestInfoLength(specialGuestInfo);
            }
            return length;
        }

        public static int getSpecialGuestInfoLength(SpecialGuestInfo specialGuestInfo) {
            if(specialGuestInfo==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + RoomSerializer.length(specialGuestInfo.getName()) + Serializer.IntLength + RoomSerializer.length(specialGuestInfo.getHead()) + Serializer.IntLength + Serializer.IntLength ;
        }

        public static void writeChorusMember(Block block, ChorusMember data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeString(data.getName());
            block.writeInt(data.getPlayerId());
            block.writeString(data.getHead());
            block.writeInt(data.getGender());
            block.writeLong(data.getAddTime());
            block.writeInt(data.getCharacteristic());
        }

        public static int getChorusMemberLength(ChorusMember chorusMember) {
            if(chorusMember==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + RoomSerializer.length(chorusMember.getName()) + Serializer.IntLength + RoomSerializer.length(chorusMember.getHead()) + Serializer.IntLength + Serializer.LongLength + Serializer.IntLength ;
        }

        public static List<Frame> readList_Frame_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<Frame> list =new List<Frame>();
            
            for(int i=0;i<len;++i) {
                Frame bo=RoomSerializer.readFrame(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static Frame readFrame(Block block) {
            if(!block.readBoolean()) {return null;}
            
            Frame data = new Frame();
            
            data.setFrameId(block.readInt());
            data.setItems(RoomSerializer.readList_FrameItem_(block));
            data.setIsReplay(block.readBoolean());
            
            return data;
        }

        public static List<FrameItem> readList_FrameItem_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<FrameItem> list =new List<FrameItem>();
            
            for(int i=0;i<len;++i) {
                FrameItem bo=RoomSerializer.readFrameItem(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static FrameItem readFrameItem(Block block) {
            if(!block.readBoolean()) {return null;}
            
            FrameItem data = new FrameItem();
            
            data.setPlayerId(block.readInt());
            data.setData(block.readByteArray());
            
            return data;
        }

        public static List<UserPhoto> readList_UserPhoto_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<UserPhoto> list =new List<UserPhoto>();
            
            for(int i=0;i<len;++i) {
                UserPhoto bo=RoomSerializer.readUserPhoto(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static UserPhoto readUserPhoto(Block block) {
            if(!block.readBoolean()) {return null;}
            
            UserPhoto data = new UserPhoto();
            
            data.setScreen_type(block.readInt());
            data.setType(block.readInt());
            data.setPath(block.readString());
            
            return data;
        }

        public static ThunderRoomInfo readThunderRoomInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ThunderRoomInfo data = new ThunderRoomInfo();
            
            data.setHallId(block.readInt());
            data.setRoomId(block.readInt());
            data.setCurRound(block.readInt());
            data.setScoreT(block.readInt());
            data.setScoreCT(block.readInt());
            data.setRemainTime(block.readInt());
            data.setMemberInfos(RoomSerializer.readList_ThunderMemberInfo_(block));
            
            return data;
        }

        public static List<ThunderMemberInfo> readList_ThunderMemberInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ThunderMemberInfo> list =new List<ThunderMemberInfo>();
            
            for(int i=0;i<len;++i) {
                ThunderMemberInfo bo=RoomSerializer.readThunderMemberInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ThunderMemberInfo readThunderMemberInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ThunderMemberInfo data = new ThunderMemberInfo();
            
            data.setUserId(block.readInt());
            data.setTeam(block.readInt());
            data.setKillNum(block.readInt());
            data.setDeadNum(block.readInt());
            data.setDeaded(block.readBoolean());
            
            return data;
        }

        public static List<SpecialGuestInfo> readList_SpecialGuestInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<SpecialGuestInfo> list =new List<SpecialGuestInfo>();
            
            for(int i=0;i<len;++i) {
                SpecialGuestInfo bo=RoomSerializer.readSpecialGuestInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static SpecialGuestInfo readSpecialGuestInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            SpecialGuestInfo data = new SpecialGuestInfo();
            
            data.setName(block.readString());
            data.setPlayerId(block.readInt());
            data.setHead(block.readString());
            data.setGender(block.readInt());
            data.setCharacteristic(block.readInt());
            
            return data;
        }

        public static ERoom readERoom(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ERoom data = new ERoom();
            
            data.setRoomId(block.readInt());
            data.setRoomName(block.readString());
            data.setRoomType(block.readString());
            data.setCreateType((CreateRoomType)(block.readShort()));
            data.setIsSubRoom(block.readBoolean());
            data.setStatus(block.readInt());
            data.setProperties(RoomSerializer.readList_PropertyValue_(block));
            data.setOwner(block.readInt());
            data.setIsPrivate(block.readBoolean());
            data.setMaxPlayers(block.readInt());
            data.setIsForbidJoin(block.readBoolean());
            data.setPlayerList(RoomSerializer.readList_ERoomPlayer_(block));
            data.setObjectList(RoomSerializer.readList_ERoomObject_(block));
            data.setTeamList(RoomSerializer.readList_ERoomTeam_(block));
            data.setRouteId(block.readString());
            data.setCreateTime(block.readLong());
            data.setFrameSyncState((FrameSyncState)(block.readShort()));
            data.setFrameRate(block.readInt());
            data.setStartGameTime(block.readLong());
            data.setHallRoomProperties(RoomSerializer.readList_PropertyValue_(block));
            data.setAiId(block.readInt());
            data.setEnterTime(block.readLong());
            data.setReadyOver(block.readBoolean());
            data.setSpecialGuests(RoomSerializer.readList_SpecialGuestInfo_(block));
            data.setHospitalStartTime(block.readLong());
            data.setHospitalInitHp(block.readInt());
            data.setHospitalEnterTime(block.readLong());
            data.setHospitalLevelNum(block.readInt());
            data.setHospitalObjectList(RoomSerializer.readList_ERoomObject_(block));
            
            return data;
        }

        public static List<PropertyValue> readList_PropertyValue_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<PropertyValue> list =new List<PropertyValue>();
            
            for(int i=0;i<len;++i) {
                PropertyValue bo=RoomSerializer.readPropertyValue(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static PropertyValue readPropertyValue(Block block) {
            if(!block.readBoolean()) {return null;}
            
            PropertyValue data = new PropertyValue();
            
            data.setIndex(block.readByte());
            data.setProperties(block.readByteArray());
            
            return data;
        }

        public static List<ERoomPlayer> readList_ERoomPlayer_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ERoomPlayer> list =new List<ERoomPlayer>();
            
            for(int i=0;i<len;++i) {
                ERoomPlayer bo=RoomSerializer.readERoomPlayer(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ERoomPlayer readERoomPlayer(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ERoomPlayer data = new ERoomPlayer();
            
            data.setPlayerId(block.readInt());
            data.setName(block.readString());
            data.setStatus(block.readInt());
            data.setProperties(RoomSerializer.readList_PropertyValue_(block));
            
            return data;
        }

        public static List<ERoomObject> readList_ERoomObject_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ERoomObject> list =new List<ERoomObject>();
            
            for(int i=0;i<len;++i) {
                ERoomObject bo=RoomSerializer.readERoomObject(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ERoomObject readERoomObject(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ERoomObject data = new ERoomObject();
            
            data.setObjectId(block.readInt());
            data.setName(block.readString());
            data.setStatus(block.readInt());
            data.setProperties(RoomSerializer.readList_PropertyValue_(block));
            
            return data;
        }

        public static List<ERoomTeam> readList_ERoomTeam_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ERoomTeam> list =new List<ERoomTeam>();
            
            for(int i=0;i<len;++i) {
                ERoomTeam bo=RoomSerializer.readERoomTeam(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ERoomTeam readERoomTeam(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ERoomTeam data = new ERoomTeam();
            
            data.setTeamId(block.readInt());
            data.setTeamName(block.readString());
            data.setMinPlayers(block.readInt());
            data.setMaxPlayers(block.readInt());
            
            return data;
        }

        public static HallRoomDetail readHallRoomDetail(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HallRoomDetail data = new HallRoomDetail();
            
            data.setRoomId(block.readInt());
            data.setRoomName(block.readString());
            data.setRoomType(block.readString());
            data.setCurNum(block.readInt());
            data.setMaxNum(block.readInt());
            data.setIsAutoDestroy(block.readBoolean());
            data.setIsPrivate(block.readBoolean());
            data.setPwd(block.readInt());
            data.setStatus(block.readInt());
            data.setProperties(RoomSerializer.readList_PropertyValue_(block));
            data.setHallRoomProperties(RoomSerializer.readList_PropertyValue_(block));
            data.setNeedGuluCoin(block.readInt());
            data.setShutups(block.readIntArray());
            
            return data;
        }

        public static List<HomePhotoFramesUrl> readList_HomePhotoFramesUrl_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<HomePhotoFramesUrl> list =new List<HomePhotoFramesUrl>();
            
            for(int i=0;i<len;++i) {
                HomePhotoFramesUrl bo=RoomSerializer.readHomePhotoFramesUrl(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static HomePhotoFramesUrl readHomePhotoFramesUrl(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HomePhotoFramesUrl data = new HomePhotoFramesUrl();
            
            data.setItemCode(block.readInt());
            data.setUrl(block.readString());
            
            return data;
        }

        public static SubERoom readSubERoom(Block block) {
            if(!block.readBoolean()) {return null;}
            
            SubERoom data = new SubERoom();
            
            data.setRoomId(block.readInt());
            data.setRoomName(block.readString());
            data.setRoomType(block.readString());
            data.setOwner(block.readInt());
            data.setIsPrivate(block.readBoolean());
            data.setIsAutoDestroy(block.readBoolean());
            data.setMaxPlayers(block.readInt());
            data.setHallRoomProperties(RoomSerializer.readList_PropertyValue_(block));
            
            return data;
        }

        public static List<ChorusMember> readList_ChorusMember_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ChorusMember> list =new List<ChorusMember>();
            
            for(int i=0;i<len;++i) {
                ChorusMember bo=RoomSerializer.readChorusMember(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ChorusMember readChorusMember(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ChorusMember data = new ChorusMember();
            
            data.setName(block.readString());
            data.setPlayerId(block.readInt());
            data.setHead(block.readString());
            data.setGender(block.readInt());
            data.setAddTime(block.readLong());
            data.setCharacteristic(block.readInt());
            
            return data;
        }

        public static DeepOverInfo readDeepOverInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            DeepOverInfo data = new DeepOverInfo();
            
            data.setGuluCoin(block.readInt());
            data.setMaterial(block.readInt());
            
            return data;
        }

        public static ThunderAwardInfo readThunderAwardInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ThunderAwardInfo data = new ThunderAwardInfo();
            
            data.setMvpId(block.readInt());
            data.setWinTeam(block.readInt());
            data.setSettleT(RoomSerializer.readList_MemberSettleInfo_(block));
            data.setSettleCT(RoomSerializer.readList_MemberSettleInfo_(block));
            
            return data;
        }

        public static List<MemberSettleInfo> readList_MemberSettleInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<MemberSettleInfo> list =new List<MemberSettleInfo>();
            
            for(int i=0;i<len;++i) {
                MemberSettleInfo bo=RoomSerializer.readMemberSettleInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static MemberSettleInfo readMemberSettleInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            MemberSettleInfo data = new MemberSettleInfo();
            
            data.setUserId(block.readInt());
            data.setRank(block.readInt());
            data.setKillNum(block.readInt());
            data.setDeadNum(block.readInt());
            data.setGuluCoin(block.readInt());
            data.setTip(block.readString());
            
            return data;
        }

        public static TeamInfo readTeamInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            TeamInfo data = new TeamInfo();
            
            data.setHallId(block.readInt());
            data.setRoomId(block.readInt());
            data.setCurRound(block.readInt());
            data.setTeamT(block.readIntArray());
            data.setTeamCT(block.readIntArray());
            
            return data;
        }

        public static SystemTipInfo readSystemTipInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            SystemTipInfo data = new SystemTipInfo();
            
            data.setType(block.readByte());
            data.setSender(block.readInt());
            data.setContent(block.readString());
            data.setInterval(block.readInt());
            data.setCount(block.readInt());
            
            return data;
        }

        public static List<AwardInfo> readList_AwardInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<AwardInfo> list =new List<AwardInfo>();
            
            for(int i=0;i<len;++i) {
                AwardInfo bo=RoomSerializer.readAwardInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static AwardInfo readAwardInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            AwardInfo data = new AwardInfo();
            
            data.setUserId(block.readInt());
            data.setRank(block.readInt());
            data.setGuluCoin(block.readInt());
            data.setTip(block.readString());
            data.setScore(block.readInt());
            
            return data;
        }

        public static MessageObj readMessageObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            MessageObj data = new MessageObj();
            
            data.setId(block.readInt());
            data.setOwner(block.readInt());
            data.setSender(block.readInt());
            data.setCharacteristic(block.readInt());
            data.setLevel(block.readInt());
            data.setName(block.readString());
            data.setHead(block.readString());
            data.setVoice(RoomSerializer.readVoiceObj(block));
            data.setReaded(block.readBoolean());
            data.setSaveTime(block.readLong());
            
            return data;
        }

        public static VoiceObj readVoiceObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            VoiceObj data = new VoiceObj();
            
            data.setSeconds(block.readInt());
            data.setVoiceId(block.readString());
            
            return data;
        }

        public static KillInfo readKillInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            KillInfo data = new KillInfo();
            
            data.setAttackerUserId(block.readInt());
            data.setWeaponId(block.readInt());
            data.setDeaderUserId(block.readInt());
            data.setAttackKeepKillNum(block.readInt());
            data.setAttackKillNum(block.readInt());
            data.setAttackDeadNum(block.readInt());
            data.setDeaderKillNum(block.readInt());
            data.setDeaderDeadNum(block.readInt());
            
            return data;
        }

        public static HospitalRefreshObject readHospitalRefreshObject(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HospitalRefreshObject data = new HospitalRefreshObject();
            
            data.setLevelNum(block.readInt());
            data.setMonsters(RoomSerializer.readList_HospitalMonsterObject_(block));
            
            return data;
        }

        public static List<HospitalMonsterObject> readList_HospitalMonsterObject_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<HospitalMonsterObject> list =new List<HospitalMonsterObject>();
            
            for(int i=0;i<len;++i) {
                HospitalMonsterObject bo=RoomSerializer.readHospitalMonsterObject(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static HospitalMonsterObject readHospitalMonsterObject(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HospitalMonsterObject data = new HospitalMonsterObject();
            
            data.setMonsterObjectId(block.readInt());
            data.setMonsterId(block.readInt());
            data.setPoint(block.readInt());
            data.setHp(block.readInt());
            
            return data;
        }

        public static List<HospitalDropObject> readList_HospitalDropObject_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<HospitalDropObject> list =new List<HospitalDropObject>();
            
            for(int i=0;i<len;++i) {
                HospitalDropObject bo=RoomSerializer.readHospitalDropObject(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static HospitalDropObject readHospitalDropObject(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HospitalDropObject data = new HospitalDropObject();
            
            data.setDropObjectId(block.readInt());
            data.setMonsterObjectId(block.readInt());
            data.setItemId(block.readInt());
            data.setPoint(block.readInt());
            
            return data;
        }
    }
}

