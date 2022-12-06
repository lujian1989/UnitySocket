using network;
using network.request;
using network.response;

namespace network.service
{
    public class ActivityNetService {
        public static ActivityNetService ins = new ActivityNetService();

        NodeClient client;

        public ActivityNetService() {
            client =NodeClient.get("ActivityNetService");
        }
    }
}

