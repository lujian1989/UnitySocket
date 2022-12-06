using System.Collections.Generic;
using network.entity;

namespace network.parser
{
    public class GateSerializer : Serializer {

        public static BackpackObj readBackpackObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            BackpackObj data = new BackpackObj();
            
            data.setId(block.readInt());
            data.setItemCode(block.readInt());
            data.setNum(block.readInt());
            data.setValidTime(block.readInt());
            data.setSender(block.readInt());
            data.setContent(block.readString());
            
            return data;
        }

        public static List<BackpackObj> readList_BackpackObj_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<BackpackObj> list =new List<BackpackObj>();
            
            for(int i=0;i<len;++i) {
                BackpackObj bo=GateSerializer.readBackpackObj(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static List<FriendInfo> readList_FriendInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<FriendInfo> list =new List<FriendInfo>();
            
            for(int i=0;i<len;++i) {
                FriendInfo bo=GateSerializer.readFriendInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static FriendInfo readFriendInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            FriendInfo data = new FriendInfo();
            
            data.setUserId(block.readInt());
            data.setName(block.readString());
            data.setCharacteristic(block.readInt());
            data.setOnline(block.readBoolean());
            data.setHallId(block.readInt());
            data.setRoomId(block.readInt());
            data.setMapId(block.readInt());
            data.setHomelandCode(block.readInt());
            data.setHead(block.readString());
            
            return data;
        }

        public static List<BlackInfo> readList_BlackInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<BlackInfo> list =new List<BlackInfo>();
            
            for(int i=0;i<len;++i) {
                BlackInfo bo=GateSerializer.readBlackInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static BlackInfo readBlackInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            BlackInfo data = new BlackInfo();
            
            data.setUserId(block.readInt());
            data.setName(block.readString());
            data.setCharacteristic(block.readInt());
            
            return data;
        }

        public static List<ApplyInfo> readList_ApplyInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ApplyInfo> list =new List<ApplyInfo>();
            
            for(int i=0;i<len;++i) {
                ApplyInfo bo=GateSerializer.readApplyInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ApplyInfo readApplyInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ApplyInfo data = new ApplyInfo();
            
            data.setUserId(block.readInt());
            data.setName(block.readString());
            data.setCharacteristic(block.readInt());
            data.setOnline(block.readBoolean());
            data.setHead(block.readString());
            
            return data;
        }

        public static List<MessageObj> readList_MessageObj_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<MessageObj> list =new List<MessageObj>();
            
            for(int i=0;i<len;++i) {
                MessageObj bo=GateSerializer.readMessageObj(block);
                list.Add(bo);
            }
            
            return list;
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
            data.setVoice(GateSerializer.readVoiceObj(block));
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

        public static Hall readHall(Block block) {
            if(!block.readBoolean()) {return null;}
            
            Hall data = new Hall();
            
            data.setHallId(block.readInt());
            data.setToken(block.readString());
            
            return data;
        }

        public static List<MailObj> readList_MailObj_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<MailObj> list =new List<MailObj>();
            
            for(int i=0;i<len;++i) {
                MailObj bo=GateSerializer.readMailObj(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static MailObj readMailObj(Block block) {
            if(!block.readBoolean()) {return null;}
            
            MailObj data = new MailObj();
            
            data.setId(block.readInt());
            data.setSender(block.readInt());
            data.setTitle(block.readString());
            data.setContent(block.readString());
            data.setGuluCoin(block.readInt());
            data.setItems(GateSerializer.readList_ItemObj_(block));
            data.setAccepted(block.readInt());
            data.setReaded(block.readInt());
            data.setSendTime(block.readLong());
            
            return data;
        }

        public static List<ItemObj> readList_ItemObj_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ItemObj> list =new List<ItemObj>();
            
            for(int i=0;i<len;++i) {
                ItemObj bo=GateSerializer.readItemObj(block);
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

        public static PlayListInfo readPlayListInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            PlayListInfo data = new PlayListInfo();
            
            data.setCasterPictureKey(block.readString());
            data.setAudioList(GateSerializer.readList_AudioInfo_(block));
            
            return data;
        }

        public static List<AudioInfo> readList_AudioInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<AudioInfo> list =new List<AudioInfo>();
            
            for(int i=0;i<len;++i) {
                AudioInfo bo=GateSerializer.readAudioInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static AudioInfo readAudioInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            AudioInfo data = new AudioInfo();
            
            data.setAudioId(block.readInt());
            data.setAudioKey(block.readString());
            data.setAudioName(block.readString());
            data.setAudioDuration(block.readInt());
            data.setUploadTime(block.readLong());
            data.setIsCollected(block.readBoolean());
            data.setIsLiked(block.readBoolean());
            data.setPlayCount(block.readInt());
            data.setLikeCount(block.readInt());
            
            return data;
        }

        public static List<CollectionInfo> readList_CollectionInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<CollectionInfo> list =new List<CollectionInfo>();
            
            for(int i=0;i<len;++i) {
                CollectionInfo bo=GateSerializer.readCollectionInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static CollectionInfo readCollectionInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            CollectionInfo data = new CollectionInfo();
            
            data.setAudioId(block.readInt());
            data.setAudioKey(block.readString());
            data.setAudioName(block.readString());
            data.setAudioDuration(block.readInt());
            data.setCasterId(block.readInt());
            data.setCasterName(block.readString());
            data.setCasterPictureKey(block.readString());
            
            return data;
        }

        public static List<CasterInfo> readList_CasterInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<CasterInfo> list =new List<CasterInfo>();
            
            for(int i=0;i<len;++i) {
                CasterInfo bo=GateSerializer.readCasterInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static CasterInfo readCasterInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            CasterInfo data = new CasterInfo();
            
            data.setCasterId(block.readInt());
            data.setCasterName(block.readString());
            data.setHeat(block.readInt());
            
            return data;
        }

        public static List<UserWeaponInfo> readList_UserWeaponInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<UserWeaponInfo> list =new List<UserWeaponInfo>();
            
            for(int i=0;i<len;++i) {
                UserWeaponInfo bo=GateSerializer.readUserWeaponInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static UserWeaponInfo readUserWeaponInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            UserWeaponInfo data = new UserWeaponInfo();
            
            data.setId(block.readInt());
            data.setLevel(block.readInt());
            
            return data;
        }

        public static UpWeaponCostInfo readUpWeaponCostInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            UpWeaponCostInfo data = new UpWeaponCostInfo();
            
            data.setGuluCoin(block.readInt());
            data.setMaterial(block.readInt());
            
            return data;
        }

        public static HallAndRoom readHallAndRoom(Block block) {
            if(!block.readBoolean()) {return null;}
            
            HallAndRoom data = new HallAndRoom();
            
            data.setHallId(block.readInt());
            data.setRoomId(block.readInt());
            
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

        public static RoleInfo readRoleInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            RoleInfo data = new RoleInfo();
            
            data.setUserId(block.readInt());
            data.setName(block.readString());
            data.setLevel(block.readInt());
            data.setExp(block.readInt());
            data.setGold(block.readInt());
            data.setDiamond(block.readInt());
            data.setCharacteristic(block.readInt());
            data.setGameCoin(block.readInt());
            data.setVrCoin(block.readInt());
            data.setGuluCoin(block.readInt());
            data.setCreateGuluTime(block.readLong());
            data.setPermission(block.readShort());
            data.setGender(block.readInt());
            data.setHomelandCode(block.readInt());
            data.setGuide(block.readString());
            data.setTitleId(block.readInt());
            data.setHead(block.readString());
            data.setLoginTime(block.readLong());
            data.setAqiAccount(block.readString());
            
            return data;
        }

        public static OnlineGuluCoinInfo readOnlineGuluCoinInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            OnlineGuluCoinInfo data = new OnlineGuluCoinInfo();
            
            data.setGuluCoin(block.readInt());
            data.setCreateGuluTime(block.readLong());
            
            return data;
        }

        public static LevelInfo readLevelInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            LevelInfo data = new LevelInfo();
            
            data.setUserId(block.readInt());
            data.setLevel(block.readInt());
            data.setExp(block.readInt());
            data.setUpExp(block.readInt());
            
            return data;
        }

        public static ActivityStatus readActivityStatus(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ActivityStatus data = new ActivityStatus();
            
            data.setSign(block.readBoolean());
            data.setSevenDayLogin(block.readBoolean());
            data.setOnlineReward(block.readBoolean());
            data.setLoginGifts(block.readBoolean());
            
            return data;
        }

        public static ActivityRewardInfo readActivityRewardInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ActivityRewardInfo data = new ActivityRewardInfo();
            
            data.setSign(block.readString());
            data.setSevenDayLogin(block.readString());
            data.setOnlineReward(block.readString());
            data.setServerTime(block.readLong());
            data.setLoginGifts(block.readString());
            
            return data;
        }

        public static List<ActivityRewards> readList_ActivityRewards_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ActivityRewards> list =new List<ActivityRewards>();
            
            for(int i=0;i<len;++i) {
                ActivityRewards bo=GateSerializer.readActivityRewards(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ActivityRewards readActivityRewards(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ActivityRewards data = new ActivityRewards();
            
            data.setDay(block.readInt());
            data.setType(block.readInt());
            data.setRewards(block.readString());
            data.setIcon(block.readString());
            data.setSerie(block.readInt());
            data.setItemSell(block.readString());
            
            return data;
        }

        public static ShopsInfo readShopsInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ShopsInfo data = new ShopsInfo();
            
            data.setShops(GateSerializer.readList_ShopInfo_(block));
            data.setShopSells(GateSerializer.readList_ShopSellInfo_(block));
            
            return data;
        }

        public static List<ShopInfo> readList_ShopInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ShopInfo> list =new List<ShopInfo>();
            
            for(int i=0;i<len;++i) {
                ShopInfo bo=GateSerializer.readShopInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ShopInfo readShopInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ShopInfo data = new ShopInfo();
            
            data.setShopCode(block.readInt());
            data.setShopName(block.readString());
            data.setUnit(block.readInt());
            data.setOffer(block.readInt());
            data.setLabel(block.readInt());
            data.setStartDt(block.readLong());
            data.setEndDt(block.readLong());
            
            return data;
        }

        public static List<ShopSellInfo> readList_ShopSellInfo_(Block block) {
            int len=block.readShort();
            if(len==-1) {return null;}
            
            List<ShopSellInfo> list =new List<ShopSellInfo>();
            
            for(int i=0;i<len;++i) {
                ShopSellInfo bo=GateSerializer.readShopSellInfo(block);
                list.Add(bo);
            }
            
            return list;
        }

        public static ShopSellInfo readShopSellInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ShopSellInfo data = new ShopSellInfo();
            
            data.setId(block.readInt());
            data.setItemCode(block.readInt());
            data.setItemName(block.readString());
            data.setItemIcon(block.readString());
            data.setShopCode(block.readInt());
            data.setUnit(block.readInt());
            data.setPrice(block.readInt());
            data.setActiveOffer(block.readInt());
            data.setSellNum(block.readInt());
            data.setLimitNum(block.readInt());
            data.setModel(block.readString());
            data.setDescStr(block.readString());
            data.setExistTime(block.readInt());
            
            return data;
        }

        public static BuyResultInfo readBuyResultInfo(Block block) {
            if(!block.readBoolean()) {return null;}
            
            BuyResultInfo data = new BuyResultInfo();
            
            data.setItemCode(block.readInt());
            data.setNum(block.readInt());
            data.setValidTime(block.readInt());
            
            return data;
        }
    }
}

