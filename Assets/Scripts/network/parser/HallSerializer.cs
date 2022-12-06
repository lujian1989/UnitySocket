using System.Collections.Generic;
using network.entity;

namespace network.parser
{
    public class HallSerializer : Serializer {

        public static ReplyDialogueObj readReplyDialogueObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ReplyDialogueObj data = new ReplyDialogueObj();
            
            data.setBottleId(block.readInt());
            data.setReaded(block.readBoolean());
            data.setReplyRole(HallSerializer.readRoleShareInfo(block));
            data.setDialogues(HallSerializer.readList_DialogueObj_(block));
            
            return data;
        }

        public static RoleShareInfo readRoleShareInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            RoleShareInfo data = new RoleShareInfo();
            
            data.setUserId(block.readInt());
            data.setName(block.readString());
            data.setCharacteristic(block.readInt());
            data.setLevel(block.readInt());
            data.setGuest(block.readInt());
            data.setHomelandCode(block.readInt());
            data.setGender(block.readInt());
            data.setTitleId(block.readInt());
            data.setPermission(block.readShort());
            data.setHead(block.readString());
            
            return data;
        }

        public static List<DialogueObj> readList_DialogueObj_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<DialogueObj> list =new List<DialogueObj>();
            
            for(int i=0;i<len;++i) {
                DialogueObj bo=HallSerializer.readDialogueObj(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static DialogueObj readDialogueObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            DialogueObj data = new DialogueObj();
            
            data.setSender(block.readInt());
            data.setBottleId(block.readInt());
            data.setType(block.readInt());
            data.setVoice(HallSerializer.readVoiceObj(block));
            data.setContent(block.readString());
            data.setImgUrl(block.readString());
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

        public static List<ReplyDialogueObj> readList_ReplyDialogueObj_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ReplyDialogueObj> list =new List<ReplyDialogueObj>();
            
            for(int i=0;i<len;++i) {
                ReplyDialogueObj bo=HallSerializer.readReplyDialogueObj(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static List<ReplyObj> readList_ReplyObj_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ReplyObj> list =new List<ReplyObj>();
            
            for(int i=0;i<len;++i) {
                ReplyObj bo=HallSerializer.readReplyObj(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ReplyObj readReplyObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ReplyObj data = new ReplyObj();
            
            data.setReplyRole(HallSerializer.readRoleShareInfo(block));
            data.setBottleId(block.readInt());
            data.setReaded(block.readBoolean());
            
            return data;
        }

        public static UserBottleObj readUserBottleObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            UserBottleObj data = new UserBottleObj();
            
            data.setState(block.readInt());
            data.setSendNum(block.readInt());
            data.setReplyNum(block.readInt());
            
            return data;
        }

        public static DriftBottleObj readDriftBottleObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            DriftBottleObj data = new DriftBottleObj();
            
            data.setSendRole(HallSerializer.readRoleShareInfo(block));
            data.setBottleId(block.readInt());
            data.setType(block.readInt());
            data.setVoice(HallSerializer.readVoiceObj(block));
            data.setContent(block.readString());
            data.setImgUrl(block.readString());
            data.setSaveTime(block.readLong());
            
            return data;
        }

        public static void writeVoteInfo(Block block, VoteInfo data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeString(data.getSongName());
            block.writeString(data.getPlayerName());
            block.writeInt(data.getPlayerId());
            block.writeInt(data.getNum());
            block.writeString(data.getHead());
            block.writeInt(data.getGender());
            block.writeLong(data.getVoteTime());
            block.writeInt(data.getCharacteristic());
        }

        public static int getVoteInfoLength(VoteInfo voteInfo) {
            if(voteInfo==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + HallSerializer.length(voteInfo.getSongName()) + HallSerializer.length(voteInfo.getPlayerName()) + Serializer.IntLength + Serializer.IntLength + HallSerializer.length(voteInfo.getHead()) + Serializer.IntLength + Serializer.LongLength + Serializer.IntLength ;
        }

        public static void writePlayerSoundInfo(Block block, PlayerSoundInfo data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeFloat(data.getHostSound());
            block.writeFloat(data.getPlayerSound());
        }

        public static int getPlayerSoundInfoLength(PlayerSoundInfo playerSoundInfo) {
            if(playerSoundInfo==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + Serializer.FloatLength + Serializer.FloatLength ;
        }

        public static void writeScoringInfo(Block block, ScoringInfo data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeString(data.getSongName());
            block.writeString(data.getPlayerName());
            block.writeInt(data.getPlayerId());
            block.writeInt(data.getScore());
            block.writeInt(data.getRank());
            block.writeLong(data.getScoreTime());
        }

        public static int getScoringInfoLength(ScoringInfo scoringInfo) {
            if(scoringInfo==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + HallSerializer.length(scoringInfo.getSongName()) + HallSerializer.length(scoringInfo.getPlayerName()) + Serializer.IntLength + Serializer.IntLength + Serializer.IntLength + Serializer.LongLength ;
        }

        public static void writeHallPlayerInfo(Block block, HallPlayerInfo data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeInt(data.getPlayerId());
            block.writeString(data.getName());
            block.writeInt(data.getStatus());
            HallSerializer.writeList_PropertyValue_(block,data.getProperties());
        }

        public static void writeList_PropertyValue_(Block block, List<PropertyValue> data) {
            if(data==null) {
                block.writeShort(-1);
                return ;
            }
            block.writeShort(data.Count);
            foreach(PropertyValue bo in data) {
                HallSerializer.writePropertyValue(block,bo);
            }
        }

        public static void writePropertyValue(Block block, PropertyValue data) {
            if(data==null) {block.writeBoolean(false);return;}
            block.writeBoolean(true);
            block.writeByte(data.getIndex());
            block.writeByteArray(data.getProperties());
        }

        public static int getHallPlayerInfoLength(HallPlayerInfo hallPlayerInfo) {
            if(hallPlayerInfo==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + Serializer.IntLength + HallSerializer.length(hallPlayerInfo.getName()) + Serializer.IntLength + HallSerializer.getList_PropertyValue_Length(hallPlayerInfo.getProperties()) ;
        }

        public static int getList_PropertyValue_Length(List<PropertyValue> data) {
            if(data==null)return 2;
            int length=2;
            foreach(PropertyValue propertyValue in data) {
                length+=HallSerializer.getPropertyValueLength(propertyValue);
            }
            return length;
        }

        public static int getPropertyValueLength(PropertyValue propertyValue) {
            if(propertyValue==null) return Serializer.BooleanLength;
            return Serializer.BooleanLength + Serializer.ByteLength + HallSerializer.length(propertyValue.getProperties()) ;
        }

        public static DropItemInfo readDropItemInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            DropItemInfo data = new DropItemInfo();
            
            data.setObjId(block.readInt());
            data.setDropItems(HallSerializer.readList_ItemObj_(block));
            
            return data;
        }

        public static List<ItemObj> readList_ItemObj_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ItemObj> list =new List<ItemObj>();
            
            for(int i=0;i<len;++i) {
                ItemObj bo=HallSerializer.readItemObj(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ItemObj readItemObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ItemObj data = new ItemObj();
            
            data.setItemId(block.readInt());
            data.setCount(block.readInt());
            
            return data;
        }

        public static List<VoteInfo> readList_VoteInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<VoteInfo> list =new List<VoteInfo>();
            
            for(int i=0;i<len;++i) {
                VoteInfo bo=HallSerializer.readVoteInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static VoteInfo readVoteInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            VoteInfo data = new VoteInfo();
            
            data.setSongName(block.readString());
            data.setPlayerName(block.readString());
            data.setPlayerId(block.readInt());
            data.setNum(block.readInt());
            data.setHead(block.readString());
            data.setGender(block.readInt());
            data.setVoteTime(block.readLong());
            data.setCharacteristic(block.readInt());
            
            return data;
        }

        public static List<TitlePrizeInfo> readList_TitlePrizeInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<TitlePrizeInfo> list =new List<TitlePrizeInfo>();
            
            for(int i=0;i<len;++i) {
                TitlePrizeInfo bo=HallSerializer.readTitlePrizeInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static TitlePrizeInfo readTitlePrizeInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            TitlePrizeInfo data = new TitlePrizeInfo();
            
            data.setUserId(block.readInt());
            data.setName(block.readString());
            data.setTitleId(block.readInt());
            
            return data;
        }

        public static StreetPannelInfo readStreetPannelInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            StreetPannelInfo data = new StreetPannelInfo();
            
            data.setType(block.readInt());
            data.setUrl(block.readString());
            
            return data;
        }

        public static List<HallRoomInfo> readList_HallRoomInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<HallRoomInfo> list =new List<HallRoomInfo>();
            
            for(int i=0;i<len;++i) {
                HallRoomInfo bo=HallSerializer.readHallRoomInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static HallRoomInfo readHallRoomInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HallRoomInfo data = new HallRoomInfo();
            
            data.setHallId(block.readInt());
            data.setRoomId(block.readInt());
            data.setRoomName(block.readString());
            data.setRoomType(block.readString());
            data.setOwner(block.readInt());
            data.setMaxNum(block.readInt());
            data.setCurNum(block.readInt());
            data.setSpecialNum(block.readInt());
            data.setIsAutoDestroy(block.readBoolean());
            data.setIsPrivate(block.readBoolean());
            data.setPwd(block.readInt());
            data.setStatus(block.readInt());
            data.setHallRoomInfo(HallSerializer.readList_PropertyValue_(block));
            data.setPlayerList(HallSerializer.readList_HallPlayerInfo_(block));
            data.setRandomInt(block.readInt());
            data.setNeedGuluCoin(block.readInt());
            data.setShutups(block.readIntArray());
            data.setIsMatchRoom(block.readBoolean());
            data.setMapId(block.readInt());
            data.setIsWork(block.readInt());
            data.setIsSystemRoom(block.readBoolean());
            data.setMainRoomId(block.readInt());
            data.setIndex(block.readInt());
            data.setIsTutorialRoom(block.readBoolean());
            data.setIsKTVPrivateRoom(block.readBoolean());
            data.setKtvTimeoutMs(block.readLong());
            
            return data;
        }

        public static List<PropertyValue> readList_PropertyValue_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<PropertyValue> list =new List<PropertyValue>();
            
            for(int i=0;i<len;++i) {
                PropertyValue bo=HallSerializer.readPropertyValue(block);
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

        public static List<HallPlayerInfo> readList_HallPlayerInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<HallPlayerInfo> list =new List<HallPlayerInfo>();
            
            for(int i=0;i<len;++i) {
                HallPlayerInfo bo=HallSerializer.readHallPlayerInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static HallPlayerInfo readHallPlayerInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HallPlayerInfo data = new HallPlayerInfo();
            
            data.setPlayerId(block.readInt());
            data.setName(block.readString());
            data.setStatus(block.readInt());
            data.setProperties(HallSerializer.readList_PropertyValue_(block));
            
            return data;
        }

        public static PlayerSoundInfo readPlayerSoundInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            PlayerSoundInfo data = new PlayerSoundInfo();
            
            data.setHostSound(block.readFloat());
            data.setPlayerSound(block.readFloat());
            
            return data;
        }

        public static List<ScoringInfo> readList_ScoringInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ScoringInfo> list =new List<ScoringInfo>();
            
            for(int i=0;i<len;++i) {
                ScoringInfo bo=HallSerializer.readScoringInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ScoringInfo readScoringInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ScoringInfo data = new ScoringInfo();
            
            data.setSongName(block.readString());
            data.setPlayerName(block.readString());
            data.setPlayerId(block.readInt());
            data.setScore(block.readInt());
            data.setRank(block.readInt());
            data.setScoreTime(block.readLong());
            
            return data;
        }

        public static List<AnswerInfo> readList_AnswerInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<AnswerInfo> list =new List<AnswerInfo>();
            
            for(int i=0;i<len;++i) {
                AnswerInfo bo=HallSerializer.readAnswerInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static AnswerInfo readAnswerInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            AnswerInfo data = new AnswerInfo();
            
            data.setName(block.readString());
            data.setHead(block.readString());
            data.setPlayerId(block.readInt());
            data.setGender(block.readInt());
            data.setAnswerTime(block.readLong());
            data.setCharacteristic(block.readInt());
            
            return data;
        }

        public static HomePageInfo readHomePageInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HomePageInfo data = new HomePageInfo();
            
            data.setHallRoomInfos(HallSerializer.readList_HallRoomInfo_(block));
            data.setHallNumInfos(HallSerializer.readList_HallNumInfo_(block));
            
            return data;
        }

        public static List<HallNumInfo> readList_HallNumInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<HallNumInfo> list =new List<HallNumInfo>();
            
            for(int i=0;i<len;++i) {
                HallNumInfo bo=HallSerializer.readHallNumInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static HallNumInfo readHallNumInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HallNumInfo data = new HallNumInfo();
            
            data.setHallId(block.readInt());
            data.setNum(block.readInt());
            data.setRoomNum(block.readInt());
            
            return data;
        }

        public static List<GuessGamePlayerInfos> readList_GuessGamePlayerInfos_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<GuessGamePlayerInfos> list =new List<GuessGamePlayerInfos>();
            
            for(int i=0;i<len;++i) {
                GuessGamePlayerInfos bo=HallSerializer.readGuessGamePlayerInfos(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static GuessGamePlayerInfos readGuessGamePlayerInfos(Block block) {
            if(!block.readBoolean()) {return null;}
            
            GuessGamePlayerInfos data = new GuessGamePlayerInfos();
            
            data.setPlayerId(block.readInt());
            data.setVal(block.readInt());
            
            return data;
        }

        public static ActivityInfo readActivityInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ActivityInfo data = new ActivityInfo();
            
            data.setOper(block.readBoolean());
            data.setUrl(block.readString());
            data.setMainRoomId(block.readInt());
            
            return data;
        }

        public static RandHomeland readRandHomeland(Block block) {
            if(!block.readBoolean()) {return null;}
            
            RandHomeland data = new RandHomeland();
            
            data.setUserId(block.readInt());
            data.setHomelandCode(block.readInt());
            
            return data;
        }

        public static HLInfo readHLInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HLInfo data = new HLInfo();
            
            data.setUserId(block.readInt());
            data.setNickName(block.readString());
            data.setBgPicture(block.readString());
            data.setSignature(block.readString());
            data.setVideo(block.readString());
            data.setAudio(block.readString());
            data.setLikes(HallSerializer.readList_HomelandLike_(block));
            data.setLikesNum(block.readInt());
            data.setLikeCurHomeland(block.readBoolean());
            
            return data;
        }

        public static List<HomelandLike> readList_HomelandLike_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<HomelandLike> list =new List<HomelandLike>();
            
            for(int i=0;i<len;++i) {
                HomelandLike bo=HallSerializer.readHomelandLike(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static HomelandLike readHomelandLike(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HomelandLike data = new HomelandLike();
            
            data.setId(block.readInt());
            data.setNickName(block.readString());
            data.setHeadPic(block.readInt());
            data.setLikeTime(block.readLong());
            data.setHead(block.readString());
            
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
            data.setVoice(HallSerializer.readVoiceObj(block));
            data.setReaded(block.readBoolean());
            data.setSaveTime(block.readLong());
            
            return data;
        }

        public static List<SongInfo> readList_SongInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<SongInfo> list =new List<SongInfo>();
            
            for(int i=0;i<len;++i) {
                SongInfo bo=HallSerializer.readSongInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static SongInfo readSongInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            SongInfo data = new SongInfo();
            
            data.setSongId(block.readString());
            data.setResourceType(block.readInt());
            data.setSongName(block.readString());
            data.setOriginalSinger(block.readString());
            data.setSinger(block.readInt());
            data.setSingerName(block.readString());
            data.setChoristers(block.readIntArray());
            
            return data;
        }

        public static List<BroadcastData> readList_BroadcastData_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<BroadcastData> list =new List<BroadcastData>();
            
            for(int i=0;i<len;++i) {
                BroadcastData bo=HallSerializer.readBroadcastData(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static BroadcastData readBroadcastData(Block block) {
            if(!block.readBoolean()) {return null;}
            
            BroadcastData data = new BroadcastData();
            
            data.setSendPlayerId(block.readInt());
            data.setType(block.readShort());
            data.setMsg(block.readByteArray());
            
            return data;
        }
    }
}

