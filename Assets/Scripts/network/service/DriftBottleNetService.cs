using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class DriftBottleNetService {
        public static DriftBottleNetService ins = new DriftBottleNetService();

        NodeClient client;

        DriftBottleNewReplyNotify driftBottleNewReplyNotify;

        DriftBottleNewReplyDialogueNotify driftBottleNewReplyDialogueNotify;

        DriftBottleNewDialogueNotify driftBottleNewDialogueNotify;

        public DriftBottleNetService() {
            client =NodeClient.get("DriftBottleNetService");
        }

        public void sendDriftBottle(int seconds, string voiceId, string content, string imgUrl, DriftBottleSendDriftBottleResponse.Success _s_ =  null, DriftBottleSendDriftBottleResponse.Fail _f_ =  null) {
            DriftBottleSendDriftBottleRequest req=new DriftBottleSendDriftBottleRequest();
            req.seconds=seconds;
            req.voiceId=voiceId;
            req.content=content;
            req.imgUrl=imgUrl;
            client.send(req, new DriftBottleSendDriftBottleResponse(_s_, _f_));
        }

        public void replyDriftBottle(int bottleId, int seconds, string voiceId, string content, string imgUrl, DriftBottleReplyDriftBottleResponse.Success _s_ =  null, DriftBottleReplyDriftBottleResponse.Fail _f_ =  null) {
            DriftBottleReplyDriftBottleRequest req=new DriftBottleReplyDriftBottleRequest();
            req.bottleId=bottleId;
            req.seconds=seconds;
            req.voiceId=voiceId;
            req.content=content;
            req.imgUrl=imgUrl;
            client.send(req, new DriftBottleReplyDriftBottleResponse(_s_, _f_));
        }

        public void readReplyDialogue(int bottleId, DriftBottleReadReplyDialogueResponse.Success _s_ =  null, DriftBottleReadReplyDialogueResponse.Fail _f_ =  null) {
            DriftBottleReadReplyDialogueRequest req=new DriftBottleReadReplyDialogueRequest();
            req.bottleId=bottleId;
            client.send(req, new DriftBottleReadReplyDialogueResponse(_s_, _f_));
        }

        public void onNewReplyNotify(DriftBottleNewReplyNotify.NewReplyNotify newReplyNotify) {
            DriftBottleNewReplyNotify cls=new DriftBottleNewReplyNotify();
            cls.newReplyNotify = newReplyNotify;
            client.onNotify(cls);
            driftBottleNewReplyNotify= cls;
        }

        public void offNewReplyNotify() {
            if (driftBottleNewReplyNotify != null){
                client.offNotify(((driftBottleNewReplyNotify.getClsID()&0xff)<<8)|(driftBottleNewReplyNotify.getMethodID()&0xff));
                driftBottleNewReplyNotify= null;
            }
        }

        public void onNewReplyDialogueNotify(DriftBottleNewReplyDialogueNotify.NewReplyDialogueNotify newReplyDialogueNotify) {
            DriftBottleNewReplyDialogueNotify cls=new DriftBottleNewReplyDialogueNotify();
            cls.newReplyDialogueNotify = newReplyDialogueNotify;
            client.onNotify(cls);
            driftBottleNewReplyDialogueNotify= cls;
        }

        public void offNewReplyDialogueNotify() {
            if (driftBottleNewReplyDialogueNotify != null){
                client.offNotify(((driftBottleNewReplyDialogueNotify.getClsID()&0xff)<<8)|(driftBottleNewReplyDialogueNotify.getMethodID()&0xff));
                driftBottleNewReplyDialogueNotify= null;
            }
        }

        public void onNewDialogueNotify(DriftBottleNewDialogueNotify.NewDialogueNotify newDialogueNotify) {
            DriftBottleNewDialogueNotify cls=new DriftBottleNewDialogueNotify();
            cls.newDialogueNotify = newDialogueNotify;
            client.onNotify(cls);
            driftBottleNewDialogueNotify= cls;
        }

        public void offNewDialogueNotify() {
            if (driftBottleNewDialogueNotify != null){
                client.offNotify(((driftBottleNewDialogueNotify.getClsID()&0xff)<<8)|(driftBottleNewDialogueNotify.getMethodID()&0xff));
                driftBottleNewDialogueNotify= null;
            }
        }

        public void getUnReplyDialogue(DriftBottleGetUnReplyDialogueResponse.Success _s_ =  null, DriftBottleGetUnReplyDialogueResponse.Fail _f_ =  null) {
            DriftBottleGetUnReplyDialogueRequest req=new DriftBottleGetUnReplyDialogueRequest();
            client.send(req, new DriftBottleGetUnReplyDialogueResponse(_s_, _f_));
        }

        public void getReplyDialogues(DriftBottleGetReplyDialoguesResponse.Success _s_ =  null, DriftBottleGetReplyDialoguesResponse.Fail _f_ =  null) {
            DriftBottleGetReplyDialoguesRequest req=new DriftBottleGetReplyDialoguesRequest();
            client.send(req, new DriftBottleGetReplyDialoguesResponse(_s_, _f_));
        }

        public void getReplies(DriftBottleGetRepliesResponse.Success _s_ =  null, DriftBottleGetRepliesResponse.Fail _f_ =  null) {
            DriftBottleGetRepliesRequest req=new DriftBottleGetRepliesRequest();
            client.send(req, new DriftBottleGetRepliesResponse(_s_, _f_));
        }

        public void getDriftBottleState(DriftBottleGetDriftBottleStateResponse.Success _s_ =  null, DriftBottleGetDriftBottleStateResponse.Fail _f_ =  null) {
            DriftBottleGetDriftBottleStateRequest req=new DriftBottleGetDriftBottleStateRequest();
            client.send(req, new DriftBottleGetDriftBottleStateResponse(_s_, _f_));
        }

        public void getDialogues(int bottleId, DriftBottleGetDialoguesResponse.Success _s_ =  null, DriftBottleGetDialoguesResponse.Fail _f_ =  null) {
            DriftBottleGetDialoguesRequest req=new DriftBottleGetDialoguesRequest();
            req.bottleId=bottleId;
            client.send(req, new DriftBottleGetDialoguesResponse(_s_, _f_));
        }

        public void dragDriftBottle(DriftBottleDragDriftBottleResponse.Success _s_ =  null, DriftBottleDragDriftBottleResponse.Fail _f_ =  null) {
            DriftBottleDragDriftBottleRequest req=new DriftBottleDragDriftBottleRequest();
            client.send(req, new DriftBottleDragDriftBottleResponse(_s_, _f_));
        }

        public void deleteDriftBottle(int bottleId, DriftBottleDeleteDriftBottleResponse.Success _s_ =  null, DriftBottleDeleteDriftBottleResponse.Fail _f_ =  null) {
            DriftBottleDeleteDriftBottleRequest req=new DriftBottleDeleteDriftBottleRequest();
            req.bottleId=bottleId;
            client.send(req, new DriftBottleDeleteDriftBottleResponse(_s_, _f_));
        }

        public void checkSendDriftBottle(DriftBottleCheckSendDriftBottleResponse.Success _s_ =  null, DriftBottleCheckSendDriftBottleResponse.Fail _f_ =  null) {
            DriftBottleCheckSendDriftBottleRequest req=new DriftBottleCheckSendDriftBottleRequest();
            client.send(req, new DriftBottleCheckSendDriftBottleResponse(_s_, _f_));
        }
    }
}

