using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class KTVNetService {
        public static KTVNetService ins = new KTVNetService();

        NodeClient client;

        KTVOperateNotify kTVOperateNotify;

        KTVOnRecvFromClientNotify kTVOnRecvFromClientNotify;

        KTVClearNotify kTVClearNotify;

        public KTVNetService() {
            client =NodeClient.get("KTVNetService");
        }

        public void top(string songId, int singer, KTVTopResponse.Success _s_ =  null, KTVTopResponse.Fail _f_ =  null) {
            KTVTopRequest req=new KTVTopRequest();
            req.songId=songId;
            req.singer=singer;
            client.send(req, new KTVTopResponse(_s_, _f_));
        }

        public void songs(int hallId, int mainRoomId, KTVSongsResponse.Success _s_ =  null, KTVSongsResponse.Fail _f_ =  null) {
            KTVSongsRequest req=new KTVSongsRequest();
            req.hallId=hallId;
            req.mainRoomId=mainRoomId;
            client.send(req, new KTVSongsResponse(_s_, _f_));
        }

        public void sendToOthers(int hallId, int mainRoomId, short type, byte[] msg, KTVSendToOthersResponse.Success _s_ =  null, KTVSendToOthersResponse.Fail _f_ =  null) {
            KTVSendToOthersRequest req=new KTVSendToOthersRequest();
            req.hallId=hallId;
            req.mainRoomId=mainRoomId;
            req.type=type;
            req.msg=msg;
            client.send(req, new KTVSendToOthersResponse(_s_, _f_));
        }

        public void sendToAll(int hallId, int mainRoomId, short type, byte[] msg, KTVSendToAllResponse.Success _s_ =  null, KTVSendToAllResponse.Fail _f_ =  null) {
            KTVSendToAllRequest req=new KTVSendToAllRequest();
            req.hallId=hallId;
            req.mainRoomId=mainRoomId;
            req.type=type;
            req.msg=msg;
            client.send(req, new KTVSendToAllResponse(_s_, _f_));
        }

        public void onOperateNotify(KTVOperateNotify.OperateNotify operateNotify) {
            KTVOperateNotify cls=new KTVOperateNotify();
            cls.operateNotify = operateNotify;
            client.onNotify(cls);
            kTVOperateNotify= cls;
        }

        public void offOperateNotify() {
            if (kTVOperateNotify != null){
                client.offNotify(((kTVOperateNotify.getClsID()&0xff)<<8)|(kTVOperateNotify.getMethodID()&0xff));
                kTVOperateNotify= null;
            }
        }

        public void onOnRecvFromClientNotify(KTVOnRecvFromClientNotify.OnRecvFromClientNotify onRecvFromClientNotify) {
            KTVOnRecvFromClientNotify cls=new KTVOnRecvFromClientNotify();
            cls.onRecvFromClientNotify = onRecvFromClientNotify;
            client.onNotify(cls);
            kTVOnRecvFromClientNotify= cls;
        }

        public void offOnRecvFromClientNotify() {
            if (kTVOnRecvFromClientNotify != null){
                client.offNotify(((kTVOnRecvFromClientNotify.getClsID()&0xff)<<8)|(kTVOnRecvFromClientNotify.getMethodID()&0xff));
                kTVOnRecvFromClientNotify= null;
            }
        }

        public void delete(string songId, int singer, KTVDeleteResponse.Success _s_ =  null, KTVDeleteResponse.Fail _f_ =  null) {
            KTVDeleteRequest req=new KTVDeleteRequest();
            req.songId=songId;
            req.singer=singer;
            client.send(req, new KTVDeleteResponse(_s_, _f_));
        }

        public void clearSongs(KTVClearSongsResponse.Success _s_ =  null, KTVClearSongsResponse.Fail _f_ =  null) {
            KTVClearSongsRequest req=new KTVClearSongsRequest();
            client.send(req, new KTVClearSongsResponse(_s_, _f_));
        }

        public void onClearNotify(KTVClearNotify.ClearNotify clearNotify) {
            KTVClearNotify cls=new KTVClearNotify();
            cls.clearNotify = clearNotify;
            client.onNotify(cls);
            kTVClearNotify= cls;
        }

        public void offClearNotify() {
            if (kTVClearNotify != null){
                client.offNotify(((kTVClearNotify.getClsID()&0xff)<<8)|(kTVClearNotify.getMethodID()&0xff));
                kTVClearNotify= null;
            }
        }

        public void chorus(string songId, int singer, int chorus, KTVChorusResponse.Success _s_ =  null, KTVChorusResponse.Fail _f_ =  null) {
            KTVChorusRequest req=new KTVChorusRequest();
            req.songId=songId;
            req.singer=singer;
            req.chorus=chorus;
            client.send(req, new KTVChorusResponse(_s_, _f_));
        }

        public void choose(string songId, int resourceType, string songName, string originalSinger, int singer, string singerName, KTVChooseResponse.Success _s_ =  null, KTVChooseResponse.Fail _f_ =  null) {
            KTVChooseRequest req=new KTVChooseRequest();
            req.songId=songId;
            req.resourceType=resourceType;
            req.songName=songName;
            req.originalSinger=originalSinger;
            req.singer=singer;
            req.singerName=singerName;
            client.send(req, new KTVChooseResponse(_s_, _f_));
        }
    }
}

