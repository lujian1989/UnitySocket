using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class HomelandNetService {
        public static HomelandNetService ins = new HomelandNetService();

        NodeClient client;

        HomelandStartRoomModeNotify homelandStartRoomModeNotify;

        HomelandNewGramophoneMsgNotify homelandNewGramophoneMsgNotify;

        HomelandEndRoomModeNotify homelandEndRoomModeNotify;

        HomelandDeleteGramophoneMsgNotify homelandDeleteGramophoneMsgNotify;

        public HomelandNetService() {
            client =NodeClient.get("HomelandNetService");
        }

        public void onStartRoomModeNotify(HomelandStartRoomModeNotify.StartRoomModeNotify startRoomModeNotify) {
            HomelandStartRoomModeNotify cls=new HomelandStartRoomModeNotify();
            cls.startRoomModeNotify = startRoomModeNotify;
            client.onNotify(cls);
            homelandStartRoomModeNotify= cls;
        }

        public void offStartRoomModeNotify() {
            if (homelandStartRoomModeNotify != null){
                client.offNotify(((homelandStartRoomModeNotify.getClsID()&0xff)<<8)|(homelandStartRoomModeNotify.getMethodID()&0xff));
                homelandStartRoomModeNotify= null;
            }
        }

        public void randHomeland(HomelandRandHomelandResponse.Success _s_ =  null, HomelandRandHomelandResponse.Fail _f_ =  null) {
            HomelandRandHomelandRequest req=new HomelandRandHomelandRequest();
            client.send(req, new HomelandRandHomelandResponse(_s_, _f_));
        }

        public void onNewGramophoneMsgNotify(HomelandNewGramophoneMsgNotify.NewGramophoneMsgNotify newGramophoneMsgNotify) {
            HomelandNewGramophoneMsgNotify cls=new HomelandNewGramophoneMsgNotify();
            cls.newGramophoneMsgNotify = newGramophoneMsgNotify;
            client.onNotify(cls);
            homelandNewGramophoneMsgNotify= cls;
        }

        public void offNewGramophoneMsgNotify() {
            if (homelandNewGramophoneMsgNotify != null){
                client.offNotify(((homelandNewGramophoneMsgNotify.getClsID()&0xff)<<8)|(homelandNewGramophoneMsgNotify.getMethodID()&0xff));
                homelandNewGramophoneMsgNotify= null;
            }
        }

        public void likeHomeland(int homelandId, bool like, HomelandLikeHomelandResponse.Success _s_ =  null, HomelandLikeHomelandResponse.Fail _f_ =  null) {
            HomelandLikeHomelandRequest req=new HomelandLikeHomelandRequest();
            req.homelandId=homelandId;
            req.like=like;
            client.send(req, new HomelandLikeHomelandResponse(_s_, _f_));
        }

        public void leaveHomeland(HomelandLeaveHomelandResponse.Success _s_ =  null, HomelandLeaveHomelandResponse.Fail _f_ =  null) {
            HomelandLeaveHomelandRequest req=new HomelandLeaveHomelandRequest();
            client.send(req, new HomelandLeaveHomelandResponse(_s_, _f_));
        }

        public void getHomelandInfo(int userId, HomelandGetHomelandInfoResponse.Success _s_ =  null, HomelandGetHomelandInfoResponse.Fail _f_ =  null) {
            HomelandGetHomelandInfoRequest req=new HomelandGetHomelandInfoRequest();
            req.userId=userId;
            client.send(req, new HomelandGetHomelandInfoResponse(_s_, _f_));
        }

        public void enterMyHomeland(HomelandEnterMyHomelandResponse.Success _s_ =  null, HomelandEnterMyHomelandResponse.Fail _f_ =  null) {
            HomelandEnterMyHomelandRequest req=new HomelandEnterMyHomelandRequest();
            client.send(req, new HomelandEnterMyHomelandResponse(_s_, _f_));
        }

        public void enterHomeland(int userId, HomelandEnterHomelandResponse.Success _s_ =  null, HomelandEnterHomelandResponse.Fail _f_ =  null) {
            HomelandEnterHomelandRequest req=new HomelandEnterHomelandRequest();
            req.userId=userId;
            client.send(req, new HomelandEnterHomelandResponse(_s_, _f_));
        }

        public void onEndRoomModeNotify(HomelandEndRoomModeNotify.EndRoomModeNotify endRoomModeNotify) {
            HomelandEndRoomModeNotify cls=new HomelandEndRoomModeNotify();
            cls.endRoomModeNotify = endRoomModeNotify;
            client.onNotify(cls);
            homelandEndRoomModeNotify= cls;
        }

        public void offEndRoomModeNotify() {
            if (homelandEndRoomModeNotify != null){
                client.offNotify(((homelandEndRoomModeNotify.getClsID()&0xff)<<8)|(homelandEndRoomModeNotify.getMethodID()&0xff));
                homelandEndRoomModeNotify= null;
            }
        }

        public void onDeleteGramophoneMsgNotify(HomelandDeleteGramophoneMsgNotify.DeleteGramophoneMsgNotify deleteGramophoneMsgNotify) {
            HomelandDeleteGramophoneMsgNotify cls=new HomelandDeleteGramophoneMsgNotify();
            cls.deleteGramophoneMsgNotify = deleteGramophoneMsgNotify;
            client.onNotify(cls);
            homelandDeleteGramophoneMsgNotify= cls;
        }

        public void offDeleteGramophoneMsgNotify() {
            if (homelandDeleteGramophoneMsgNotify != null){
                client.offNotify(((homelandDeleteGramophoneMsgNotify.getClsID()&0xff)<<8)|(homelandDeleteGramophoneMsgNotify.getMethodID()&0xff));
                homelandDeleteGramophoneMsgNotify= null;
            }
        }

        public void checkEnterHomeland(int userId, HomelandCheckEnterHomelandResponse.Success _s_ =  null, HomelandCheckEnterHomelandResponse.Fail _f_ =  null) {
            HomelandCheckEnterHomelandRequest req=new HomelandCheckEnterHomelandRequest();
            req.userId=userId;
            client.send(req, new HomelandCheckEnterHomelandResponse(_s_, _f_));
        }
    }
}

