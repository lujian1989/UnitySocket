using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class RoleNetService {
        public static RoleNetService ins = new RoleNetService();

        NodeClient client;

        RoleOnUpLevelNotify roleOnUpLevelNotify;

        RoleOnServerRestartNotify roleOnServerRestartNotify;

        RoleOnJGLChangedNotify roleOnJGLChangedNotify;

        RoleOnDeclareNotify roleOnDeclareNotify;

        public RoleNetService() {
            client =NodeClient.get("RoleNetService");
        }

        public void useMoneyGun(RoleUseMoneyGunResponse.Success _s_ =  null, RoleUseMoneyGunResponse.Fail _f_ =  null) {
            RoleUseMoneyGunRequest req=new RoleUseMoneyGunRequest();
            client.send(req, new RoleUseMoneyGunResponse(_s_, _f_));
        }

        public void useHomeLand(int code, RoleUseHomeLandResponse.Success _s_ =  null, RoleUseHomeLandResponse.Fail _f_ =  null) {
            RoleUseHomeLandRequest req=new RoleUseHomeLandRequest();
            req.code=code;
            client.send(req, new RoleUseHomeLandResponse(_s_, _f_));
        }

        public void setPlatform(string platform, RoleSetPlatformResponse.Success _s_ =  null, RoleSetPlatformResponse.Fail _f_ =  null) {
            RoleSetPlatformRequest req=new RoleSetPlatformRequest();
            req.platform=platform;
            client.send(req, new RoleSetPlatformResponse(_s_, _f_));
        }

        public void setGuide(int type, int step, RoleSetGuideResponse.Success _s_ =  null, RoleSetGuideResponse.Fail _f_ =  null) {
            RoleSetGuideRequest req=new RoleSetGuideRequest();
            req.type=type;
            req.step=step;
            client.send(req, new RoleSetGuideResponse(_s_, _f_));
        }

        public void setGender(int gender, RoleSetGenderResponse.Success _s_ =  null, RoleSetGenderResponse.Fail _f_ =  null) {
            RoleSetGenderRequest req=new RoleSetGenderRequest();
            req.gender=gender;
            client.send(req, new RoleSetGenderResponse(_s_, _f_));
        }

        public void setCharacterName(string name, RoleSetCharacterNameResponse.Success _s_ =  null, RoleSetCharacterNameResponse.Fail _f_ =  null) {
            RoleSetCharacterNameRequest req=new RoleSetCharacterNameRequest();
            req.name=name;
            client.send(req, new RoleSetCharacterNameResponse(_s_, _f_));
        }

        public void setCharacterId(int characterId, RoleSetCharacterIdResponse.Success _s_ =  null, RoleSetCharacterIdResponse.Fail _f_ =  null) {
            RoleSetCharacterIdRequest req=new RoleSetCharacterIdRequest();
            req.characterId=characterId;
            client.send(req, new RoleSetCharacterIdResponse(_s_, _f_));
        }

        public void sellHomeland(RoleSellHomelandResponse.Success _s_ =  null, RoleSellHomelandResponse.Fail _f_ =  null) {
            RoleSellHomelandRequest req=new RoleSellHomelandRequest();
            client.send(req, new RoleSellHomelandResponse(_s_, _f_));
        }

        public void onOnUpLevelNotify(RoleOnUpLevelNotify.OnUpLevelNotify onUpLevelNotify) {
            RoleOnUpLevelNotify cls=new RoleOnUpLevelNotify();
            cls.onUpLevelNotify = onUpLevelNotify;
            client.onNotify(cls);
            roleOnUpLevelNotify= cls;
        }

        public void offOnUpLevelNotify() {
            if (roleOnUpLevelNotify != null){
                client.offNotify(((roleOnUpLevelNotify.getClsID()&0xff)<<8)|(roleOnUpLevelNotify.getMethodID()&0xff));
                roleOnUpLevelNotify= null;
            }
        }

        public void onOnServerRestartNotify(RoleOnServerRestartNotify.OnServerRestartNotify onServerRestartNotify) {
            RoleOnServerRestartNotify cls=new RoleOnServerRestartNotify();
            cls.onServerRestartNotify = onServerRestartNotify;
            client.onNotify(cls);
            roleOnServerRestartNotify= cls;
        }

        public void offOnServerRestartNotify() {
            if (roleOnServerRestartNotify != null){
                client.offNotify(((roleOnServerRestartNotify.getClsID()&0xff)<<8)|(roleOnServerRestartNotify.getMethodID()&0xff));
                roleOnServerRestartNotify= null;
            }
        }

        public void onOnJGLChangedNotify(RoleOnJGLChangedNotify.OnJGLChangedNotify onJGLChangedNotify) {
            RoleOnJGLChangedNotify cls=new RoleOnJGLChangedNotify();
            cls.onJGLChangedNotify = onJGLChangedNotify;
            client.onNotify(cls);
            roleOnJGLChangedNotify= cls;
        }

        public void offOnJGLChangedNotify() {
            if (roleOnJGLChangedNotify != null){
                client.offNotify(((roleOnJGLChangedNotify.getClsID()&0xff)<<8)|(roleOnJGLChangedNotify.getMethodID()&0xff));
                roleOnJGLChangedNotify= null;
            }
        }

        public void onOnDeclareNotify(RoleOnDeclareNotify.OnDeclareNotify onDeclareNotify) {
            RoleOnDeclareNotify cls=new RoleOnDeclareNotify();
            cls.onDeclareNotify = onDeclareNotify;
            client.onNotify(cls);
            roleOnDeclareNotify= cls;
        }

        public void offOnDeclareNotify() {
            if (roleOnDeclareNotify != null){
                client.offNotify(((roleOnDeclareNotify.getClsID()&0xff)<<8)|(roleOnDeclareNotify.getMethodID()&0xff));
                roleOnDeclareNotify= null;
            }
        }

        public void getServerTime(RoleGetServerTimeResponse.Success _s_ =  null, RoleGetServerTimeResponse.Fail _f_ =  null) {
            RoleGetServerTimeRequest req=new RoleGetServerTimeRequest();
            client.send(req, new RoleGetServerTimeResponse(_s_, _f_));
        }

        public void getRoomInfo(int userId, RoleGetRoomInfoResponse.Success _s_ =  null, RoleGetRoomInfoResponse.Fail _f_ =  null) {
            RoleGetRoomInfoRequest req=new RoleGetRoomInfoRequest();
            req.userId=userId;
            client.send(req, new RoleGetRoomInfoResponse(_s_, _f_));
        }

        public void getRoleShareInfo(int userId, RoleGetRoleShareInfoResponse.Success _s_ =  null, RoleGetRoleShareInfoResponse.Fail _f_ =  null) {
            RoleGetRoleShareInfoRequest req=new RoleGetRoleShareInfoRequest();
            req.userId=userId;
            client.send(req, new RoleGetRoleShareInfoResponse(_s_, _f_));
        }

        public void getRoleInfo(RoleGetRoleInfoResponse.Success _s_ =  null, RoleGetRoleInfoResponse.Fail _f_ =  null) {
            RoleGetRoleInfoRequest req=new RoleGetRoleInfoRequest();
            client.send(req, new RoleGetRoleInfoResponse(_s_, _f_));
        }

        public void getOnlineGuluCoin(RoleGetOnlineGuluCoinResponse.Success _s_ =  null, RoleGetOnlineGuluCoinResponse.Fail _f_ =  null) {
            RoleGetOnlineGuluCoinRequest req=new RoleGetOnlineGuluCoinRequest();
            client.send(req, new RoleGetOnlineGuluCoinResponse(_s_, _f_));
        }

        public void getLevelInfo(RoleGetLevelInfoResponse.Success _s_ =  null, RoleGetLevelInfoResponse.Fail _f_ =  null) {
            RoleGetLevelInfoRequest req=new RoleGetLevelInfoRequest();
            client.send(req, new RoleGetLevelInfoResponse(_s_, _f_));
        }

        public void getKTVIsOpen(RoleGetKTVIsOpenResponse.Success _s_ =  null, RoleGetKTVIsOpenResponse.Fail _f_ =  null) {
            RoleGetKTVIsOpenRequest req=new RoleGetKTVIsOpenRequest();
            client.send(req, new RoleGetKTVIsOpenResponse(_s_, _f_));
        }

        public void getCharacterName(RoleGetCharacterNameResponse.Success _s_ =  null, RoleGetCharacterNameResponse.Fail _f_ =  null) {
            RoleGetCharacterNameRequest req=new RoleGetCharacterNameRequest();
            client.send(req, new RoleGetCharacterNameResponse(_s_, _f_));
        }

        public void getCharacterId(RoleGetCharacterIdResponse.Success _s_ =  null, RoleGetCharacterIdResponse.Fail _f_ =  null) {
            RoleGetCharacterIdRequest req=new RoleGetCharacterIdRequest();
            client.send(req, new RoleGetCharacterIdResponse(_s_, _f_));
        }

        public void getActivityStatus(RoleGetActivityStatusResponse.Success _s_ =  null, RoleGetActivityStatusResponse.Fail _f_ =  null) {
            RoleGetActivityStatusRequest req=new RoleGetActivityStatusRequest();
            client.send(req, new RoleGetActivityStatusResponse(_s_, _f_));
        }

        public void getActivityRewardInfo(RoleGetActivityRewardInfoResponse.Success _s_ =  null, RoleGetActivityRewardInfoResponse.Fail _f_ =  null) {
            RoleGetActivityRewardInfoRequest req=new RoleGetActivityRewardInfoRequest();
            client.send(req, new RoleGetActivityRewardInfoResponse(_s_, _f_));
        }

        public void getActivityRewardConfig(int type, RoleGetActivityRewardConfigResponse.Success _s_ =  null, RoleGetActivityRewardConfigResponse.Fail _f_ =  null) {
            RoleGetActivityRewardConfigRequest req=new RoleGetActivityRewardConfigRequest();
            req.type=type;
            client.send(req, new RoleGetActivityRewardConfigResponse(_s_, _f_));
        }

        public void buyHomeLand(int code, RoleBuyHomeLandResponse.Success _s_ =  null, RoleBuyHomeLandResponse.Fail _f_ =  null) {
            RoleBuyHomeLandRequest req=new RoleBuyHomeLandRequest();
            req.code=code;
            client.send(req, new RoleBuyHomeLandResponse(_s_, _f_));
        }

        public void bindAqiAccount(string aqiAccount, RoleBindAqiAccountResponse.Success _s_ =  null, RoleBindAqiAccountResponse.Fail _f_ =  null) {
            RoleBindAqiAccountRequest req=new RoleBindAqiAccountRequest();
            req.aqiAccount=aqiAccount;
            client.send(req, new RoleBindAqiAccountResponse(_s_, _f_));
        }

        public void GetActivityRewards(int type, int day, RoleGetActivityRewardsResponse.Success _s_ =  null, RoleGetActivityRewardsResponse.Fail _f_ =  null) {
            RoleGetActivityRewardsRequest req=new RoleGetActivityRewardsRequest();
            req.type=type;
            req.day=day;
            client.send(req, new RoleGetActivityRewardsResponse(_s_, _f_));
        }
    }
}

