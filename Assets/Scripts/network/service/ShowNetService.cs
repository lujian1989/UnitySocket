using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class ShowNetService {
        public static ShowNetService ins = new ShowNetService();

        NodeClient client;

        ShowOnRecvFromClientNotify showOnRecvFromClientNotify;

        public ShowNetService() {
            client =NodeClient.get("ShowNetService");
        }

        public void sendToAll(bool self, short type, byte[] msg, ShowSendToAllResponse.Success _s_ =  null, ShowSendToAllResponse.Fail _f_ =  null) {
            ShowSendToAllRequest req=new ShowSendToAllRequest();
            req.self=self;
            req.type=type;
            req.msg=msg;
            client.send(req, new ShowSendToAllResponse(_s_, _f_));
        }

        public void pubData(short type, byte[] msg, ShowPubDataResponse.Success _s_ =  null, ShowPubDataResponse.Fail _f_ =  null) {
            ShowPubDataRequest req=new ShowPubDataRequest();
            req.type=type;
            req.msg=msg;
            client.send(req, new ShowPubDataResponse(_s_, _f_));
        }

        public void onOnRecvFromClientNotify(ShowOnRecvFromClientNotify.OnRecvFromClientNotify onRecvFromClientNotify) {
            ShowOnRecvFromClientNotify cls=new ShowOnRecvFromClientNotify();
            cls.onRecvFromClientNotify = onRecvFromClientNotify;
            client.onNotify(cls);
            showOnRecvFromClientNotify= cls;
        }

        public void offOnRecvFromClientNotify() {
            if (showOnRecvFromClientNotify != null){
                client.offNotify(((showOnRecvFromClientNotify.getClsID()&0xff)<<8)|(showOnRecvFromClientNotify.getMethodID()&0xff));
                showOnRecvFromClientNotify= null;
            }
        }

        public void getPubDatas(ShowGetPubDatasResponse.Success _s_ =  null, ShowGetPubDatasResponse.Fail _f_ =  null) {
            ShowGetPubDatasRequest req=new ShowGetPubDatasRequest();
            client.send(req, new ShowGetPubDatasResponse(_s_, _f_));
        }

        public void getFreeRoom(int mainRoomId, ShowGetFreeRoomResponse.Success _s_ =  null, ShowGetFreeRoomResponse.Fail _f_ =  null) {
            ShowGetFreeRoomRequest req=new ShowGetFreeRoomRequest();
            req.mainRoomId=mainRoomId;
            client.send(req, new ShowGetFreeRoomResponse(_s_, _f_));
        }
    }
}

