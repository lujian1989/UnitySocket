using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class PveNetService {
        public static PveNetService ins = new PveNetService();

        NodeClient client;

        public PveNetService() {
            client =NodeClient.get("PveNetService");
        }

        public void upgradeWeapon(int id, PveUpgradeWeaponResponse.Success _s_ =  null, PveUpgradeWeaponResponse.Fail _f_ =  null) {
            PveUpgradeWeaponRequest req=new PveUpgradeWeaponRequest();
            req.id=id;
            client.send(req, new PveUpgradeWeaponResponse(_s_, _f_));
        }

        public void getWeapons(PveGetWeaponsResponse.Success _s_ =  null, PveGetWeaponsResponse.Fail _f_ =  null) {
            PveGetWeaponsRequest req=new PveGetWeaponsRequest();
            client.send(req, new PveGetWeaponsResponse(_s_, _f_));
        }

        public void getUpWeaponCost(int id, PveGetUpWeaponCostResponse.Success _s_ =  null, PveGetUpWeaponCostResponse.Fail _f_ =  null) {
            PveGetUpWeaponCostRequest req=new PveGetUpWeaponCostRequest();
            req.id=id;
            client.send(req, new PveGetUpWeaponCostResponse(_s_, _f_));
        }

        public void getMaterial(PveGetMaterialResponse.Success _s_ =  null, PveGetMaterialResponse.Fail _f_ =  null) {
            PveGetMaterialRequest req=new PveGetMaterialRequest();
            client.send(req, new PveGetMaterialResponse(_s_, _f_));
        }

        public void getGifts(PveGetGiftsResponse.Success _s_ =  null, PveGetGiftsResponse.Fail _f_ =  null) {
            PveGetGiftsRequest req=new PveGetGiftsRequest();
            client.send(req, new PveGetGiftsResponse(_s_, _f_));
        }

        public void clearData(PveClearDataResponse.Success _s_ =  null, PveClearDataResponse.Fail _f_ =  null) {
            PveClearDataRequest req=new PveClearDataRequest();
            client.send(req, new PveClearDataResponse(_s_, _f_));
        }

        public void changeGift(int sourceId, int targetId, PveChangeGiftResponse.Success _s_ =  null, PveChangeGiftResponse.Fail _f_ =  null) {
            PveChangeGiftRequest req=new PveChangeGiftRequest();
            req.sourceId=sourceId;
            req.targetId=targetId;
            client.send(req, new PveChangeGiftResponse(_s_, _f_));
        }

        public void buyWeapon(int id, PveBuyWeaponResponse.Success _s_ =  null, PveBuyWeaponResponse.Fail _f_ =  null) {
            PveBuyWeaponRequest req=new PveBuyWeaponRequest();
            req.id=id;
            client.send(req, new PveBuyWeaponResponse(_s_, _f_));
        }

        public void addMaterial(int num, PveAddMaterialResponse.Success _s_ =  null, PveAddMaterialResponse.Fail _f_ =  null) {
            PveAddMaterialRequest req=new PveAddMaterialRequest();
            req.num=num;
            client.send(req, new PveAddMaterialResponse(_s_, _f_));
        }

        public void addGuluCoin(int num, PveAddGuluCoinResponse.Success _s_ =  null, PveAddGuluCoinResponse.Fail _f_ =  null) {
            PveAddGuluCoinRequest req=new PveAddGuluCoinRequest();
            req.num=num;
            client.send(req, new PveAddGuluCoinResponse(_s_, _f_));
        }
    }
}

