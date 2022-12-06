using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class MelodyNetService {
        public static MelodyNetService ins = new MelodyNetService();

        NodeClient client;

        public MelodyNetService() {
            client =NodeClient.get("MelodyNetService");
        }

        public void play(int audioId, MelodyPlayResponse.Success _s_ =  null, MelodyPlayResponse.Fail _f_ =  null) {
            MelodyPlayRequest req=new MelodyPlayRequest();
            req.audioId=audioId;
            client.send(req, new MelodyPlayResponse(_s_, _f_));
        }

        public void like(int audioId, bool isLike, MelodyLikeResponse.Success _s_ =  null, MelodyLikeResponse.Fail _f_ =  null) {
            MelodyLikeRequest req=new MelodyLikeRequest();
            req.audioId=audioId;
            req.isLike=isLike;
            client.send(req, new MelodyLikeResponse(_s_, _f_));
        }

        public void getPlayList(int casterId, MelodyGetPlayListResponse.Success _s_ =  null, MelodyGetPlayListResponse.Fail _f_ =  null) {
            MelodyGetPlayListRequest req=new MelodyGetPlayListRequest();
            req.casterId=casterId;
            client.send(req, new MelodyGetPlayListResponse(_s_, _f_));
        }

        public void getCollections(MelodyGetCollectionsResponse.Success _s_ =  null, MelodyGetCollectionsResponse.Fail _f_ =  null) {
            MelodyGetCollectionsRequest req=new MelodyGetCollectionsRequest();
            client.send(req, new MelodyGetCollectionsResponse(_s_, _f_));
        }

        public void getCasters(int topCount, MelodyGetCastersResponse.Success _s_ =  null, MelodyGetCastersResponse.Fail _f_ =  null) {
            MelodyGetCastersRequest req=new MelodyGetCastersRequest();
            req.topCount=topCount;
            client.send(req, new MelodyGetCastersResponse(_s_, _f_));
        }

        public void collect(int audioId, bool isCollect, MelodyCollectResponse.Success _s_ =  null, MelodyCollectResponse.Fail _f_ =  null) {
            MelodyCollectRequest req=new MelodyCollectRequest();
            req.audioId=audioId;
            req.isCollect=isCollect;
            client.send(req, new MelodyCollectResponse(_s_, _f_));
        }
    }
}

