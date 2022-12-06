using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class ShopNetService {
        public static ShopNetService ins = new ShopNetService();

        NodeClient client;

        public ShopNetService() {
            client =NodeClient.get("ShopNetService");
        }

        public void getShopList(ShopGetShopListResponse.Success _s_ =  null, ShopGetShopListResponse.Fail _f_ =  null) {
            ShopGetShopListRequest req=new ShopGetShopListRequest();
            client.send(req, new ShopGetShopListResponse(_s_, _f_));
        }

        public void buyItemByGold(long id, int num, ShopBuyItemByGoldResponse.Success _s_ =  null, ShopBuyItemByGoldResponse.Fail _f_ =  null) {
            ShopBuyItemByGoldRequest req=new ShopBuyItemByGoldRequest();
            req.id=id;
            req.num=num;
            client.send(req, new ShopBuyItemByGoldResponse(_s_, _f_));
        }

        public void buyItem(long id, int num, ShopBuyItemResponse.Success _s_ =  null, ShopBuyItemResponse.Fail _f_ =  null) {
            ShopBuyItemRequest req=new ShopBuyItemRequest();
            req.id=id;
            req.num=num;
            client.send(req, new ShopBuyItemResponse(_s_, _f_));
        }
    }
}

