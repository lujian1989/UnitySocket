using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class BackpackNetService {
        public static BackpackNetService ins = new BackpackNetService();

        NodeClient client;

        BackpackBackpackNotify backpackBackpackNotify;

        public BackpackNetService() {
            client =NodeClient.get("BackpackNetService");
        }

        public void usePaper(int id, int receiver, string content, BackpackUsePaperResponse.Success _s_ =  null, BackpackUsePaperResponse.Fail _f_ =  null) {
            BackpackUsePaperRequest req=new BackpackUsePaperRequest();
            req.id=id;
            req.receiver=receiver;
            req.content=content;
            client.send(req, new BackpackUsePaperResponse(_s_, _f_));
        }

        public void useItem(int id, int num, BackpackUseItemResponse.Success _s_ =  null, BackpackUseItemResponse.Fail _f_ =  null) {
            BackpackUseItemRequest req=new BackpackUseItemRequest();
            req.id=id;
            req.num=num;
            client.send(req, new BackpackUseItemResponse(_s_, _f_));
        }

        public void openGift(int id, BackpackOpenGiftResponse.Success _s_ =  null, BackpackOpenGiftResponse.Fail _f_ =  null) {
            BackpackOpenGiftRequest req=new BackpackOpenGiftRequest();
            req.id=id;
            client.send(req, new BackpackOpenGiftResponse(_s_, _f_));
        }

        public void getBackpacks(BackpackGetBackpacksResponse.Success _s_ =  null, BackpackGetBackpacksResponse.Fail _f_ =  null) {
            BackpackGetBackpacksRequest req=new BackpackGetBackpacksRequest();
            client.send(req, new BackpackGetBackpacksResponse(_s_, _f_));
        }

        public void deleteItem(int id, BackpackDeleteItemResponse.Success _s_ =  null, BackpackDeleteItemResponse.Fail _f_ =  null) {
            BackpackDeleteItemRequest req=new BackpackDeleteItemRequest();
            req.id=id;
            client.send(req, new BackpackDeleteItemResponse(_s_, _f_));
        }

        public void onBackpackNotify(BackpackBackpackNotify.BackpackNotify backpackNotify) {
            BackpackBackpackNotify cls=new BackpackBackpackNotify();
            cls.backpackNotify = backpackNotify;
            client.onNotify(cls);
            backpackBackpackNotify= cls;
        }

        public void offBackpackNotify() {
            if (backpackBackpackNotify != null){
                client.offNotify(((backpackBackpackNotify.getClsID()&0xff)<<8)|(backpackBackpackNotify.getMethodID()&0xff));
                backpackBackpackNotify= null;
            }
        }
    }
}

