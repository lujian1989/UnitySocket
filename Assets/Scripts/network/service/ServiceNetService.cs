using network;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class ServiceNetService {
        public static ServiceNetService ins = new ServiceNetService();

        NodeClient client;

        ServiceOnSubscribePropertyNotify serviceOnSubscribePropertyNotify;

        ServiceOnSubscribeNotify serviceOnSubscribeNotify;

        public ServiceNetService() {
            client =NodeClient.get("ServiceNetService");
        }

        public void unsubscribe(int serviceId, ServiceUnsubscribeResponse.Success _s_ =  null, ServiceUnsubscribeResponse.Fail _f_ =  null) {
            ServiceUnsubscribeRequest req=new ServiceUnsubscribeRequest();
            req.serviceId=serviceId;
            client.send(req, new ServiceUnsubscribeResponse(_s_, _f_));
        }

        public void subscribe(int serviceId, ServiceSubscribeResponse.Success _s_ =  null, ServiceSubscribeResponse.Fail _f_ =  null) {
            ServiceSubscribeRequest req=new ServiceSubscribeRequest();
            req.serviceId=serviceId;
            client.send(req, new ServiceSubscribeResponse(_s_, _f_));
        }

        public void publishProperty(int serviceId, short index, byte[] data, ServicePublishPropertyResponse.Success _s_ =  null, ServicePublishPropertyResponse.Fail _f_ =  null) {
            ServicePublishPropertyRequest req=new ServicePublishPropertyRequest();
            req.serviceId=serviceId;
            req.index=index;
            req.data=data;
            client.send(req, new ServicePublishPropertyResponse(_s_, _f_));
        }

        public void publish(int serviceId, short typeID, byte[] data, ServicePublishResponse.Success _s_ =  null, ServicePublishResponse.Fail _f_ =  null) {
            ServicePublishRequest req=new ServicePublishRequest();
            req.serviceId=serviceId;
            req.typeID=typeID;
            req.data=data;
            client.send(req, new ServicePublishResponse(_s_, _f_));
        }

        public void onOnSubscribePropertyNotify(ServiceOnSubscribePropertyNotify.OnSubscribePropertyNotify onSubscribePropertyNotify) {
            ServiceOnSubscribePropertyNotify cls=new ServiceOnSubscribePropertyNotify();
            cls.onSubscribePropertyNotify = onSubscribePropertyNotify;
            client.onNotify(cls);
            serviceOnSubscribePropertyNotify= cls;
        }

        public void offOnSubscribePropertyNotify() {
            if (serviceOnSubscribePropertyNotify != null){
                client.offNotify(((serviceOnSubscribePropertyNotify.getClsID()&0xff)<<8)|(serviceOnSubscribePropertyNotify.getMethodID()&0xff));
                serviceOnSubscribePropertyNotify= null;
            }
        }

        public void onOnSubscribeNotify(ServiceOnSubscribeNotify.OnSubscribeNotify onSubscribeNotify) {
            ServiceOnSubscribeNotify cls=new ServiceOnSubscribeNotify();
            cls.onSubscribeNotify = onSubscribeNotify;
            client.onNotify(cls);
            serviceOnSubscribeNotify= cls;
        }

        public void offOnSubscribeNotify() {
            if (serviceOnSubscribeNotify != null){
                client.offNotify(((serviceOnSubscribeNotify.getClsID()&0xff)<<8)|(serviceOnSubscribeNotify.getMethodID()&0xff));
                serviceOnSubscribeNotify= null;
            }
        }
    }
}

