using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class HallManageNetService {
        public static HallManageNetService ins = new HallManageNetService();

        NodeClient client;

        public HallManageNetService() {
            client =NodeClient.get("HallManageNetService");
        }

        public void getHall(int id, HallManageGetHallResponse.Success _s_ =  null, HallManageGetHallResponse.Fail _f_ =  null) {
            HallManageGetHallRequest req=new HallManageGetHallRequest();
            req.id=id;
            client.send(req, new HallManageGetHallResponse(_s_, _f_));
        }

        public void createHall(string hallName, string hallType, HallManageCreateHallResponse.Success _s_ =  null, HallManageCreateHallResponse.Fail _f_ =  null) {
            HallManageCreateHallRequest req=new HallManageCreateHallRequest();
            req.hallName=hallName;
            req.hallType=hallType;
            client.send(req, new HallManageCreateHallResponse(_s_, _f_));
        }
    }
}

