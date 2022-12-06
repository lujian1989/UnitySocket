using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class MailNetService {
        public static MailNetService ins = new MailNetService();

        NodeClient client;

        MailNewMailNotify mailNewMailNotify;

        public MailNetService() {
            client =NodeClient.get("MailNetService");
        }

        public void readMail(int id, MailReadMailResponse.Success _s_ =  null, MailReadMailResponse.Fail _f_ =  null) {
            MailReadMailRequest req=new MailReadMailRequest();
            req.id=id;
            client.send(req, new MailReadMailResponse(_s_, _f_));
        }

        public void onNewMailNotify(MailNewMailNotify.NewMailNotify newMailNotify) {
            MailNewMailNotify cls=new MailNewMailNotify();
            cls.newMailNotify = newMailNotify;
            client.onNotify(cls);
            mailNewMailNotify= cls;
        }

        public void offNewMailNotify() {
            if (mailNewMailNotify != null){
                client.offNotify(((mailNewMailNotify.getClsID()&0xff)<<8)|(mailNewMailNotify.getMethodID()&0xff));
                mailNewMailNotify= null;
            }
        }

        public void getMails(MailGetMailsResponse.Success _s_ =  null, MailGetMailsResponse.Fail _f_ =  null) {
            MailGetMailsRequest req=new MailGetMailsRequest();
            client.send(req, new MailGetMailsResponse(_s_, _f_));
        }

        public void deleteMail(int id, MailDeleteMailResponse.Success _s_ =  null, MailDeleteMailResponse.Fail _f_ =  null) {
            MailDeleteMailRequest req=new MailDeleteMailRequest();
            req.id=id;
            client.send(req, new MailDeleteMailResponse(_s_, _f_));
        }

        public void acceptItems(int id, MailAcceptItemsResponse.Success _s_ =  null, MailAcceptItemsResponse.Fail _f_ =  null) {
            MailAcceptItemsRequest req=new MailAcceptItemsRequest();
            req.id=id;
            client.send(req, new MailAcceptItemsResponse(_s_, _f_));
        }
    }
}

