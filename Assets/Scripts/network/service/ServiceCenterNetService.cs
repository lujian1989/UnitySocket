using network;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class ServiceCenterNetService {
        public static ServiceCenterNetService ins = new ServiceCenterNetService();

        NodeClient client;

        public ServiceCenterNetService() {
            client =NodeClient.get("ServiceCenterNetService");
        }

        public void test(int[] data, ServiceCenterTestResponse.Success _s_ =  null, ServiceCenterTestResponse.Fail _f_ =  null) {
            ServiceCenterTestRequest req=new ServiceCenterTestRequest();
            req.data=data;
            client.send(req, new ServiceCenterTestResponse(_s_, _f_));
        }

        public void autoCreateAndGetService(string name, ServiceCenterAutoCreateAndGetServiceResponse.Success _s_ =  null, ServiceCenterAutoCreateAndGetServiceResponse.Fail _f_ =  null) {
            ServiceCenterAutoCreateAndGetServiceRequest req=new ServiceCenterAutoCreateAndGetServiceRequest();
            req.name=name;
            client.send(req, new ServiceCenterAutoCreateAndGetServiceResponse(_s_, _f_));
        }
    }
}

