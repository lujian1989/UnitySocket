using network;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class StorageNetService {
        public static StorageNetService ins = new StorageNetService();

        NodeClient client;

        public StorageNetService() {
            client =NodeClient.get("StorageNetService");
        }

        public void setGlobal(string key, byte[] data, StorageSetGlobalResponse.Success _s_ =  null, StorageSetGlobalResponse.Fail _f_ =  null) {
            StorageSetGlobalRequest req=new StorageSetGlobalRequest();
            req.key=key;
            req.data=data;
            client.send(req, new StorageSetGlobalResponse(_s_, _f_));
        }

        public void set(string key, byte[] data, StorageSetResponse.Success _s_ =  null, StorageSetResponse.Fail _f_ =  null) {
            StorageSetRequest req=new StorageSetRequest();
            req.key=key;
            req.data=data;
            client.send(req, new StorageSetResponse(_s_, _f_));
        }

        public void getGlobal(string key, StorageGetGlobalResponse.Success _s_ =  null, StorageGetGlobalResponse.Fail _f_ =  null) {
            StorageGetGlobalRequest req=new StorageGetGlobalRequest();
            req.key=key;
            client.send(req, new StorageGetGlobalResponse(_s_, _f_));
        }

        public void getByUserID(int userID, string key, StorageGetByUserIDResponse.Success _s_ =  null, StorageGetByUserIDResponse.Fail _f_ =  null) {
            StorageGetByUserIDRequest req=new StorageGetByUserIDRequest();
            req.userID=userID;
            req.key=key;
            client.send(req, new StorageGetByUserIDResponse(_s_, _f_));
        }

        public void get(string key, StorageGetResponse.Success _s_ =  null, StorageGetResponse.Fail _f_ =  null) {
            StorageGetRequest req=new StorageGetRequest();
            req.key=key;
            client.send(req, new StorageGetResponse(_s_, _f_));
        }
    }
}

