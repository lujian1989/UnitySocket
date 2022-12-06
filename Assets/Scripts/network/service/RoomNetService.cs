using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class RoomNetService {
        public static RoomNetService ins = new RoomNetService();

        public NodeClient client;

        bool isSendClose;

        RoomThunderStartFailNotify roomThunderStartFailNotify;

        RoomThunderSettleNotify roomThunderSettleNotify;

        RoomThunderRoundStartNotify roomThunderRoundStartNotify;

        RoomThunderRoundOverNotify roomThunderRoundOverNotify;

        RoomTeamNotify roomTeamNotify;

        RoomSpecialGuestsNotify roomSpecialGuestsNotify;

        RoomReadyOverNotify roomReadyOverNotify;

        RoomOpenActivity1Notify roomOpenActivity1Notify;

        RoomOnSystemTipNotify roomOnSystemTipNotify;

        RoomOnStopFrameSyncNotify roomOnStopFrameSyncNotify;

        RoomOnStartFrameSyncNotify roomOnStartFrameSyncNotify;

        RoomOnShutupNotify roomOnShutupNotify;

        RoomOnRoomStatusAndPropertiesChangedNotify roomOnRoomStatusAndPropertiesChangedNotify;

        RoomOnRemovePlayerNotify roomOnRemovePlayerNotify;

        RoomOnRecvFromTrialNotify roomOnRecvFromTrialNotify;

        RoomOnRecvFromClientNotify roomOnRecvFromClientNotify;

        RoomOnRecvFrameNotify roomOnRecvFrameNotify;

        RoomOnPlayerStatusAndPropertiesChangedNotify roomOnPlayerStatusAndPropertiesChangedNotify;

        RoomOnObjectStatusAndPropertiesChangedNotify roomOnObjectStatusAndPropertiesChangedNotify;

        RoomOnLeaveRoomNotify roomOnLeaveRoomNotify;

        RoomOnJoinRoomNotify roomOnJoinRoomNotify;

        RoomOnGameAwardNotify roomOnGameAwardNotify;

        RoomOnDismissRoomNotify roomOnDismissRoomNotify;

        RoomOnDestroyObjectNotify roomOnDestroyObjectNotify;

        RoomOnCreateObjectNotify roomOnCreateObjectNotify;

        RoomOnChangeRoomNotify roomOnChangeRoomNotify;

        RoomOnChangePlayerNetworkStateNotify roomOnChangePlayerNetworkStateNotify;

        RoomNewGramophoneMsgNotify roomNewGramophoneMsgNotify;

        RoomKillNotify roomKillNotify;

        RoomHospitalSavePlayerNotify roomHospitalSavePlayerNotify;

        RoomHospitalResultNotify roomHospitalResultNotify;

        RoomHospitalPlayerDeadNotify roomHospitalPlayerDeadNotify;

        RoomHospitalPickNotify roomHospitalPickNotify;

        RoomHospitalMonsterNotify roomHospitalMonsterNotify;

        RoomHospitalMonsterDeadNotify roomHospitalMonsterDeadNotify;

        RoomHospitalDropObjectExpireNotify roomHospitalDropObjectExpireNotify;

        RoomHospitalDropItemNotify roomHospitalDropItemNotify;

        RoomHospitalDamageNotify roomHospitalDamageNotify;

        RoomHomePhotoFramesUrlNotify roomHomePhotoFramesUrlNotify;

        RoomDeleteGramophoneMsgNotify roomDeleteGramophoneMsgNotify;

        RoomDeadNotify roomDeadNotify;

        RoomChorusMemberNotify roomChorusMemberNotify;

        RoomAiLevelNotify roomAiLevelNotify;

        RoomAiIdChangedNotify roomAiIdChangedNotify;

        public RoomNetService() {
            client =NodeClient.get("RoomNetService");
        }

        public void setSendClose(bool isSendClose) {
            this.isSendClose = isSendClose;
        }

        public void trialToAll(short type, int id, byte[] msg, RoomTrialToAllResponse.Success _s_ =  null, RoomTrialToAllResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomTrialToAllRequest req=new RoomTrialToAllRequest();
            req.type=type;
            req.id=id;
            req.msg=msg;
            client.send(req, new RoomTrialToAllResponse(_s_, _f_));
        }

        public void onThunderStartFailNotify(RoomThunderStartFailNotify.ThunderStartFailNotify thunderStartFailNotify) {
            RoomThunderStartFailNotify cls=new RoomThunderStartFailNotify();
            cls.thunderStartFailNotify = thunderStartFailNotify;
            client.onNotify(cls);
            roomThunderStartFailNotify= cls;
        }

        public void offThunderStartFailNotify() {
            if (roomThunderStartFailNotify != null){
                client.offNotify(((roomThunderStartFailNotify.getClsID()&0xff)<<8)|(roomThunderStartFailNotify.getMethodID()&0xff));
                roomThunderStartFailNotify= null;
            }
        }

        public void onThunderSettleNotify(RoomThunderSettleNotify.ThunderSettleNotify thunderSettleNotify) {
            RoomThunderSettleNotify cls=new RoomThunderSettleNotify();
            cls.thunderSettleNotify = thunderSettleNotify;
            client.onNotify(cls);
            roomThunderSettleNotify= cls;
        }

        public void offThunderSettleNotify() {
            if (roomThunderSettleNotify != null){
                client.offNotify(((roomThunderSettleNotify.getClsID()&0xff)<<8)|(roomThunderSettleNotify.getMethodID()&0xff));
                roomThunderSettleNotify= null;
            }
        }

        public void onThunderRoundStartNotify(RoomThunderRoundStartNotify.ThunderRoundStartNotify thunderRoundStartNotify) {
            RoomThunderRoundStartNotify cls=new RoomThunderRoundStartNotify();
            cls.thunderRoundStartNotify = thunderRoundStartNotify;
            client.onNotify(cls);
            roomThunderRoundStartNotify= cls;
        }

        public void offThunderRoundStartNotify() {
            if (roomThunderRoundStartNotify != null){
                client.offNotify(((roomThunderRoundStartNotify.getClsID()&0xff)<<8)|(roomThunderRoundStartNotify.getMethodID()&0xff));
                roomThunderRoundStartNotify= null;
            }
        }

        public void onThunderRoundOverNotify(RoomThunderRoundOverNotify.ThunderRoundOverNotify thunderRoundOverNotify) {
            RoomThunderRoundOverNotify cls=new RoomThunderRoundOverNotify();
            cls.thunderRoundOverNotify = thunderRoundOverNotify;
            client.onNotify(cls);
            roomThunderRoundOverNotify= cls;
        }

        public void offThunderRoundOverNotify() {
            if (roomThunderRoundOverNotify != null){
                client.offNotify(((roomThunderRoundOverNotify.getClsID()&0xff)<<8)|(roomThunderRoundOverNotify.getMethodID()&0xff));
                roomThunderRoundOverNotify= null;
            }
        }

        public void onTeamNotify(RoomTeamNotify.TeamNotify teamNotify) {
            RoomTeamNotify cls=new RoomTeamNotify();
            cls.teamNotify = teamNotify;
            client.onNotify(cls);
            roomTeamNotify= cls;
        }

        public void offTeamNotify() {
            if (roomTeamNotify != null){
                client.offNotify(((roomTeamNotify.getClsID()&0xff)<<8)|(roomTeamNotify.getMethodID()&0xff));
                roomTeamNotify= null;
            }
        }

        public void stopFrameSync(RoomStopFrameSyncResponse.Success _s_ =  null, RoomStopFrameSyncResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomStopFrameSyncRequest req=new RoomStopFrameSyncRequest();
            client.send(req, new RoomStopFrameSyncResponse(_s_, _f_));
        }

        public void startFrameSync(RoomStartFrameSyncResponse.Success _s_ =  null, RoomStartFrameSyncResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomStartFrameSyncRequest req=new RoomStartFrameSyncRequest();
            client.send(req, new RoomStartFrameSyncResponse(_s_, _f_));
        }

        public void onSpecialGuestsNotify(RoomSpecialGuestsNotify.SpecialGuestsNotify specialGuestsNotify) {
            RoomSpecialGuestsNotify cls=new RoomSpecialGuestsNotify();
            cls.specialGuestsNotify = specialGuestsNotify;
            client.onNotify(cls);
            roomSpecialGuestsNotify= cls;
        }

        public void offSpecialGuestsNotify() {
            if (roomSpecialGuestsNotify != null){
                client.offNotify(((roomSpecialGuestsNotify.getClsID()&0xff)<<8)|(roomSpecialGuestsNotify.getMethodID()&0xff));
                roomSpecialGuestsNotify= null;
            }
        }

        public void shutup(byte type, int playerId, RoomShutupResponse.Success _s_ =  null, RoomShutupResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomShutupRequest req=new RoomShutupRequest();
            req.type=type;
            req.playerId=playerId;
            client.send(req, new RoomShutupResponse(_s_, _f_));
        }

        public void setHomePhotoFramesUrl(int itemCode, string url, RoomSetHomePhotoFramesUrlResponse.Success _s_ =  null, RoomSetHomePhotoFramesUrlResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSetHomePhotoFramesUrlRequest req=new RoomSetHomePhotoFramesUrlRequest();
            req.itemCode=itemCode;
            req.url=url;
            client.send(req, new RoomSetHomePhotoFramesUrlResponse(_s_, _f_));
        }

        public void sendToPlayers(int[] players, short type, byte[] msg, RoomSendToPlayersResponse.Success _s_ =  null, RoomSendToPlayersResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSendToPlayersRequest req=new RoomSendToPlayersRequest();
            req.players=players;
            req.type=type;
            req.msg=msg;
            client.send(req, new RoomSendToPlayersResponse(_s_, _f_));
        }

        public void sendToOthers(short type, byte[] msg, RoomSendToOthersResponse.Success _s_ =  null, RoomSendToOthersResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSendToOthersRequest req=new RoomSendToOthersRequest();
            req.type=type;
            req.msg=msg;
            client.send(req, new RoomSendToOthersResponse(_s_, _f_));
        }

        public void sendToAll(short type, byte[] msg, RoomSendToAllResponse.Success _s_ =  null, RoomSendToAllResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSendToAllRequest req=new RoomSendToAllRequest();
            req.type=type;
            req.msg=msg;
            client.send(req, new RoomSendToAllResponse(_s_, _f_));
        }

        public void sendFrame(byte[] data, RoomSendFrameResponse.Success _s_ =  null, RoomSendFrameResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSendFrameRequest req=new RoomSendFrameRequest();
            req.data=data;
            client.send(req, new RoomSendFrameResponse(_s_, _f_));
        }

        public void saveRoomStatusAndProperty(int oriStatus, int dstStatus, PropertyValue value, RoomSaveRoomStatusAndPropertyResponse.Success _s_ =  null, RoomSaveRoomStatusAndPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveRoomStatusAndPropertyRequest req=new RoomSaveRoomStatusAndPropertyRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.value=value;
            client.send(req, new RoomSaveRoomStatusAndPropertyResponse(_s_, _f_));
        }

        public void saveRoomStatusAndProperties(int oriStatus, int dstStatus, List<PropertyValue> values, RoomSaveRoomStatusAndPropertiesResponse.Success _s_ =  null, RoomSaveRoomStatusAndPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveRoomStatusAndPropertiesRequest req=new RoomSaveRoomStatusAndPropertiesRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.values=values;
            client.send(req, new RoomSaveRoomStatusAndPropertiesResponse(_s_, _f_));
        }

        public void saveRoomStatus(int oriStatus, int dstStatus, RoomSaveRoomStatusResponse.Success _s_ =  null, RoomSaveRoomStatusResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveRoomStatusRequest req=new RoomSaveRoomStatusRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            client.send(req, new RoomSaveRoomStatusResponse(_s_, _f_));
        }

        public void saveRoomProperty(PropertyValue value, RoomSaveRoomPropertyResponse.Success _s_ =  null, RoomSaveRoomPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveRoomPropertyRequest req=new RoomSaveRoomPropertyRequest();
            req.value=value;
            client.send(req, new RoomSaveRoomPropertyResponse(_s_, _f_));
        }

        public void saveRoomProperties(List<PropertyValue> values, RoomSaveRoomPropertiesResponse.Success _s_ =  null, RoomSaveRoomPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveRoomPropertiesRequest req=new RoomSaveRoomPropertiesRequest();
            req.values=values;
            client.send(req, new RoomSaveRoomPropertiesResponse(_s_, _f_));
        }

        public void savePlayerStatusAndProperty(int playerStatus, PropertyValue value, RoomSavePlayerStatusAndPropertyResponse.Success _s_ =  null, RoomSavePlayerStatusAndPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSavePlayerStatusAndPropertyRequest req=new RoomSavePlayerStatusAndPropertyRequest();
            req.playerStatus=playerStatus;
            req.value=value;
            client.send(req, new RoomSavePlayerStatusAndPropertyResponse(_s_, _f_));
        }

        public void savePlayerStatusAndProperties(int playerStatus, List<PropertyValue> values, RoomSavePlayerStatusAndPropertiesResponse.Success _s_ =  null, RoomSavePlayerStatusAndPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSavePlayerStatusAndPropertiesRequest req=new RoomSavePlayerStatusAndPropertiesRequest();
            req.playerStatus=playerStatus;
            req.values=values;
            client.send(req, new RoomSavePlayerStatusAndPropertiesResponse(_s_, _f_));
        }

        public void savePlayerStatus(int playerStatus, RoomSavePlayerStatusResponse.Success _s_ =  null, RoomSavePlayerStatusResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSavePlayerStatusRequest req=new RoomSavePlayerStatusRequest();
            req.playerStatus=playerStatus;
            client.send(req, new RoomSavePlayerStatusResponse(_s_, _f_));
        }

        public void savePlayerProperty(PropertyValue value, RoomSavePlayerPropertyResponse.Success _s_ =  null, RoomSavePlayerPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSavePlayerPropertyRequest req=new RoomSavePlayerPropertyRequest();
            req.value=value;
            client.send(req, new RoomSavePlayerPropertyResponse(_s_, _f_));
        }

        public void savePlayerProperties(List<PropertyValue> values, RoomSavePlayerPropertiesResponse.Success _s_ =  null, RoomSavePlayerPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSavePlayerPropertiesRequest req=new RoomSavePlayerPropertiesRequest();
            req.values=values;
            client.send(req, new RoomSavePlayerPropertiesResponse(_s_, _f_));
        }

        public void saveObjectStatusAndProperty(int objId, int oriStatus, int dstStatus, PropertyValue value, RoomSaveObjectStatusAndPropertyResponse.Success _s_ =  null, RoomSaveObjectStatusAndPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveObjectStatusAndPropertyRequest req=new RoomSaveObjectStatusAndPropertyRequest();
            req.objId=objId;
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.value=value;
            client.send(req, new RoomSaveObjectStatusAndPropertyResponse(_s_, _f_));
        }

        public void saveObjectStatusAndProperties(int objId, int oriStatus, int dstStatus, List<PropertyValue> values, RoomSaveObjectStatusAndPropertiesResponse.Success _s_ =  null, RoomSaveObjectStatusAndPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveObjectStatusAndPropertiesRequest req=new RoomSaveObjectStatusAndPropertiesRequest();
            req.objId=objId;
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.values=values;
            client.send(req, new RoomSaveObjectStatusAndPropertiesResponse(_s_, _f_));
        }

        public void saveObjectStatus(int objId, int oriStatus, int dstStatus, RoomSaveObjectStatusResponse.Success _s_ =  null, RoomSaveObjectStatusResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveObjectStatusRequest req=new RoomSaveObjectStatusRequest();
            req.objId=objId;
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            client.send(req, new RoomSaveObjectStatusResponse(_s_, _f_));
        }

        public void saveObjectProperty(int objId, PropertyValue value, RoomSaveObjectPropertyResponse.Success _s_ =  null, RoomSaveObjectPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveObjectPropertyRequest req=new RoomSaveObjectPropertyRequest();
            req.objId=objId;
            req.value=value;
            client.send(req, new RoomSaveObjectPropertyResponse(_s_, _f_));
        }

        public void saveObjectProperties(int objId, List<PropertyValue> values, RoomSaveObjectPropertiesResponse.Success _s_ =  null, RoomSaveObjectPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomSaveObjectPropertiesRequest req=new RoomSaveObjectPropertiesRequest();
            req.objId=objId;
            req.values=values;
            client.send(req, new RoomSaveObjectPropertiesResponse(_s_, _f_));
        }

        public void requestFrame(int beginFrameId, int endFrameId, RoomRequestFrameResponse.Success _s_ =  null, RoomRequestFrameResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomRequestFrameRequest req=new RoomRequestFrameRequest();
            req.beginFrameId=beginFrameId;
            req.endFrameId=endFrameId;
            client.send(req, new RoomRequestFrameResponse(_s_, _f_));
        }

        public void reqAiId(int aiCmdId, RoomReqAiIdResponse.Success _s_ =  null, RoomReqAiIdResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomReqAiIdRequest req=new RoomReqAiIdRequest();
            req.aiCmdId=aiCmdId;
            client.send(req, new RoomReqAiIdResponse(_s_, _f_));
        }

        public void removePlayer(int removePlayerId, RoomRemovePlayerResponse.Success _s_ =  null, RoomRemovePlayerResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomRemovePlayerRequest req=new RoomRemovePlayerRequest();
            req.removePlayerId=removePlayerId;
            client.send(req, new RoomRemovePlayerResponse(_s_, _f_));
        }

        public void onReadyOverNotify(RoomReadyOverNotify.ReadyOverNotify readyOverNotify) {
            RoomReadyOverNotify cls=new RoomReadyOverNotify();
            cls.readyOverNotify = readyOverNotify;
            client.onNotify(cls);
            roomReadyOverNotify= cls;
        }

        public void offReadyOverNotify() {
            if (roomReadyOverNotify != null){
                client.offNotify(((roomReadyOverNotify.getClsID()&0xff)<<8)|(roomReadyOverNotify.getMethodID()&0xff));
                roomReadyOverNotify= null;
            }
        }

        public void onOpenActivity1Notify(RoomOpenActivity1Notify.OpenActivity1Notify openActivity1Notify) {
            RoomOpenActivity1Notify cls=new RoomOpenActivity1Notify();
            cls.openActivity1Notify = openActivity1Notify;
            client.onNotify(cls);
            roomOpenActivity1Notify= cls;
        }

        public void offOpenActivity1Notify() {
            if (roomOpenActivity1Notify != null){
                client.offNotify(((roomOpenActivity1Notify.getClsID()&0xff)<<8)|(roomOpenActivity1Notify.getMethodID()&0xff));
                roomOpenActivity1Notify= null;
            }
        }

        public void onOnSystemTipNotify(RoomOnSystemTipNotify.OnSystemTipNotify onSystemTipNotify) {
            RoomOnSystemTipNotify cls=new RoomOnSystemTipNotify();
            cls.onSystemTipNotify = onSystemTipNotify;
            client.onNotify(cls);
            roomOnSystemTipNotify= cls;
        }

        public void offOnSystemTipNotify() {
            if (roomOnSystemTipNotify != null){
                client.offNotify(((roomOnSystemTipNotify.getClsID()&0xff)<<8)|(roomOnSystemTipNotify.getMethodID()&0xff));
                roomOnSystemTipNotify= null;
            }
        }

        public void onOnStopFrameSyncNotify(RoomOnStopFrameSyncNotify.OnStopFrameSyncNotify onStopFrameSyncNotify) {
            RoomOnStopFrameSyncNotify cls=new RoomOnStopFrameSyncNotify();
            cls.onStopFrameSyncNotify = onStopFrameSyncNotify;
            client.onNotify(cls);
            roomOnStopFrameSyncNotify= cls;
        }

        public void offOnStopFrameSyncNotify() {
            if (roomOnStopFrameSyncNotify != null){
                client.offNotify(((roomOnStopFrameSyncNotify.getClsID()&0xff)<<8)|(roomOnStopFrameSyncNotify.getMethodID()&0xff));
                roomOnStopFrameSyncNotify= null;
            }
        }

        public void onOnStartFrameSyncNotify(RoomOnStartFrameSyncNotify.OnStartFrameSyncNotify onStartFrameSyncNotify) {
            RoomOnStartFrameSyncNotify cls=new RoomOnStartFrameSyncNotify();
            cls.onStartFrameSyncNotify = onStartFrameSyncNotify;
            client.onNotify(cls);
            roomOnStartFrameSyncNotify= cls;
        }

        public void offOnStartFrameSyncNotify() {
            if (roomOnStartFrameSyncNotify != null){
                client.offNotify(((roomOnStartFrameSyncNotify.getClsID()&0xff)<<8)|(roomOnStartFrameSyncNotify.getMethodID()&0xff));
                roomOnStartFrameSyncNotify= null;
            }
        }

        public void onOnShutupNotify(RoomOnShutupNotify.OnShutupNotify onShutupNotify) {
            RoomOnShutupNotify cls=new RoomOnShutupNotify();
            cls.onShutupNotify = onShutupNotify;
            client.onNotify(cls);
            roomOnShutupNotify= cls;
        }

        public void offOnShutupNotify() {
            if (roomOnShutupNotify != null){
                client.offNotify(((roomOnShutupNotify.getClsID()&0xff)<<8)|(roomOnShutupNotify.getMethodID()&0xff));
                roomOnShutupNotify= null;
            }
        }

        public void onOnRoomStatusAndPropertiesChangedNotify(RoomOnRoomStatusAndPropertiesChangedNotify.OnRoomStatusAndPropertiesChangedNotify onRoomStatusAndPropertiesChangedNotify) {
            RoomOnRoomStatusAndPropertiesChangedNotify cls=new RoomOnRoomStatusAndPropertiesChangedNotify();
            cls.onRoomStatusAndPropertiesChangedNotify = onRoomStatusAndPropertiesChangedNotify;
            client.onNotify(cls);
            roomOnRoomStatusAndPropertiesChangedNotify= cls;
        }

        public void offOnRoomStatusAndPropertiesChangedNotify() {
            if (roomOnRoomStatusAndPropertiesChangedNotify != null){
                client.offNotify(((roomOnRoomStatusAndPropertiesChangedNotify.getClsID()&0xff)<<8)|(roomOnRoomStatusAndPropertiesChangedNotify.getMethodID()&0xff));
                roomOnRoomStatusAndPropertiesChangedNotify= null;
            }
        }

        public void onOnRemovePlayerNotify(RoomOnRemovePlayerNotify.OnRemovePlayerNotify onRemovePlayerNotify) {
            RoomOnRemovePlayerNotify cls=new RoomOnRemovePlayerNotify();
            cls.onRemovePlayerNotify = onRemovePlayerNotify;
            client.onNotify(cls);
            roomOnRemovePlayerNotify= cls;
        }

        public void offOnRemovePlayerNotify() {
            if (roomOnRemovePlayerNotify != null){
                client.offNotify(((roomOnRemovePlayerNotify.getClsID()&0xff)<<8)|(roomOnRemovePlayerNotify.getMethodID()&0xff));
                roomOnRemovePlayerNotify= null;
            }
        }

        public void onOnRecvFromTrialNotify(RoomOnRecvFromTrialNotify.OnRecvFromTrialNotify onRecvFromTrialNotify) {
            RoomOnRecvFromTrialNotify cls=new RoomOnRecvFromTrialNotify();
            cls.onRecvFromTrialNotify = onRecvFromTrialNotify;
            client.onNotify(cls);
            roomOnRecvFromTrialNotify= cls;
        }

        public void offOnRecvFromTrialNotify() {
            if (roomOnRecvFromTrialNotify != null){
                client.offNotify(((roomOnRecvFromTrialNotify.getClsID()&0xff)<<8)|(roomOnRecvFromTrialNotify.getMethodID()&0xff));
                roomOnRecvFromTrialNotify= null;
            }
        }

        public void onOnRecvFromClientNotify(RoomOnRecvFromClientNotify.OnRecvFromClientNotify onRecvFromClientNotify) {
            RoomOnRecvFromClientNotify cls=new RoomOnRecvFromClientNotify();
            cls.onRecvFromClientNotify = onRecvFromClientNotify;
            client.onNotify(cls);
            roomOnRecvFromClientNotify= cls;
        }

        public void offOnRecvFromClientNotify() {
            if (roomOnRecvFromClientNotify != null){
                client.offNotify(((roomOnRecvFromClientNotify.getClsID()&0xff)<<8)|(roomOnRecvFromClientNotify.getMethodID()&0xff));
                roomOnRecvFromClientNotify= null;
            }
        }

        public void onOnRecvFrameNotify(RoomOnRecvFrameNotify.OnRecvFrameNotify onRecvFrameNotify) {
            RoomOnRecvFrameNotify cls=new RoomOnRecvFrameNotify();
            cls.onRecvFrameNotify = onRecvFrameNotify;
            client.onNotify(cls);
            roomOnRecvFrameNotify= cls;
        }

        public void offOnRecvFrameNotify() {
            if (roomOnRecvFrameNotify != null){
                client.offNotify(((roomOnRecvFrameNotify.getClsID()&0xff)<<8)|(roomOnRecvFrameNotify.getMethodID()&0xff));
                roomOnRecvFrameNotify= null;
            }
        }

        public void onOnPlayerStatusAndPropertiesChangedNotify(RoomOnPlayerStatusAndPropertiesChangedNotify.OnPlayerStatusAndPropertiesChangedNotify onPlayerStatusAndPropertiesChangedNotify) {
            RoomOnPlayerStatusAndPropertiesChangedNotify cls=new RoomOnPlayerStatusAndPropertiesChangedNotify();
            cls.onPlayerStatusAndPropertiesChangedNotify = onPlayerStatusAndPropertiesChangedNotify;
            client.onNotify(cls);
            roomOnPlayerStatusAndPropertiesChangedNotify= cls;
        }

        public void offOnPlayerStatusAndPropertiesChangedNotify() {
            if (roomOnPlayerStatusAndPropertiesChangedNotify != null){
                client.offNotify(((roomOnPlayerStatusAndPropertiesChangedNotify.getClsID()&0xff)<<8)|(roomOnPlayerStatusAndPropertiesChangedNotify.getMethodID()&0xff));
                roomOnPlayerStatusAndPropertiesChangedNotify= null;
            }
        }

        public void onOnObjectStatusAndPropertiesChangedNotify(RoomOnObjectStatusAndPropertiesChangedNotify.OnObjectStatusAndPropertiesChangedNotify onObjectStatusAndPropertiesChangedNotify) {
            RoomOnObjectStatusAndPropertiesChangedNotify cls=new RoomOnObjectStatusAndPropertiesChangedNotify();
            cls.onObjectStatusAndPropertiesChangedNotify = onObjectStatusAndPropertiesChangedNotify;
            client.onNotify(cls);
            roomOnObjectStatusAndPropertiesChangedNotify= cls;
        }

        public void offOnObjectStatusAndPropertiesChangedNotify() {
            if (roomOnObjectStatusAndPropertiesChangedNotify != null){
                client.offNotify(((roomOnObjectStatusAndPropertiesChangedNotify.getClsID()&0xff)<<8)|(roomOnObjectStatusAndPropertiesChangedNotify.getMethodID()&0xff));
                roomOnObjectStatusAndPropertiesChangedNotify= null;
            }
        }

        public void onOnLeaveRoomNotify(RoomOnLeaveRoomNotify.OnLeaveRoomNotify onLeaveRoomNotify) {
            RoomOnLeaveRoomNotify cls=new RoomOnLeaveRoomNotify();
            cls.onLeaveRoomNotify = onLeaveRoomNotify;
            client.onNotify(cls);
            roomOnLeaveRoomNotify= cls;
        }

        public void offOnLeaveRoomNotify() {
            if (roomOnLeaveRoomNotify != null){
                client.offNotify(((roomOnLeaveRoomNotify.getClsID()&0xff)<<8)|(roomOnLeaveRoomNotify.getMethodID()&0xff));
                roomOnLeaveRoomNotify= null;
            }
        }

        public void onOnJoinRoomNotify(RoomOnJoinRoomNotify.OnJoinRoomNotify onJoinRoomNotify) {
            RoomOnJoinRoomNotify cls=new RoomOnJoinRoomNotify();
            cls.onJoinRoomNotify = onJoinRoomNotify;
            client.onNotify(cls);
            roomOnJoinRoomNotify= cls;
        }

        public void offOnJoinRoomNotify() {
            if (roomOnJoinRoomNotify != null){
                client.offNotify(((roomOnJoinRoomNotify.getClsID()&0xff)<<8)|(roomOnJoinRoomNotify.getMethodID()&0xff));
                roomOnJoinRoomNotify= null;
            }
        }

        public void onOnGameAwardNotify(RoomOnGameAwardNotify.OnGameAwardNotify onGameAwardNotify) {
            RoomOnGameAwardNotify cls=new RoomOnGameAwardNotify();
            cls.onGameAwardNotify = onGameAwardNotify;
            client.onNotify(cls);
            roomOnGameAwardNotify= cls;
        }

        public void offOnGameAwardNotify() {
            if (roomOnGameAwardNotify != null){
                client.offNotify(((roomOnGameAwardNotify.getClsID()&0xff)<<8)|(roomOnGameAwardNotify.getMethodID()&0xff));
                roomOnGameAwardNotify= null;
            }
        }

        public void onOnDismissRoomNotify(RoomOnDismissRoomNotify.OnDismissRoomNotify onDismissRoomNotify) {
            RoomOnDismissRoomNotify cls=new RoomOnDismissRoomNotify();
            cls.onDismissRoomNotify = onDismissRoomNotify;
            client.onNotify(cls);
            roomOnDismissRoomNotify= cls;
        }

        public void offOnDismissRoomNotify() {
            if (roomOnDismissRoomNotify != null){
                client.offNotify(((roomOnDismissRoomNotify.getClsID()&0xff)<<8)|(roomOnDismissRoomNotify.getMethodID()&0xff));
                roomOnDismissRoomNotify= null;
            }
        }

        public void onOnDestroyObjectNotify(RoomOnDestroyObjectNotify.OnDestroyObjectNotify onDestroyObjectNotify) {
            RoomOnDestroyObjectNotify cls=new RoomOnDestroyObjectNotify();
            cls.onDestroyObjectNotify = onDestroyObjectNotify;
            client.onNotify(cls);
            roomOnDestroyObjectNotify= cls;
        }

        public void offOnDestroyObjectNotify() {
            if (roomOnDestroyObjectNotify != null){
                client.offNotify(((roomOnDestroyObjectNotify.getClsID()&0xff)<<8)|(roomOnDestroyObjectNotify.getMethodID()&0xff));
                roomOnDestroyObjectNotify= null;
            }
        }

        public void onOnCreateObjectNotify(RoomOnCreateObjectNotify.OnCreateObjectNotify onCreateObjectNotify) {
            RoomOnCreateObjectNotify cls=new RoomOnCreateObjectNotify();
            cls.onCreateObjectNotify = onCreateObjectNotify;
            client.onNotify(cls);
            roomOnCreateObjectNotify= cls;
        }

        public void offOnCreateObjectNotify() {
            if (roomOnCreateObjectNotify != null){
                client.offNotify(((roomOnCreateObjectNotify.getClsID()&0xff)<<8)|(roomOnCreateObjectNotify.getMethodID()&0xff));
                roomOnCreateObjectNotify= null;
            }
        }

        public void onOnChangeRoomNotify(RoomOnChangeRoomNotify.OnChangeRoomNotify onChangeRoomNotify) {
            RoomOnChangeRoomNotify cls=new RoomOnChangeRoomNotify();
            cls.onChangeRoomNotify = onChangeRoomNotify;
            client.onNotify(cls);
            roomOnChangeRoomNotify= cls;
        }

        public void offOnChangeRoomNotify() {
            if (roomOnChangeRoomNotify != null){
                client.offNotify(((roomOnChangeRoomNotify.getClsID()&0xff)<<8)|(roomOnChangeRoomNotify.getMethodID()&0xff));
                roomOnChangeRoomNotify= null;
            }
        }

        public void onOnChangePlayerNetworkStateNotify(RoomOnChangePlayerNetworkStateNotify.OnChangePlayerNetworkStateNotify onChangePlayerNetworkStateNotify) {
            RoomOnChangePlayerNetworkStateNotify cls=new RoomOnChangePlayerNetworkStateNotify();
            cls.onChangePlayerNetworkStateNotify = onChangePlayerNetworkStateNotify;
            client.onNotify(cls);
            roomOnChangePlayerNetworkStateNotify= cls;
        }

        public void offOnChangePlayerNetworkStateNotify() {
            if (roomOnChangePlayerNetworkStateNotify != null){
                client.offNotify(((roomOnChangePlayerNetworkStateNotify.getClsID()&0xff)<<8)|(roomOnChangePlayerNetworkStateNotify.getMethodID()&0xff));
                roomOnChangePlayerNetworkStateNotify= null;
            }
        }

        public void onAutoRequestFrameError(RoomOnAutoRequestFrameErrorResponse.Success _s_ =  null, RoomOnAutoRequestFrameErrorResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomOnAutoRequestFrameErrorRequest req=new RoomOnAutoRequestFrameErrorRequest();
            client.send(req, new RoomOnAutoRequestFrameErrorResponse(_s_, _f_));
        }

        public void onNewGramophoneMsgNotify(RoomNewGramophoneMsgNotify.NewGramophoneMsgNotify newGramophoneMsgNotify) {
            RoomNewGramophoneMsgNotify cls=new RoomNewGramophoneMsgNotify();
            cls.newGramophoneMsgNotify = newGramophoneMsgNotify;
            client.onNotify(cls);
            roomNewGramophoneMsgNotify= cls;
        }

        public void offNewGramophoneMsgNotify() {
            if (roomNewGramophoneMsgNotify != null){
                client.offNotify(((roomNewGramophoneMsgNotify.getClsID()&0xff)<<8)|(roomNewGramophoneMsgNotify.getMethodID()&0xff));
                roomNewGramophoneMsgNotify= null;
            }
        }

        public void modifyRoomInfo(string roomName, bool isPrivate, string customProperties, bool isForbidJoin, RoomModifyRoomInfoResponse.Success _s_ =  null, RoomModifyRoomInfoResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomModifyRoomInfoRequest req=new RoomModifyRoomInfoRequest();
            req.roomName=roomName;
            req.isPrivate=isPrivate;
            req.customProperties=customProperties;
            req.isForbidJoin=isForbidJoin;
            client.send(req, new RoomModifyRoomInfoResponse(_s_, _f_));
        }

        public void leaveRoom(RoomLeaveRoomResponse.Success _s_ =  null, RoomLeaveRoomResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomLeaveRoomRequest req=new RoomLeaveRoomRequest();
            client.send(req, new RoomLeaveRoomResponse(_s_, _f_));
        }

        public void onKillNotify(RoomKillNotify.KillNotify killNotify) {
            RoomKillNotify cls=new RoomKillNotify();
            cls.killNotify = killNotify;
            client.onNotify(cls);
            roomKillNotify= cls;
        }

        public void offKillNotify() {
            if (roomKillNotify != null){
                client.offNotify(((roomKillNotify.getClsID()&0xff)<<8)|(roomKillNotify.getMethodID()&0xff));
                roomKillNotify= null;
            }
        }

        public void onHospitalSavePlayerNotify(RoomHospitalSavePlayerNotify.HospitalSavePlayerNotify hospitalSavePlayerNotify) {
            RoomHospitalSavePlayerNotify cls=new RoomHospitalSavePlayerNotify();
            cls.hospitalSavePlayerNotify = hospitalSavePlayerNotify;
            client.onNotify(cls);
            roomHospitalSavePlayerNotify= cls;
        }

        public void offHospitalSavePlayerNotify() {
            if (roomHospitalSavePlayerNotify != null){
                client.offNotify(((roomHospitalSavePlayerNotify.getClsID()&0xff)<<8)|(roomHospitalSavePlayerNotify.getMethodID()&0xff));
                roomHospitalSavePlayerNotify= null;
            }
        }

        public void hospitalSavePlayer(int type, int target, int addHp, RoomHospitalSavePlayerResponse.Success _s_ =  null, RoomHospitalSavePlayerResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomHospitalSavePlayerRequest req=new RoomHospitalSavePlayerRequest();
            req.type=type;
            req.target=target;
            req.addHp=addHp;
            client.send(req, new RoomHospitalSavePlayerResponse(_s_, _f_));
        }

        public void hospitalSaveObjectProperties(int monsterObjectId, List<PropertyValue> values, RoomHospitalSaveObjectPropertiesResponse.Success _s_ =  null, RoomHospitalSaveObjectPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomHospitalSaveObjectPropertiesRequest req=new RoomHospitalSaveObjectPropertiesRequest();
            req.monsterObjectId=monsterObjectId;
            req.values=values;
            client.send(req, new RoomHospitalSaveObjectPropertiesResponse(_s_, _f_));
        }

        public void onHospitalResultNotify(RoomHospitalResultNotify.HospitalResultNotify hospitalResultNotify) {
            RoomHospitalResultNotify cls=new RoomHospitalResultNotify();
            cls.hospitalResultNotify = hospitalResultNotify;
            client.onNotify(cls);
            roomHospitalResultNotify= cls;
        }

        public void offHospitalResultNotify() {
            if (roomHospitalResultNotify != null){
                client.offNotify(((roomHospitalResultNotify.getClsID()&0xff)<<8)|(roomHospitalResultNotify.getMethodID()&0xff));
                roomHospitalResultNotify= null;
            }
        }

        public void onHospitalPlayerDeadNotify(RoomHospitalPlayerDeadNotify.HospitalPlayerDeadNotify hospitalPlayerDeadNotify) {
            RoomHospitalPlayerDeadNotify cls=new RoomHospitalPlayerDeadNotify();
            cls.hospitalPlayerDeadNotify = hospitalPlayerDeadNotify;
            client.onNotify(cls);
            roomHospitalPlayerDeadNotify= cls;
        }

        public void offHospitalPlayerDeadNotify() {
            if (roomHospitalPlayerDeadNotify != null){
                client.offNotify(((roomHospitalPlayerDeadNotify.getClsID()&0xff)<<8)|(roomHospitalPlayerDeadNotify.getMethodID()&0xff));
                roomHospitalPlayerDeadNotify= null;
            }
        }

        public void hospitalPlayerAttack(int weaponId, int monsterObjectId, int damage, RoomHospitalPlayerAttackResponse.Success _s_ =  null, RoomHospitalPlayerAttackResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomHospitalPlayerAttackRequest req=new RoomHospitalPlayerAttackRequest();
            req.weaponId=weaponId;
            req.monsterObjectId=monsterObjectId;
            req.damage=damage;
            client.send(req, new RoomHospitalPlayerAttackResponse(_s_, _f_));
        }

        public void onHospitalPickNotify(RoomHospitalPickNotify.HospitalPickNotify hospitalPickNotify) {
            RoomHospitalPickNotify cls=new RoomHospitalPickNotify();
            cls.hospitalPickNotify = hospitalPickNotify;
            client.onNotify(cls);
            roomHospitalPickNotify= cls;
        }

        public void offHospitalPickNotify() {
            if (roomHospitalPickNotify != null){
                client.offNotify(((roomHospitalPickNotify.getClsID()&0xff)<<8)|(roomHospitalPickNotify.getMethodID()&0xff));
                roomHospitalPickNotify= null;
            }
        }

        public void hospitalPickItem(int monsterObjectId, int dropObjectId, RoomHospitalPickItemResponse.Success _s_ =  null, RoomHospitalPickItemResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomHospitalPickItemRequest req=new RoomHospitalPickItemRequest();
            req.monsterObjectId=monsterObjectId;
            req.dropObjectId=dropObjectId;
            client.send(req, new RoomHospitalPickItemResponse(_s_, _f_));
        }

        public void onHospitalMonsterNotify(RoomHospitalMonsterNotify.HospitalMonsterNotify hospitalMonsterNotify) {
            RoomHospitalMonsterNotify cls=new RoomHospitalMonsterNotify();
            cls.hospitalMonsterNotify = hospitalMonsterNotify;
            client.onNotify(cls);
            roomHospitalMonsterNotify= cls;
        }

        public void offHospitalMonsterNotify() {
            if (roomHospitalMonsterNotify != null){
                client.offNotify(((roomHospitalMonsterNotify.getClsID()&0xff)<<8)|(roomHospitalMonsterNotify.getMethodID()&0xff));
                roomHospitalMonsterNotify= null;
            }
        }

        public void onHospitalMonsterDeadNotify(RoomHospitalMonsterDeadNotify.HospitalMonsterDeadNotify hospitalMonsterDeadNotify) {
            RoomHospitalMonsterDeadNotify cls=new RoomHospitalMonsterDeadNotify();
            cls.hospitalMonsterDeadNotify = hospitalMonsterDeadNotify;
            client.onNotify(cls);
            roomHospitalMonsterDeadNotify= cls;
        }

        public void offHospitalMonsterDeadNotify() {
            if (roomHospitalMonsterDeadNotify != null){
                client.offNotify(((roomHospitalMonsterDeadNotify.getClsID()&0xff)<<8)|(roomHospitalMonsterDeadNotify.getMethodID()&0xff));
                roomHospitalMonsterDeadNotify= null;
            }
        }

        public void hospitalMonsterAttack(int monsterObjectId, int damage, RoomHospitalMonsterAttackResponse.Success _s_ =  null, RoomHospitalMonsterAttackResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomHospitalMonsterAttackRequest req=new RoomHospitalMonsterAttackRequest();
            req.monsterObjectId=monsterObjectId;
            req.damage=damage;
            client.send(req, new RoomHospitalMonsterAttackResponse(_s_, _f_));
        }

        public void onHospitalDropObjectExpireNotify(RoomHospitalDropObjectExpireNotify.HospitalDropObjectExpireNotify hospitalDropObjectExpireNotify) {
            RoomHospitalDropObjectExpireNotify cls=new RoomHospitalDropObjectExpireNotify();
            cls.hospitalDropObjectExpireNotify = hospitalDropObjectExpireNotify;
            client.onNotify(cls);
            roomHospitalDropObjectExpireNotify= cls;
        }

        public void offHospitalDropObjectExpireNotify() {
            if (roomHospitalDropObjectExpireNotify != null){
                client.offNotify(((roomHospitalDropObjectExpireNotify.getClsID()&0xff)<<8)|(roomHospitalDropObjectExpireNotify.getMethodID()&0xff));
                roomHospitalDropObjectExpireNotify= null;
            }
        }

        public void onHospitalDropItemNotify(RoomHospitalDropItemNotify.HospitalDropItemNotify hospitalDropItemNotify) {
            RoomHospitalDropItemNotify cls=new RoomHospitalDropItemNotify();
            cls.hospitalDropItemNotify = hospitalDropItemNotify;
            client.onNotify(cls);
            roomHospitalDropItemNotify= cls;
        }

        public void offHospitalDropItemNotify() {
            if (roomHospitalDropItemNotify != null){
                client.offNotify(((roomHospitalDropItemNotify.getClsID()&0xff)<<8)|(roomHospitalDropItemNotify.getMethodID()&0xff));
                roomHospitalDropItemNotify= null;
            }
        }

        public void onHospitalDamageNotify(RoomHospitalDamageNotify.HospitalDamageNotify hospitalDamageNotify) {
            RoomHospitalDamageNotify cls=new RoomHospitalDamageNotify();
            cls.hospitalDamageNotify = hospitalDamageNotify;
            client.onNotify(cls);
            roomHospitalDamageNotify= cls;
        }

        public void offHospitalDamageNotify() {
            if (roomHospitalDamageNotify != null){
                client.offNotify(((roomHospitalDamageNotify.getClsID()&0xff)<<8)|(roomHospitalDamageNotify.getMethodID()&0xff));
                roomHospitalDamageNotify= null;
            }
        }

        public void hospitalCreateMonster(int monsterId, int point, int num, RoomHospitalCreateMonsterResponse.Success _s_ =  null, RoomHospitalCreateMonsterResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomHospitalCreateMonsterRequest req=new RoomHospitalCreateMonsterRequest();
            req.monsterId=monsterId;
            req.point=point;
            req.num=num;
            client.send(req, new RoomHospitalCreateMonsterResponse(_s_, _f_));
        }

        public void onHomePhotoFramesUrlNotify(RoomHomePhotoFramesUrlNotify.HomePhotoFramesUrlNotify homePhotoFramesUrlNotify) {
            RoomHomePhotoFramesUrlNotify cls=new RoomHomePhotoFramesUrlNotify();
            cls.homePhotoFramesUrlNotify = homePhotoFramesUrlNotify;
            client.onNotify(cls);
            roomHomePhotoFramesUrlNotify= cls;
        }

        public void offHomePhotoFramesUrlNotify() {
            if (roomHomePhotoFramesUrlNotify != null){
                client.offNotify(((roomHomePhotoFramesUrlNotify.getClsID()&0xff)<<8)|(roomHomePhotoFramesUrlNotify.getMethodID()&0xff));
                roomHomePhotoFramesUrlNotify= null;
            }
        }

        public void getUserPhoto(RoomGetUserPhotoResponse.Success _s_ =  null, RoomGetUserPhotoResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetUserPhotoRequest req=new RoomGetUserPhotoRequest();
            client.send(req, new RoomGetUserPhotoResponse(_s_, _f_));
        }

        public void getTimeFromOriState(RoomGetTimeFromOriStateResponse.Success _s_ =  null, RoomGetTimeFromOriStateResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetTimeFromOriStateRequest req=new RoomGetTimeFromOriStateRequest();
            client.send(req, new RoomGetTimeFromOriStateResponse(_s_, _f_));
        }

        public void getThunderRoomInfo(RoomGetThunderRoomInfoResponse.Success _s_ =  null, RoomGetThunderRoomInfoResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetThunderRoomInfoRequest req=new RoomGetThunderRoomInfoRequest();
            client.send(req, new RoomGetThunderRoomInfoResponse(_s_, _f_));
        }

        public void getSpecialGuests(RoomGetSpecialGuestsResponse.Success _s_ =  null, RoomGetSpecialGuestsResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetSpecialGuestsRequest req=new RoomGetSpecialGuestsRequest();
            client.send(req, new RoomGetSpecialGuestsResponse(_s_, _f_));
        }

        public void getRoomTime(RoomGetRoomTimeResponse.Success _s_ =  null, RoomGetRoomTimeResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetRoomTimeRequest req=new RoomGetRoomTimeRequest();
            client.send(req, new RoomGetRoomTimeResponse(_s_, _f_));
        }

        public void getRoomInfo(int hallId, int roomId, RoomGetRoomInfoResponse.Success _s_ =  null, RoomGetRoomInfoResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetRoomInfoRequest req=new RoomGetRoomInfoRequest();
            req.hallId=hallId;
            req.roomId=roomId;
            client.send(req, new RoomGetRoomInfoResponse(_s_, _f_));
        }

        public void getRoomDetail(int roomID, RoomGetRoomDetailResponse.Success _s_ =  null, RoomGetRoomDetailResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetRoomDetailRequest req=new RoomGetRoomDetailRequest();
            req.roomID=roomID;
            client.send(req, new RoomGetRoomDetailResponse(_s_, _f_));
        }

        public void getHomePhotoFramesUrl(int userId, RoomGetHomePhotoFramesUrlResponse.Success _s_ =  null, RoomGetHomePhotoFramesUrlResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetHomePhotoFramesUrlRequest req=new RoomGetHomePhotoFramesUrlRequest();
            req.userId=userId;
            client.send(req, new RoomGetHomePhotoFramesUrlResponse(_s_, _f_));
        }

        public void getFreeSubRoom(int hallId, int roomId, string roomType, RoomGetFreeSubRoomResponse.Success _s_ =  null, RoomGetFreeSubRoomResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetFreeSubRoomRequest req=new RoomGetFreeSubRoomRequest();
            req.hallId=hallId;
            req.roomId=roomId;
            req.roomType=roomType;
            client.send(req, new RoomGetFreeSubRoomResponse(_s_, _f_));
        }

        public void getChorusMembers(RoomGetChorusMembersResponse.Success _s_ =  null, RoomGetChorusMembersResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGetChorusMembersRequest req=new RoomGetChorusMembersRequest();
            client.send(req, new RoomGetChorusMembersResponse(_s_, _f_));
        }

        public void gameOut(RoomGameOutResponse.Success _s_ =  null, RoomGameOutResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomGameOutRequest req=new RoomGameOutRequest();
            client.send(req, new RoomGameOutResponse(_s_, _f_));
        }

        public void exitToHall(RoomExitToHallResponse.Success _s_ =  null, RoomExitToHallResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomExitToHallRequest req=new RoomExitToHallRequest();
            client.send(req, new RoomExitToHallResponse(_s_, _f_));
        }

        public void enterRoom(ERoomPlayer player, int hallId, int roomId, long enterTime, RoomEnterRoomResponse.Success _s_ =  null, RoomEnterRoomResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomEnterRoomRequest req=new RoomEnterRoomRequest();
            req.player=player;
            req.hallId=hallId;
            req.roomId=roomId;
            req.enterTime=enterTime;
            client.send(req, new RoomEnterRoomResponse(_s_, _f_));
        }

        public void dismissRoom(RoomDismissRoomResponse.Success _s_ =  null, RoomDismissRoomResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomDismissRoomRequest req=new RoomDismissRoomRequest();
            client.send(req, new RoomDismissRoomResponse(_s_, _f_));
        }

        public void destroyObject(int objId, RoomDestroyObjectResponse.Success _s_ =  null, RoomDestroyObjectResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomDestroyObjectRequest req=new RoomDestroyObjectRequest();
            req.objId=objId;
            client.send(req, new RoomDestroyObjectResponse(_s_, _f_));
        }

        public void destroyAllObjects(RoomDestroyAllObjectsResponse.Success _s_ =  null, RoomDestroyAllObjectsResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomDestroyAllObjectsRequest req=new RoomDestroyAllObjectsRequest();
            client.send(req, new RoomDestroyAllObjectsResponse(_s_, _f_));
        }

        public void deleteSpecialGuest(int userId, RoomDeleteSpecialGuestResponse.Success _s_ =  null, RoomDeleteSpecialGuestResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomDeleteSpecialGuestRequest req=new RoomDeleteSpecialGuestRequest();
            req.userId=userId;
            client.send(req, new RoomDeleteSpecialGuestResponse(_s_, _f_));
        }

        public void onDeleteGramophoneMsgNotify(RoomDeleteGramophoneMsgNotify.DeleteGramophoneMsgNotify deleteGramophoneMsgNotify) {
            RoomDeleteGramophoneMsgNotify cls=new RoomDeleteGramophoneMsgNotify();
            cls.deleteGramophoneMsgNotify = deleteGramophoneMsgNotify;
            client.onNotify(cls);
            roomDeleteGramophoneMsgNotify= cls;
        }

        public void offDeleteGramophoneMsgNotify() {
            if (roomDeleteGramophoneMsgNotify != null){
                client.offNotify(((roomDeleteGramophoneMsgNotify.getClsID()&0xff)<<8)|(roomDeleteGramophoneMsgNotify.getMethodID()&0xff));
                roomDeleteGramophoneMsgNotify= null;
            }
        }

        public void deleteChorusMember(int userId, RoomDeleteChorusMemberResponse.Success _s_ =  null, RoomDeleteChorusMemberResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomDeleteChorusMemberRequest req=new RoomDeleteChorusMemberRequest();
            req.userId=userId;
            client.send(req, new RoomDeleteChorusMemberResponse(_s_, _f_));
        }

        public void deepEternityOver(int level, RoomDeepEternityOverResponse.Success _s_ =  null, RoomDeepEternityOverResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomDeepEternityOverRequest req=new RoomDeepEternityOverRequest();
            req.level=level;
            client.send(req, new RoomDeepEternityOverResponse(_s_, _f_));
        }

        public void deepAddMaterial(int level, int num, RoomDeepAddMaterialResponse.Success _s_ =  null, RoomDeepAddMaterialResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomDeepAddMaterialRequest req=new RoomDeepAddMaterialRequest();
            req.level=level;
            req.num=num;
            client.send(req, new RoomDeepAddMaterialResponse(_s_, _f_));
        }

        public void deepAddGuluCoin(int level, int num, RoomDeepAddGuluCoinResponse.Success _s_ =  null, RoomDeepAddGuluCoinResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomDeepAddGuluCoinRequest req=new RoomDeepAddGuluCoinRequest();
            req.level=level;
            req.num=num;
            client.send(req, new RoomDeepAddGuluCoinResponse(_s_, _f_));
        }

        public void onDeadNotify(RoomDeadNotify.DeadNotify deadNotify) {
            RoomDeadNotify cls=new RoomDeadNotify();
            cls.deadNotify = deadNotify;
            client.onNotify(cls);
            roomDeadNotify= cls;
        }

        public void offDeadNotify() {
            if (roomDeadNotify != null){
                client.offNotify(((roomDeadNotify.getClsID()&0xff)<<8)|(roomDeadNotify.getMethodID()&0xff));
                roomDeadNotify= null;
            }
        }

        public void createSubTempRooms(int num, int maxPlayers, RoomCreateSubTempRoomsResponse.Success _s_ =  null, RoomCreateSubTempRoomsResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomCreateSubTempRoomsRequest req=new RoomCreateSubTempRoomsRequest();
            req.num=num;
            req.maxPlayers=maxPlayers;
            client.send(req, new RoomCreateSubTempRoomsResponse(_s_, _f_));
        }

        public void createSubTempRoom(int maxPlayers, RoomCreateSubTempRoomResponse.Success _s_ =  null, RoomCreateSubTempRoomResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomCreateSubTempRoomRequest req=new RoomCreateSubTempRoomRequest();
            req.maxPlayers=maxPlayers;
            client.send(req, new RoomCreateSubTempRoomResponse(_s_, _f_));
        }

        public void createSubRooms(int num, string roomName, string roomType, int maxPlayers, bool isAutoDestroy, bool isPrivate, List<PropertyValue> hallRoomInfo, RoomCreateSubRoomsResponse.Success _s_ =  null, RoomCreateSubRoomsResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomCreateSubRoomsRequest req=new RoomCreateSubRoomsRequest();
            req.num=num;
            req.roomName=roomName;
            req.roomType=roomType;
            req.maxPlayers=maxPlayers;
            req.isAutoDestroy=isAutoDestroy;
            req.isPrivate=isPrivate;
            req.hallRoomInfo=hallRoomInfo;
            client.send(req, new RoomCreateSubRoomsResponse(_s_, _f_));
        }

        public void createSubRoom(string roomName, string roomType, int maxPlayers, bool isAutoDestroy, bool isPrivate, List<PropertyValue> hallRoomInfo, RoomCreateSubRoomResponse.Success _s_ =  null, RoomCreateSubRoomResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomCreateSubRoomRequest req=new RoomCreateSubRoomRequest();
            req.roomName=roomName;
            req.roomType=roomType;
            req.maxPlayers=maxPlayers;
            req.isAutoDestroy=isAutoDestroy;
            req.isPrivate=isPrivate;
            req.hallRoomInfo=hallRoomInfo;
            client.send(req, new RoomCreateSubRoomResponse(_s_, _f_));
        }

        public void createObjects(List<ERoomObject> objs, RoomCreateObjectsResponse.Success _s_ =  null, RoomCreateObjectsResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomCreateObjectsRequest req=new RoomCreateObjectsRequest();
            req.objs=objs;
            client.send(req, new RoomCreateObjectsResponse(_s_, _f_));
        }

        public void createObject(string name, int oriStatus, List<PropertyValue> values, RoomCreateObjectResponse.Success _s_ =  null, RoomCreateObjectResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomCreateObjectRequest req=new RoomCreateObjectRequest();
            req.name=name;
            req.oriStatus=oriStatus;
            req.values=values;
            client.send(req, new RoomCreateObjectResponse(_s_, _f_));
        }

        public void clearSpecialGuests(RoomClearSpecialGuestsResponse.Success _s_ =  null, RoomClearSpecialGuestsResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomClearSpecialGuestsRequest req=new RoomClearSpecialGuestsRequest();
            client.send(req, new RoomClearSpecialGuestsResponse(_s_, _f_));
        }

        public void clearChorusMember(RoomClearChorusMemberResponse.Success _s_ =  null, RoomClearChorusMemberResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomClearChorusMemberRequest req=new RoomClearChorusMemberRequest();
            client.send(req, new RoomClearChorusMemberResponse(_s_, _f_));
        }

        public void onChorusMemberNotify(RoomChorusMemberNotify.ChorusMemberNotify chorusMemberNotify) {
            RoomChorusMemberNotify cls=new RoomChorusMemberNotify();
            cls.chorusMemberNotify = chorusMemberNotify;
            client.onNotify(cls);
            roomChorusMemberNotify= cls;
        }

        public void offChorusMemberNotify() {
            if (roomChorusMemberNotify != null){
                client.offNotify(((roomChorusMemberNotify.getClsID()&0xff)<<8)|(roomChorusMemberNotify.getMethodID()&0xff));
                roomChorusMemberNotify= null;
            }
        }

        public void changeRoomStatusAndProperty(int oriStatus, int dstStatus, PropertyValue value, RoomChangeRoomStatusAndPropertyResponse.Success _s_ =  null, RoomChangeRoomStatusAndPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeRoomStatusAndPropertyRequest req=new RoomChangeRoomStatusAndPropertyRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.value=value;
            client.send(req, new RoomChangeRoomStatusAndPropertyResponse(_s_, _f_));
        }

        public void changeRoomStatusAndProperties(int oriStatus, int dstStatus, List<PropertyValue> values, RoomChangeRoomStatusAndPropertiesResponse.Success _s_ =  null, RoomChangeRoomStatusAndPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeRoomStatusAndPropertiesRequest req=new RoomChangeRoomStatusAndPropertiesRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.values=values;
            client.send(req, new RoomChangeRoomStatusAndPropertiesResponse(_s_, _f_));
        }

        public void changeRoomStatus(int oriStatus, int dstStatus, RoomChangeRoomStatusResponse.Success _s_ =  null, RoomChangeRoomStatusResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeRoomStatusRequest req=new RoomChangeRoomStatusRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            client.send(req, new RoomChangeRoomStatusResponse(_s_, _f_));
        }

        public void changeRoomProperty(PropertyValue value, RoomChangeRoomPropertyResponse.Success _s_ =  null, RoomChangeRoomPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeRoomPropertyRequest req=new RoomChangeRoomPropertyRequest();
            req.value=value;
            client.send(req, new RoomChangeRoomPropertyResponse(_s_, _f_));
        }

        public void changeRoomProperties(List<PropertyValue> values, RoomChangeRoomPropertiesResponse.Success _s_ =  null, RoomChangeRoomPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeRoomPropertiesRequest req=new RoomChangeRoomPropertiesRequest();
            req.values=values;
            client.send(req, new RoomChangeRoomPropertiesResponse(_s_, _f_));
        }

        public void changePlayerStatusAndProperty(int playerStatus, PropertyValue value, RoomChangePlayerStatusAndPropertyResponse.Success _s_ =  null, RoomChangePlayerStatusAndPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangePlayerStatusAndPropertyRequest req=new RoomChangePlayerStatusAndPropertyRequest();
            req.playerStatus=playerStatus;
            req.value=value;
            client.send(req, new RoomChangePlayerStatusAndPropertyResponse(_s_, _f_));
        }

        public void changePlayerStatusAndProperties(int playerStatus, List<PropertyValue> values, RoomChangePlayerStatusAndPropertiesResponse.Success _s_ =  null, RoomChangePlayerStatusAndPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangePlayerStatusAndPropertiesRequest req=new RoomChangePlayerStatusAndPropertiesRequest();
            req.playerStatus=playerStatus;
            req.values=values;
            client.send(req, new RoomChangePlayerStatusAndPropertiesResponse(_s_, _f_));
        }

        public void changePlayerStatus(int playerStatus, RoomChangePlayerStatusResponse.Success _s_ =  null, RoomChangePlayerStatusResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangePlayerStatusRequest req=new RoomChangePlayerStatusRequest();
            req.playerStatus=playerStatus;
            client.send(req, new RoomChangePlayerStatusResponse(_s_, _f_));
        }

        public void changePlayerProperty(PropertyValue value, RoomChangePlayerPropertyResponse.Success _s_ =  null, RoomChangePlayerPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangePlayerPropertyRequest req=new RoomChangePlayerPropertyRequest();
            req.value=value;
            client.send(req, new RoomChangePlayerPropertyResponse(_s_, _f_));
        }

        public void changePlayerProperties(List<PropertyValue> values, RoomChangePlayerPropertiesResponse.Success _s_ =  null, RoomChangePlayerPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangePlayerPropertiesRequest req=new RoomChangePlayerPropertiesRequest();
            req.values=values;
            client.send(req, new RoomChangePlayerPropertiesResponse(_s_, _f_));
        }

        public void changeObjectStatusAndProperty(int objId, int oriStatus, int dstStatus, PropertyValue value, RoomChangeObjectStatusAndPropertyResponse.Success _s_ =  null, RoomChangeObjectStatusAndPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeObjectStatusAndPropertyRequest req=new RoomChangeObjectStatusAndPropertyRequest();
            req.objId=objId;
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.value=value;
            client.send(req, new RoomChangeObjectStatusAndPropertyResponse(_s_, _f_));
        }

        public void changeObjectStatusAndProperties(int objId, int oriStatus, int dstStatus, List<PropertyValue> values, RoomChangeObjectStatusAndPropertiesResponse.Success _s_ =  null, RoomChangeObjectStatusAndPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeObjectStatusAndPropertiesRequest req=new RoomChangeObjectStatusAndPropertiesRequest();
            req.objId=objId;
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.values=values;
            client.send(req, new RoomChangeObjectStatusAndPropertiesResponse(_s_, _f_));
        }

        public void changeObjectStatus(int objId, int oriStatus, int dstStatus, RoomChangeObjectStatusResponse.Success _s_ =  null, RoomChangeObjectStatusResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeObjectStatusRequest req=new RoomChangeObjectStatusRequest();
            req.objId=objId;
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            client.send(req, new RoomChangeObjectStatusResponse(_s_, _f_));
        }

        public void changeObjectProperty(int objId, PropertyValue value, RoomChangeObjectPropertyResponse.Success _s_ =  null, RoomChangeObjectPropertyResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeObjectPropertyRequest req=new RoomChangeObjectPropertyRequest();
            req.objId=objId;
            req.value=value;
            client.send(req, new RoomChangeObjectPropertyResponse(_s_, _f_));
        }

        public void changeObjectProperties(int objId, List<PropertyValue> values, RoomChangeObjectPropertiesResponse.Success _s_ =  null, RoomChangeObjectPropertiesResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomChangeObjectPropertiesRequest req=new RoomChangeObjectPropertiesRequest();
            req.objId=objId;
            req.values=values;
            client.send(req, new RoomChangeObjectPropertiesResponse(_s_, _f_));
        }

        public void batchAddSpecialGuest(List<SpecialGuestInfo> list, RoomBatchAddSpecialGuestResponse.Success _s_ =  null, RoomBatchAddSpecialGuestResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomBatchAddSpecialGuestRequest req=new RoomBatchAddSpecialGuestRequest();
            req.list=list;
            client.send(req, new RoomBatchAddSpecialGuestResponse(_s_, _f_));
        }

        public void autoTrialToAll(short type, int id, byte[] msg, int delay, RoomAutoTrialToAllResponse.Success _s_ =  null, RoomAutoTrialToAllResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomAutoTrialToAllRequest req=new RoomAutoTrialToAllRequest();
            req.type=type;
            req.id=id;
            req.msg=msg;
            req.delay=delay;
            client.send(req, new RoomAutoTrialToAllResponse(_s_, _f_));
        }

        public void autoSendToAll(short type, byte[] msg, int delay, RoomAutoSendToAllResponse.Success _s_ =  null, RoomAutoSendToAllResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomAutoSendToAllRequest req=new RoomAutoSendToAllRequest();
            req.type=type;
            req.msg=msg;
            req.delay=delay;
            client.send(req, new RoomAutoSendToAllResponse(_s_, _f_));
        }

        public void autoChangeRoomStatus(int oriStatus, int dstStatus, int delay, RoomAutoChangeRoomStatusResponse.Success _s_ =  null, RoomAutoChangeRoomStatusResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomAutoChangeRoomStatusRequest req=new RoomAutoChangeRoomStatusRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.delay=delay;
            client.send(req, new RoomAutoChangeRoomStatusResponse(_s_, _f_));
        }

        public void attack(int round, int enemy, int weaponId, int damage, RoomAttackResponse.Success _s_ =  null, RoomAttackResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomAttackRequest req=new RoomAttackRequest();
            req.round=round;
            req.enemy=enemy;
            req.weaponId=weaponId;
            req.damage=damage;
            client.send(req, new RoomAttackResponse(_s_, _f_));
        }

        public void onAiLevelNotify(RoomAiLevelNotify.AiLevelNotify aiLevelNotify) {
            RoomAiLevelNotify cls=new RoomAiLevelNotify();
            cls.aiLevelNotify = aiLevelNotify;
            client.onNotify(cls);
            roomAiLevelNotify= cls;
        }

        public void offAiLevelNotify() {
            if (roomAiLevelNotify != null){
                client.offNotify(((roomAiLevelNotify.getClsID()&0xff)<<8)|(roomAiLevelNotify.getMethodID()&0xff));
                roomAiLevelNotify= null;
            }
        }

        public void onAiIdChangedNotify(RoomAiIdChangedNotify.AiIdChangedNotify aiIdChangedNotify) {
            RoomAiIdChangedNotify cls=new RoomAiIdChangedNotify();
            cls.aiIdChangedNotify = aiIdChangedNotify;
            client.onNotify(cls);
            roomAiIdChangedNotify= cls;
        }

        public void offAiIdChangedNotify() {
            if (roomAiIdChangedNotify != null){
                client.offNotify(((roomAiIdChangedNotify.getClsID()&0xff)<<8)|(roomAiIdChangedNotify.getMethodID()&0xff));
                roomAiIdChangedNotify= null;
            }
        }

        public void addSpecialGuest(SpecialGuestInfo guestInfo, RoomAddSpecialGuestResponse.Success _s_ =  null, RoomAddSpecialGuestResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomAddSpecialGuestRequest req=new RoomAddSpecialGuestRequest();
            req.guestInfo=guestInfo;
            client.send(req, new RoomAddSpecialGuestResponse(_s_, _f_));
        }

        public void addScore(int addScore, RoomAddScoreResponse.Success _s_ =  null, RoomAddScoreResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomAddScoreRequest req=new RoomAddScoreRequest();
            req.addScore=addScore;
            client.send(req, new RoomAddScoreResponse(_s_, _f_));
        }

        public void addChorusMember(ChorusMember memberInfo, RoomAddChorusMemberResponse.Success _s_ =  null, RoomAddChorusMemberResponse.Fail _f_ =  null) {
            if (isSendClose) return;
            RoomAddChorusMemberRequest req=new RoomAddChorusMemberRequest();
            req.memberInfo=memberInfo;
            client.send(req, new RoomAddChorusMemberResponse(_s_, _f_));
        }
    }
}

