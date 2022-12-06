using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class GramophoneNetService {
        public static GramophoneNetService ins = new GramophoneNetService();

        NodeClient client;

        public GramophoneNetService() {
            client =NodeClient.get("GramophoneNetService");
        }

        public void readMessage(int id, GramophoneReadMessageResponse.Success _s_ =  null, GramophoneReadMessageResponse.Fail _f_ =  null) {
            GramophoneReadMessageRequest req=new GramophoneReadMessageRequest();
            req.id=id;
            client.send(req, new GramophoneReadMessageResponse(_s_, _f_));
        }

        public void leftMessage(int owner, int seconds, string voiceId, GramophoneLeftMessageResponse.Success _s_ =  null, GramophoneLeftMessageResponse.Fail _f_ =  null) {
            GramophoneLeftMessageRequest req=new GramophoneLeftMessageRequest();
            req.owner=owner;
            req.seconds=seconds;
            req.voiceId=voiceId;
            client.send(req, new GramophoneLeftMessageResponse(_s_, _f_));
        }

        public void getMessages(int owner, GramophoneGetMessagesResponse.Success _s_ =  null, GramophoneGetMessagesResponse.Fail _f_ =  null) {
            GramophoneGetMessagesRequest req=new GramophoneGetMessagesRequest();
            req.owner=owner;
            client.send(req, new GramophoneGetMessagesResponse(_s_, _f_));
        }

        public void deleteMessage(int owner, int id, GramophoneDeleteMessageResponse.Success _s_ =  null, GramophoneDeleteMessageResponse.Fail _f_ =  null) {
            GramophoneDeleteMessageRequest req=new GramophoneDeleteMessageRequest();
            req.owner=owner;
            req.id=id;
            client.send(req, new GramophoneDeleteMessageResponse(_s_, _f_));
        }
    }
}

