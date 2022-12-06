using network;

namespace network.service
{
    public class DatingNetService {
        public static DatingNetService ins = new DatingNetService();

        NodeClient client;

        public DatingNetService() {
            client =NodeClient.get("DatingNetService");
        }
    }
}

