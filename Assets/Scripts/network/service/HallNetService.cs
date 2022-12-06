using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class HallNetService {
        public static HallNetService ins = new HallNetService();

        NodeClient client;

        HallTitleNotify hallTitleNotify;

        HallStreetSetPannelNotify hallStreetSetPannelNotify;

        HallStartShowPlayBallNotify hallStartShowPlayBallNotify;

        HallStartShowNotify hallStartShowNotify;

        HallStartAnswerNotify hallStartAnswerNotify;

        HallServerRestartNotify hallServerRestartNotify;

        HallOperationKTVNotify hallOperationKTVNotify;

        HallOpenShowNotify hallOpenShowNotify;

        HallOpenActivityNotify hallOpenActivityNotify;

        HallOnNewRoomNotify hallOnNewRoomNotify;

        HallOnDismissRoomNotify hallOnDismissRoomNotify;

        HallModifyGuessGamePlayerNotify hallModifyGuessGamePlayerNotify;

        HallMatchSuccessNotify hallMatchSuccessNotify;

        HallMatchFailNotify hallMatchFailNotify;

        HallKtvRoomTimeoutWarnNotify hallKtvRoomTimeoutWarnNotify;

        HallKickoutFromKTVRoomNotify hallKickoutFromKTVRoomNotify;

        HallEndShowNotify hallEndShowNotify;

        public HallNetService() {
            client =NodeClient.get("HallNetService");
        }

        public void vote(int userId, int num, HallVoteResponse.Success _s_ =  null, HallVoteResponse.Fail _f_ =  null) {
            HallVoteRequest req=new HallVoteRequest();
            req.userId=userId;
            req.num=num;
            client.send(req, new HallVoteResponse(_s_, _f_));
        }

        public void onTitleNotify(HallTitleNotify.TitleNotify titleNotify) {
            HallTitleNotify cls=new HallTitleNotify();
            cls.titleNotify = titleNotify;
            client.onNotify(cls);
            hallTitleNotify= cls;
        }

        public void offTitleNotify() {
            if (hallTitleNotify != null){
                client.offNotify(((hallTitleNotify.getClsID()&0xff)<<8)|(hallTitleNotify.getMethodID()&0xff));
                hallTitleNotify= null;
            }
        }

        public void onStreetSetPannelNotify(HallStreetSetPannelNotify.StreetSetPannelNotify streetSetPannelNotify) {
            HallStreetSetPannelNotify cls=new HallStreetSetPannelNotify();
            cls.streetSetPannelNotify = streetSetPannelNotify;
            client.onNotify(cls);
            hallStreetSetPannelNotify= cls;
        }

        public void offStreetSetPannelNotify() {
            if (hallStreetSetPannelNotify != null){
                client.offNotify(((hallStreetSetPannelNotify.getClsID()&0xff)<<8)|(hallStreetSetPannelNotify.getMethodID()&0xff));
                hallStreetSetPannelNotify= null;
            }
        }

        public void stopShowPlayBallSchedule(HallStopShowPlayBallScheduleResponse.Success _s_ =  null, HallStopShowPlayBallScheduleResponse.Fail _f_ =  null) {
            HallStopShowPlayBallScheduleRequest req=new HallStopShowPlayBallScheduleRequest();
            client.send(req, new HallStopShowPlayBallScheduleResponse(_s_, _f_));
        }

        public void startVote(VoteInfo voteInfo, HallStartVoteResponse.Success _s_ =  null, HallStartVoteResponse.Fail _f_ =  null) {
            HallStartVoteRequest req=new HallStartVoteRequest();
            req.voteInfo=voteInfo;
            client.send(req, new HallStartVoteResponse(_s_, _f_));
        }

        public void startShowPlayBallSchedule(HallStartShowPlayBallScheduleResponse.Success _s_ =  null, HallStartShowPlayBallScheduleResponse.Fail _f_ =  null) {
            HallStartShowPlayBallScheduleRequest req=new HallStartShowPlayBallScheduleRequest();
            client.send(req, new HallStartShowPlayBallScheduleResponse(_s_, _f_));
        }

        public void onStartShowPlayBallNotify(HallStartShowPlayBallNotify.StartShowPlayBallNotify startShowPlayBallNotify) {
            HallStartShowPlayBallNotify cls=new HallStartShowPlayBallNotify();
            cls.startShowPlayBallNotify = startShowPlayBallNotify;
            client.onNotify(cls);
            hallStartShowPlayBallNotify= cls;
        }

        public void offStartShowPlayBallNotify() {
            if (hallStartShowPlayBallNotify != null){
                client.offNotify(((hallStartShowPlayBallNotify.getClsID()&0xff)<<8)|(hallStartShowPlayBallNotify.getMethodID()&0xff));
                hallStartShowPlayBallNotify= null;
            }
        }

        public void onStartShowNotify(HallStartShowNotify.StartShowNotify startShowNotify) {
            HallStartShowNotify cls=new HallStartShowNotify();
            cls.startShowNotify = startShowNotify;
            client.onNotify(cls);
            hallStartShowNotify= cls;
        }

        public void offStartShowNotify() {
            if (hallStartShowNotify != null){
                client.offNotify(((hallStartShowNotify.getClsID()&0xff)<<8)|(hallStartShowNotify.getMethodID()&0xff));
                hallStartShowNotify= null;
            }
        }

        public void onStartAnswerNotify(HallStartAnswerNotify.StartAnswerNotify startAnswerNotify) {
            HallStartAnswerNotify cls=new HallStartAnswerNotify();
            cls.startAnswerNotify = startAnswerNotify;
            client.onNotify(cls);
            hallStartAnswerNotify= cls;
        }

        public void offStartAnswerNotify() {
            if (hallStartAnswerNotify != null){
                client.offNotify(((hallStartAnswerNotify.getClsID()&0xff)<<8)|(hallStartAnswerNotify.getMethodID()&0xff));
                hallStartAnswerNotify= null;
            }
        }

        public void startAnswer(HallStartAnswerResponse.Success _s_ =  null, HallStartAnswerResponse.Fail _f_ =  null) {
            HallStartAnswerRequest req=new HallStartAnswerRequest();
            client.send(req, new HallStartAnswerResponse(_s_, _f_));
        }

        public void setTitle(int type, int userId, int titleId, HallSetTitleResponse.Success _s_ =  null, HallSetTitleResponse.Fail _f_ =  null) {
            HallSetTitleRequest req=new HallSetTitleRequest();
            req.type=type;
            req.userId=userId;
            req.titleId=titleId;
            client.send(req, new HallSetTitleResponse(_s_, _f_));
        }

        public void setShowPlayerSound(PlayerSoundInfo val, HallSetShowPlayerSoundResponse.Success _s_ =  null, HallSetShowPlayerSoundResponse.Fail _f_ =  null) {
            HallSetShowPlayerSoundRequest req=new HallSetShowPlayerSoundRequest();
            req.val=val;
            client.send(req, new HallSetShowPlayerSoundResponse(_s_, _f_));
        }

        public void setDeepLevel(int level, HallSetDeepLevelResponse.Success _s_ =  null, HallSetDeepLevelResponse.Fail _f_ =  null) {
            HallSetDeepLevelRequest req=new HallSetDeepLevelRequest();
            req.level=level;
            client.send(req, new HallSetDeepLevelResponse(_s_, _f_));
        }

        public void onServerRestartNotify(HallServerRestartNotify.ServerRestartNotify serverRestartNotify) {
            HallServerRestartNotify cls=new HallServerRestartNotify();
            cls.serverRestartNotify = serverRestartNotify;
            client.onNotify(cls);
            hallServerRestartNotify= cls;
        }

        public void offServerRestartNotify() {
            if (hallServerRestartNotify != null){
                client.offNotify(((hallServerRestartNotify.getClsID()&0xff)<<8)|(hallServerRestartNotify.getMethodID()&0xff));
                hallServerRestartNotify= null;
            }
        }

        public void scoring(ScoringInfo scoringInfo, HallScoringResponse.Success _s_ =  null, HallScoringResponse.Fail _f_ =  null) {
            HallScoringRequest req=new HallScoringRequest();
            req.scoringInfo=scoringInfo;
            client.send(req, new HallScoringResponse(_s_, _f_));
        }

        public void rechargeKTVRoom(int roomId, int coinType, HallRechargeKTVRoomResponse.Success _s_ =  null, HallRechargeKTVRoomResponse.Fail _f_ =  null) {
            HallRechargeKTVRoomRequest req=new HallRechargeKTVRoomRequest();
            req.roomId=roomId;
            req.coinType=coinType;
            client.send(req, new HallRechargeKTVRoomResponse(_s_, _f_));
        }

        public void randomDropItem(int dropId, int objId, HallRandomDropItemResponse.Success _s_ =  null, HallRandomDropItemResponse.Fail _f_ =  null) {
            HallRandomDropItemRequest req=new HallRandomDropItemRequest();
            req.dropId=dropId;
            req.objId=objId;
            client.send(req, new HallRandomDropItemResponse(_s_, _f_));
        }

        public void preEnterRoom(int hallId, int roomId, HallPreEnterRoomResponse.Success _s_ =  null, HallPreEnterRoomResponse.Fail _f_ =  null) {
            HallPreEnterRoomRequest req=new HallPreEnterRoomRequest();
            req.hallId=hallId;
            req.roomId=roomId;
            client.send(req, new HallPreEnterRoomResponse(_s_, _f_));
        }

        public void onOperationKTVNotify(HallOperationKTVNotify.OperationKTVNotify operationKTVNotify) {
            HallOperationKTVNotify cls=new HallOperationKTVNotify();
            cls.operationKTVNotify = operationKTVNotify;
            client.onNotify(cls);
            hallOperationKTVNotify= cls;
        }

        public void offOperationKTVNotify() {
            if (hallOperationKTVNotify != null){
                client.offNotify(((hallOperationKTVNotify.getClsID()&0xff)<<8)|(hallOperationKTVNotify.getMethodID()&0xff));
                hallOperationKTVNotify= null;
            }
        }

        public void onOpenShowNotify(HallOpenShowNotify.OpenShowNotify openShowNotify) {
            HallOpenShowNotify cls=new HallOpenShowNotify();
            cls.openShowNotify = openShowNotify;
            client.onNotify(cls);
            hallOpenShowNotify= cls;
        }

        public void offOpenShowNotify() {
            if (hallOpenShowNotify != null){
                client.offNotify(((hallOpenShowNotify.getClsID()&0xff)<<8)|(hallOpenShowNotify.getMethodID()&0xff));
                hallOpenShowNotify= null;
            }
        }

        public void onOpenActivityNotify(HallOpenActivityNotify.OpenActivityNotify openActivityNotify) {
            HallOpenActivityNotify cls=new HallOpenActivityNotify();
            cls.openActivityNotify = openActivityNotify;
            client.onNotify(cls);
            hallOpenActivityNotify= cls;
        }

        public void offOpenActivityNotify() {
            if (hallOpenActivityNotify != null){
                client.offNotify(((hallOpenActivityNotify.getClsID()&0xff)<<8)|(hallOpenActivityNotify.getMethodID()&0xff));
                hallOpenActivityNotify= null;
            }
        }

        public void onOnNewRoomNotify(HallOnNewRoomNotify.OnNewRoomNotify onNewRoomNotify) {
            HallOnNewRoomNotify cls=new HallOnNewRoomNotify();
            cls.onNewRoomNotify = onNewRoomNotify;
            client.onNotify(cls);
            hallOnNewRoomNotify= cls;
        }

        public void offOnNewRoomNotify() {
            if (hallOnNewRoomNotify != null){
                client.offNotify(((hallOnNewRoomNotify.getClsID()&0xff)<<8)|(hallOnNewRoomNotify.getMethodID()&0xff));
                hallOnNewRoomNotify= null;
            }
        }

        public void onOnDismissRoomNotify(HallOnDismissRoomNotify.OnDismissRoomNotify onDismissRoomNotify) {
            HallOnDismissRoomNotify cls=new HallOnDismissRoomNotify();
            cls.onDismissRoomNotify = onDismissRoomNotify;
            client.onNotify(cls);
            hallOnDismissRoomNotify= cls;
        }

        public void offOnDismissRoomNotify() {
            if (hallOnDismissRoomNotify != null){
                client.offNotify(((hallOnDismissRoomNotify.getClsID()&0xff)<<8)|(hallOnDismissRoomNotify.getMethodID()&0xff));
                hallOnDismissRoomNotify= null;
            }
        }

        public void modifyVote(int userId, int num, HallModifyVoteResponse.Success _s_ =  null, HallModifyVoteResponse.Fail _f_ =  null) {
            HallModifyVoteRequest req=new HallModifyVoteRequest();
            req.userId=userId;
            req.num=num;
            client.send(req, new HallModifyVoteResponse(_s_, _f_));
        }

        public void onModifyGuessGamePlayerNotify(HallModifyGuessGamePlayerNotify.ModifyGuessGamePlayerNotify modifyGuessGamePlayerNotify) {
            HallModifyGuessGamePlayerNotify cls=new HallModifyGuessGamePlayerNotify();
            cls.modifyGuessGamePlayerNotify = modifyGuessGamePlayerNotify;
            client.onNotify(cls);
            hallModifyGuessGamePlayerNotify= cls;
        }

        public void offModifyGuessGamePlayerNotify() {
            if (hallModifyGuessGamePlayerNotify != null){
                client.offNotify(((hallModifyGuessGamePlayerNotify.getClsID()&0xff)<<8)|(hallModifyGuessGamePlayerNotify.getMethodID()&0xff));
                hallModifyGuessGamePlayerNotify= null;
            }
        }

        public void modifyGuessGamePlayerDict(int oper, int userId, int val, HallModifyGuessGamePlayerDictResponse.Success _s_ =  null, HallModifyGuessGamePlayerDictResponse.Fail _f_ =  null) {
            HallModifyGuessGamePlayerDictRequest req=new HallModifyGuessGamePlayerDictRequest();
            req.oper=oper;
            req.userId=userId;
            req.val=val;
            client.send(req, new HallModifyGuessGamePlayerDictResponse(_s_, _f_));
        }

        public void matchWithPlayerInfo(int hallId, HallPlayerInfo player, HallMatchWithPlayerInfoResponse.Success _s_ =  null, HallMatchWithPlayerInfoResponse.Fail _f_ =  null) {
            HallMatchWithPlayerInfoRequest req=new HallMatchWithPlayerInfoRequest();
            req.hallId=hallId;
            req.player=player;
            client.send(req, new HallMatchWithPlayerInfoResponse(_s_, _f_));
        }

        public void onMatchSuccessNotify(HallMatchSuccessNotify.MatchSuccessNotify matchSuccessNotify) {
            HallMatchSuccessNotify cls=new HallMatchSuccessNotify();
            cls.matchSuccessNotify = matchSuccessNotify;
            client.onNotify(cls);
            hallMatchSuccessNotify= cls;
        }

        public void offMatchSuccessNotify() {
            if (hallMatchSuccessNotify != null){
                client.offNotify(((hallMatchSuccessNotify.getClsID()&0xff)<<8)|(hallMatchSuccessNotify.getMethodID()&0xff));
                hallMatchSuccessNotify= null;
            }
        }

        public void onMatchFailNotify(HallMatchFailNotify.MatchFailNotify matchFailNotify) {
            HallMatchFailNotify cls=new HallMatchFailNotify();
            cls.matchFailNotify = matchFailNotify;
            client.onNotify(cls);
            hallMatchFailNotify= cls;
        }

        public void offMatchFailNotify() {
            if (hallMatchFailNotify != null){
                client.offNotify(((hallMatchFailNotify.getClsID()&0xff)<<8)|(hallMatchFailNotify.getMethodID()&0xff));
                hallMatchFailNotify= null;
            }
        }

        public void match(int hallId, HallMatchResponse.Success _s_ =  null, HallMatchResponse.Fail _f_ =  null) {
            HallMatchRequest req=new HallMatchRequest();
            req.hallId=hallId;
            client.send(req, new HallMatchResponse(_s_, _f_));
        }

        public void leaveHall(HallLeaveHallResponse.Success _s_ =  null, HallLeaveHallResponse.Fail _f_ =  null) {
            HallLeaveHallRequest req=new HallLeaveHallRequest();
            client.send(req, new HallLeaveHallResponse(_s_, _f_));
        }

        public void onKtvRoomTimeoutWarnNotify(HallKtvRoomTimeoutWarnNotify.KtvRoomTimeoutWarnNotify ktvRoomTimeoutWarnNotify) {
            HallKtvRoomTimeoutWarnNotify cls=new HallKtvRoomTimeoutWarnNotify();
            cls.ktvRoomTimeoutWarnNotify = ktvRoomTimeoutWarnNotify;
            client.onNotify(cls);
            hallKtvRoomTimeoutWarnNotify= cls;
        }

        public void offKtvRoomTimeoutWarnNotify() {
            if (hallKtvRoomTimeoutWarnNotify != null){
                client.offNotify(((hallKtvRoomTimeoutWarnNotify.getClsID()&0xff)<<8)|(hallKtvRoomTimeoutWarnNotify.getMethodID()&0xff));
                hallKtvRoomTimeoutWarnNotify= null;
            }
        }

        public void onKickoutFromKTVRoomNotify(HallKickoutFromKTVRoomNotify.KickoutFromKTVRoomNotify kickoutFromKTVRoomNotify) {
            HallKickoutFromKTVRoomNotify cls=new HallKickoutFromKTVRoomNotify();
            cls.kickoutFromKTVRoomNotify = kickoutFromKTVRoomNotify;
            client.onNotify(cls);
            hallKickoutFromKTVRoomNotify= cls;
        }

        public void offKickoutFromKTVRoomNotify() {
            if (hallKickoutFromKTVRoomNotify != null){
                client.offNotify(((hallKickoutFromKTVRoomNotify.getClsID()&0xff)<<8)|(hallKickoutFromKTVRoomNotify.getMethodID()&0xff));
                hallKickoutFromKTVRoomNotify= null;
            }
        }

        public void kickoutFromKTVRoom(int playerId, HallKickoutFromKTVRoomResponse.Success _s_ =  null, HallKickoutFromKTVRoomResponse.Fail _f_ =  null) {
            HallKickoutFromKTVRoomRequest req=new HallKickoutFromKTVRoomRequest();
            req.playerId=playerId;
            client.send(req, new HallKickoutFromKTVRoomResponse(_s_, _f_));
        }

        public void keepMatch(int hallId, int oldMapId, int oldRoomId, HallKeepMatchResponse.Success _s_ =  null, HallKeepMatchResponse.Fail _f_ =  null) {
            HallKeepMatchRequest req=new HallKeepMatchRequest();
            req.hallId=hallId;
            req.oldMapId=oldMapId;
            req.oldRoomId=oldRoomId;
            client.send(req, new HallKeepMatchResponse(_s_, _f_));
        }

        public void getVoteToplist(HallGetVoteToplistResponse.Success _s_ =  null, HallGetVoteToplistResponse.Fail _f_ =  null) {
            HallGetVoteToplistRequest req=new HallGetVoteToplistRequest();
            client.send(req, new HallGetVoteToplistResponse(_s_, _f_));
        }

        public void getTitlePrizes(HallGetTitlePrizesResponse.Success _s_ =  null, HallGetTitlePrizesResponse.Fail _f_ =  null) {
            HallGetTitlePrizesRequest req=new HallGetTitlePrizesRequest();
            client.send(req, new HallGetTitlePrizesResponse(_s_, _f_));
        }

        public void getStreetPannelInfo(HallGetStreetPannelInfoResponse.Success _s_ =  null, HallGetStreetPannelInfoResponse.Fail _f_ =  null) {
            HallGetStreetPannelInfoRequest req=new HallGetStreetPannelInfoRequest();
            client.send(req, new HallGetStreetPannelInfoResponse(_s_, _f_));
        }

        public void getShowRooms(int pageNo, int pageSize, string roomType, bool isDesc, HallGetShowRoomsResponse.Success _s_ =  null, HallGetShowRoomsResponse.Fail _f_ =  null) {
            HallGetShowRoomsRequest req=new HallGetShowRoomsRequest();
            req.pageNo=pageNo;
            req.pageSize=pageSize;
            req.roomType=roomType;
            req.isDesc=isDesc;
            client.send(req, new HallGetShowRoomsResponse(_s_, _f_));
        }

        public void getShowPlayerSound(HallGetShowPlayerSoundResponse.Success _s_ =  null, HallGetShowPlayerSoundResponse.Fail _f_ =  null) {
            HallGetShowPlayerSoundRequest req=new HallGetShowPlayerSoundRequest();
            client.send(req, new HallGetShowPlayerSoundResponse(_s_, _f_));
        }

        public void getServerMs(HallGetServerMsResponse.Success _s_ =  null, HallGetServerMsResponse.Fail _f_ =  null) {
            HallGetServerMsRequest req=new HallGetServerMsRequest();
            client.send(req, new HallGetServerMsResponse(_s_, _f_));
        }

        public void getScoringToplist(HallGetScoringToplistResponse.Success _s_ =  null, HallGetScoringToplistResponse.Fail _f_ =  null) {
            HallGetScoringToplistRequest req=new HallGetScoringToplistRequest();
            client.send(req, new HallGetScoringToplistResponse(_s_, _f_));
        }

        public void getRoomListByType(string roomType, bool isDesc, HallGetRoomListByTypeResponse.Success _s_ =  null, HallGetRoomListByTypeResponse.Fail _f_ =  null) {
            HallGetRoomListByTypeRequest req=new HallGetRoomListByTypeRequest();
            req.roomType=roomType;
            req.isDesc=isDesc;
            client.send(req, new HallGetRoomListByTypeResponse(_s_, _f_));
        }

        public void getRoomList(int pageNo, int pageSize, string roomType, bool isDesc, HallGetRoomListResponse.Success _s_ =  null, HallGetRoomListResponse.Fail _f_ =  null) {
            HallGetRoomListRequest req=new HallGetRoomListRequest();
            req.pageNo=pageNo;
            req.pageSize=pageSize;
            req.roomType=roomType;
            req.isDesc=isDesc;
            client.send(req, new HallGetRoomListResponse(_s_, _f_));
        }

        public void getRoomDetail(int hallId, int roomId, HallGetRoomDetailResponse.Success _s_ =  null, HallGetRoomDetailResponse.Fail _f_ =  null) {
            HallGetRoomDetailRequest req=new HallGetRoomDetailRequest();
            req.hallId=hallId;
            req.roomId=roomId;
            client.send(req, new HallGetRoomDetailResponse(_s_, _f_));
        }

        public void getRoomById(int roomId, HallGetRoomByIdResponse.Success _s_ =  null, HallGetRoomByIdResponse.Fail _f_ =  null) {
            HallGetRoomByIdRequest req=new HallGetRoomByIdRequest();
            req.roomId=roomId;
            client.send(req, new HallGetRoomByIdResponse(_s_, _f_));
        }

        public void getKTVStatus(HallGetKTVStatusResponse.Success _s_ =  null, HallGetKTVStatusResponse.Fail _f_ =  null) {
            HallGetKTVStatusRequest req=new HallGetKTVStatusRequest();
            client.send(req, new HallGetKTVStatusResponse(_s_, _f_));
        }

        public void getKTVRooms(int pageNo, int pageSize, string roomType, bool isDesc, HallGetKTVRoomsResponse.Success _s_ =  null, HallGetKTVRoomsResponse.Fail _f_ =  null) {
            HallGetKTVRoomsRequest req=new HallGetKTVRoomsRequest();
            req.pageNo=pageNo;
            req.pageSize=pageSize;
            req.roomType=roomType;
            req.isDesc=isDesc;
            client.send(req, new HallGetKTVRoomsResponse(_s_, _f_));
        }

        public void getInternalList(HallGetInternalListResponse.Success _s_ =  null, HallGetInternalListResponse.Fail _f_ =  null) {
            HallGetInternalListRequest req=new HallGetInternalListRequest();
            client.send(req, new HallGetInternalListResponse(_s_, _f_));
        }

        public void getHomePageInfo(int pageNo, int pageSize, string roomType, bool isDesc, int[] hallIds, HallGetHomePageInfoResponse.Success _s_ =  null, HallGetHomePageInfoResponse.Fail _f_ =  null) {
            HallGetHomePageInfoRequest req=new HallGetHomePageInfoRequest();
            req.pageNo=pageNo;
            req.pageSize=pageSize;
            req.roomType=roomType;
            req.isDesc=isDesc;
            req.hallIds=hallIds;
            client.send(req, new HallGetHomePageInfoResponse(_s_, _f_));
        }

        public void getGuessGamePlayerDict(HallGetGuessGamePlayerDictResponse.Success _s_ =  null, HallGetGuessGamePlayerDictResponse.Fail _f_ =  null) {
            HallGetGuessGamePlayerDictRequest req=new HallGetGuessGamePlayerDictRequest();
            client.send(req, new HallGetGuessGamePlayerDictResponse(_s_, _f_));
        }

        public void getFreeRoom(int hallId, HallGetFreeRoomResponse.Success _s_ =  null, HallGetFreeRoomResponse.Fail _f_ =  null) {
            HallGetFreeRoomRequest req=new HallGetFreeRoomRequest();
            req.hallId=hallId;
            client.send(req, new HallGetFreeRoomResponse(_s_, _f_));
        }

        public void getFinalVoteToplist(HallGetFinalVoteToplistResponse.Success _s_ =  null, HallGetFinalVoteToplistResponse.Fail _f_ =  null) {
            HallGetFinalVoteToplistRequest req=new HallGetFinalVoteToplistRequest();
            client.send(req, new HallGetFinalVoteToplistResponse(_s_, _f_));
        }

        public void getDeepStage(HallGetDeepStageResponse.Success _s_ =  null, HallGetDeepStageResponse.Fail _f_ =  null) {
            HallGetDeepStageRequest req=new HallGetDeepStageRequest();
            client.send(req, new HallGetDeepStageResponse(_s_, _f_));
        }

        public void getAnswerToplist(HallGetAnswerToplistResponse.Success _s_ =  null, HallGetAnswerToplistResponse.Fail _f_ =  null) {
            HallGetAnswerToplistRequest req=new HallGetAnswerToplistRequest();
            client.send(req, new HallGetAnswerToplistResponse(_s_, _f_));
        }

        public void getActivityStatus(HallGetActivityStatusResponse.Success _s_ =  null, HallGetActivityStatusResponse.Fail _f_ =  null) {
            HallGetActivityStatusRequest req=new HallGetActivityStatusRequest();
            client.send(req, new HallGetActivityStatusResponse(_s_, _f_));
        }

        public void fastMatch(int hallId, int roomId, int mapId, HallFastMatchResponse.Success _s_ =  null, HallFastMatchResponse.Fail _f_ =  null) {
            HallFastMatchRequest req=new HallFastMatchRequest();
            req.hallId=hallId;
            req.roomId=roomId;
            req.mapId=mapId;
            client.send(req, new HallFastMatchResponse(_s_, _f_));
        }

        public void enterHallWithPlayerInfo(int hallId, HallPlayerInfo player, HallEnterHallWithPlayerInfoResponse.Success _s_ =  null, HallEnterHallWithPlayerInfoResponse.Fail _f_ =  null) {
            HallEnterHallWithPlayerInfoRequest req=new HallEnterHallWithPlayerInfoRequest();
            req.hallId=hallId;
            req.player=player;
            client.send(req, new HallEnterHallWithPlayerInfoResponse(_s_, _f_));
        }

        public void enterHall(int hallId, HallEnterHallResponse.Success _s_ =  null, HallEnterHallResponse.Fail _f_ =  null) {
            HallEnterHallRequest req=new HallEnterHallRequest();
            req.hallId=hallId;
            client.send(req, new HallEnterHallResponse(_s_, _f_));
        }

        public void onEndShowNotify(HallEndShowNotify.EndShowNotify endShowNotify) {
            HallEndShowNotify cls=new HallEndShowNotify();
            cls.endShowNotify = endShowNotify;
            client.onNotify(cls);
            hallEndShowNotify= cls;
        }

        public void offEndShowNotify() {
            if (hallEndShowNotify != null){
                client.offNotify(((hallEndShowNotify.getClsID()&0xff)<<8)|(hallEndShowNotify.getMethodID()&0xff));
                hallEndShowNotify= null;
            }
        }

        public void deleteInternalList(int playerId, HallDeleteInternalListResponse.Success _s_ =  null, HallDeleteInternalListResponse.Fail _f_ =  null) {
            HallDeleteInternalListRequest req=new HallDeleteInternalListRequest();
            req.playerId=playerId;
            client.send(req, new HallDeleteInternalListResponse(_s_, _f_));
        }

        public void createTutorialRoom(string roomName, string roomType, int maxPlayers, bool isAutoDestroy, bool isPrivate, List<PropertyValue> hallRoomInfo, HallCreateTutorialRoomResponse.Success _s_ =  null, HallCreateTutorialRoomResponse.Fail _f_ =  null) {
            HallCreateTutorialRoomRequest req=new HallCreateTutorialRoomRequest();
            req.roomName=roomName;
            req.roomType=roomType;
            req.maxPlayers=maxPlayers;
            req.isAutoDestroy=isAutoDestroy;
            req.isPrivate=isPrivate;
            req.hallRoomInfo=hallRoomInfo;
            client.send(req, new HallCreateTutorialRoomResponse(_s_, _f_));
        }

        public void createRoom(string roomName, string roomType, int maxPlayers, bool isAutoDestroy, bool isPrivate, List<PropertyValue> hallRoomInfo, HallCreateRoomResponse.Success _s_ =  null, HallCreateRoomResponse.Fail _f_ =  null) {
            HallCreateRoomRequest req=new HallCreateRoomRequest();
            req.roomName=roomName;
            req.roomType=roomType;
            req.maxPlayers=maxPlayers;
            req.isAutoDestroy=isAutoDestroy;
            req.isPrivate=isPrivate;
            req.hallRoomInfo=hallRoomInfo;
            client.send(req, new HallCreateRoomResponse(_s_, _f_));
        }

        public void createKTVRoom(int mapId, int pwd, int timeSize, int roomSize, string roomName, string roomType, int coinType, bool isAutoDestroy, List<PropertyValue> hallRoomInfo, HallCreateKTVRoomResponse.Success _s_ =  null, HallCreateKTVRoomResponse.Fail _f_ =  null) {
            HallCreateKTVRoomRequest req=new HallCreateKTVRoomRequest();
            req.mapId=mapId;
            req.pwd=pwd;
            req.timeSize=timeSize;
            req.roomSize=roomSize;
            req.roomName=roomName;
            req.roomType=roomType;
            req.coinType=coinType;
            req.isAutoDestroy=isAutoDestroy;
            req.hallRoomInfo=hallRoomInfo;
            client.send(req, new HallCreateKTVRoomResponse(_s_, _f_));
        }

        public void clearVoteData(HallClearVoteDataResponse.Success _s_ =  null, HallClearVoteDataResponse.Fail _f_ =  null) {
            HallClearVoteDataRequest req=new HallClearVoteDataRequest();
            client.send(req, new HallClearVoteDataResponse(_s_, _f_));
        }

        public void clearScoringData(HallClearScoringDataResponse.Success _s_ =  null, HallClearScoringDataResponse.Fail _f_ =  null) {
            HallClearScoringDataRequest req=new HallClearScoringDataRequest();
            client.send(req, new HallClearScoringDataResponse(_s_, _f_));
        }

        public void clearInternalListData(HallClearInternalListDataResponse.Success _s_ =  null, HallClearInternalListDataResponse.Fail _f_ =  null) {
            HallClearInternalListDataRequest req=new HallClearInternalListDataRequest();
            client.send(req, new HallClearInternalListDataResponse(_s_, _f_));
        }

        public void clearAnswerData(HallClearAnswerDataResponse.Success _s_ =  null, HallClearAnswerDataResponse.Fail _f_ =  null) {
            HallClearAnswerDataRequest req=new HallClearAnswerDataRequest();
            client.send(req, new HallClearAnswerDataResponse(_s_, _f_));
        }

        public void chooseInternalListNum(int num, HallChooseInternalListNumResponse.Success _s_ =  null, HallChooseInternalListNumResponse.Fail _f_ =  null) {
            HallChooseInternalListNumRequest req=new HallChooseInternalListNumRequest();
            req.num=num;
            client.send(req, new HallChooseInternalListNumResponse(_s_, _f_));
        }

        public void checkPwd(int hallId, int roomId, int pwd, HallCheckPwdResponse.Success _s_ =  null, HallCheckPwdResponse.Fail _f_ =  null) {
            HallCheckPwdRequest req=new HallCheckPwdRequest();
            req.hallId=hallId;
            req.roomId=roomId;
            req.pwd=pwd;
            client.send(req, new HallCheckPwdResponse(_s_, _f_));
        }

        public void checkMatch(int hallId, HallCheckMatchResponse.Success _s_ =  null, HallCheckMatchResponse.Fail _f_ =  null) {
            HallCheckMatchRequest req=new HallCheckMatchRequest();
            req.hallId=hallId;
            client.send(req, new HallCheckMatchResponse(_s_, _f_));
        }

        public void checkKTVFreeActivityOpen(HallCheckKTVFreeActivityOpenResponse.Success _s_ =  null, HallCheckKTVFreeActivityOpenResponse.Fail _f_ =  null) {
            HallCheckKTVFreeActivityOpenRequest req=new HallCheckKTVFreeActivityOpenRequest();
            client.send(req, new HallCheckKTVFreeActivityOpenResponse(_s_, _f_));
        }

        public void checkKTVEnterValid(int hallId, int roomId, HallCheckKTVEnterValidResponse.Success _s_ =  null, HallCheckKTVEnterValidResponse.Fail _f_ =  null) {
            HallCheckKTVEnterValidRequest req=new HallCheckKTVEnterValidRequest();
            req.hallId=hallId;
            req.roomId=roomId;
            client.send(req, new HallCheckKTVEnterValidResponse(_s_, _f_));
        }

        public void checkEnterRoom(int hallId, int roomId, HallCheckEnterRoomResponse.Success _s_ =  null, HallCheckEnterRoomResponse.Fail _f_ =  null) {
            HallCheckEnterRoomRequest req=new HallCheckEnterRoomRequest();
            req.hallId=hallId;
            req.roomId=roomId;
            client.send(req, new HallCheckEnterRoomResponse(_s_, _f_));
        }

        public void checkEnterHall(int hallId, HallCheckEnterHallResponse.Success _s_ =  null, HallCheckEnterHallResponse.Fail _f_ =  null) {
            HallCheckEnterHallRequest req=new HallCheckEnterHallRequest();
            req.hallId=hallId;
            client.send(req, new HallCheckEnterHallResponse(_s_, _f_));
        }

        public void checkCreateRoom(int hallId, HallCheckCreateRoomResponse.Success _s_ =  null, HallCheckCreateRoomResponse.Fail _f_ =  null) {
            HallCheckCreateRoomRequest req=new HallCheckCreateRoomRequest();
            req.hallId=hallId;
            client.send(req, new HallCheckCreateRoomResponse(_s_, _f_));
        }

        public void changeHallRoomStatusAndProperty(int oriStatus, int dstStatus, PropertyValue value, HallChangeHallRoomStatusAndPropertyResponse.Success _s_ =  null, HallChangeHallRoomStatusAndPropertyResponse.Fail _f_ =  null) {
            HallChangeHallRoomStatusAndPropertyRequest req=new HallChangeHallRoomStatusAndPropertyRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.value=value;
            client.send(req, new HallChangeHallRoomStatusAndPropertyResponse(_s_, _f_));
        }

        public void changeHallRoomStatus(int oriStatus, int dstStatus, HallChangeHallRoomStatusResponse.Success _s_ =  null, HallChangeHallRoomStatusResponse.Fail _f_ =  null) {
            HallChangeHallRoomStatusRequest req=new HallChangeHallRoomStatusRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            client.send(req, new HallChangeHallRoomStatusResponse(_s_, _f_));
        }

        public void changeHallRoomProperty(PropertyValue value, HallChangeHallRoomPropertyResponse.Success _s_ =  null, HallChangeHallRoomPropertyResponse.Fail _f_ =  null) {
            HallChangeHallRoomPropertyRequest req=new HallChangeHallRoomPropertyRequest();
            req.value=value;
            client.send(req, new HallChangeHallRoomPropertyResponse(_s_, _f_));
        }

        public void changeHallPlayerStatusAndProperty(int oriStatus, int dstStatus, PropertyValue value, HallChangeHallPlayerStatusAndPropertyResponse.Success _s_ =  null, HallChangeHallPlayerStatusAndPropertyResponse.Fail _f_ =  null) {
            HallChangeHallPlayerStatusAndPropertyRequest req=new HallChangeHallPlayerStatusAndPropertyRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            req.value=value;
            client.send(req, new HallChangeHallPlayerStatusAndPropertyResponse(_s_, _f_));
        }

        public void changeHallPlayerStatus(int oriStatus, int dstStatus, HallChangeHallPlayerStatusResponse.Success _s_ =  null, HallChangeHallPlayerStatusResponse.Fail _f_ =  null) {
            HallChangeHallPlayerStatusRequest req=new HallChangeHallPlayerStatusRequest();
            req.oriStatus=oriStatus;
            req.dstStatus=dstStatus;
            client.send(req, new HallChangeHallPlayerStatusResponse(_s_, _f_));
        }

        public void changeHallPlayerProperty(PropertyValue value, HallChangeHallPlayerPropertyResponse.Success _s_ =  null, HallChangeHallPlayerPropertyResponse.Fail _f_ =  null) {
            HallChangeHallPlayerPropertyRequest req=new HallChangeHallPlayerPropertyRequest();
            req.value=value;
            client.send(req, new HallChangeHallPlayerPropertyResponse(_s_, _f_));
        }

        public void cancelMatch(HallCancelMatchResponse.Success _s_ =  null, HallCancelMatchResponse.Fail _f_ =  null) {
            HallCancelMatchRequest req=new HallCancelMatchRequest();
            client.send(req, new HallCancelMatchResponse(_s_, _f_));
        }

        public void answer(HallAnswerResponse.Success _s_ =  null, HallAnswerResponse.Fail _f_ =  null) {
            HallAnswerRequest req=new HallAnswerRequest();
            client.send(req, new HallAnswerResponse(_s_, _f_));
        }

        public void addToInternalList(int playerId, HallAddToInternalListResponse.Success _s_ =  null, HallAddToInternalListResponse.Fail _f_ =  null) {
            HallAddToInternalListRequest req=new HallAddToInternalListRequest();
            req.playerId=playerId;
            client.send(req, new HallAddToInternalListResponse(_s_, _f_));
        }
    }
}

