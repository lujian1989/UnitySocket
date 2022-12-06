using System.Collections.Generic;
using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class FriendNetService {
        public static FriendNetService ins = new FriendNetService();

        NodeClient client;

        FriendNewFriendNotify friendNewFriendNotify;

        FriendNewApplyNotify friendNewApplyNotify;

        FriendFriendInfoNotify friendFriendInfoNotify;

        FriendDeleteNotify friendDeleteNotify;

        public FriendNetService() {
            client =NodeClient.get("FriendNetService");
        }

        public void search(string content, FriendSearchResponse.Success _s_ =  null, FriendSearchResponse.Fail _f_ =  null) {
            FriendSearchRequest req=new FriendSearchRequest();
            req.content=content;
            client.send(req, new FriendSearchResponse(_s_, _f_));
        }

        public void onNewFriendNotify(FriendNewFriendNotify.NewFriendNotify newFriendNotify) {
            FriendNewFriendNotify cls=new FriendNewFriendNotify();
            cls.newFriendNotify = newFriendNotify;
            client.onNotify(cls);
            friendNewFriendNotify= cls;
        }

        public void offNewFriendNotify() {
            if (friendNewFriendNotify != null){
                client.offNotify(((friendNewFriendNotify.getClsID()&0xff)<<8)|(friendNewFriendNotify.getMethodID()&0xff));
                friendNewFriendNotify= null;
            }
        }

        public void onNewApplyNotify(FriendNewApplyNotify.NewApplyNotify newApplyNotify) {
            FriendNewApplyNotify cls=new FriendNewApplyNotify();
            cls.newApplyNotify = newApplyNotify;
            client.onNotify(cls);
            friendNewApplyNotify= cls;
        }

        public void offNewApplyNotify() {
            if (friendNewApplyNotify != null){
                client.offNotify(((friendNewApplyNotify.getClsID()&0xff)<<8)|(friendNewApplyNotify.getMethodID()&0xff));
                friendNewApplyNotify= null;
            }
        }

        public void isFriend(int userId, FriendIsFriendResponse.Success _s_ =  null, FriendIsFriendResponse.Fail _f_ =  null) {
            FriendIsFriendRequest req=new FriendIsFriendRequest();
            req.userId=userId;
            client.send(req, new FriendIsFriendResponse(_s_, _f_));
        }

        public void getFriends(FriendGetFriendsResponse.Success _s_ =  null, FriendGetFriendsResponse.Fail _f_ =  null) {
            FriendGetFriendsRequest req=new FriendGetFriendsRequest();
            client.send(req, new FriendGetFriendsResponse(_s_, _f_));
        }

        public void getFriendInfo(int userId, FriendGetFriendInfoResponse.Success _s_ =  null, FriendGetFriendInfoResponse.Fail _f_ =  null) {
            FriendGetFriendInfoRequest req=new FriendGetFriendInfoRequest();
            req.userId=userId;
            client.send(req, new FriendGetFriendInfoResponse(_s_, _f_));
        }

        public void getBlacks(FriendGetBlacksResponse.Success _s_ =  null, FriendGetBlacksResponse.Fail _f_ =  null) {
            FriendGetBlacksRequest req=new FriendGetBlacksRequest();
            client.send(req, new FriendGetBlacksResponse(_s_, _f_));
        }

        public void getApplys(FriendGetApplysResponse.Success _s_ =  null, FriendGetApplysResponse.Fail _f_ =  null) {
            FriendGetApplysRequest req=new FriendGetApplysRequest();
            client.send(req, new FriendGetApplysResponse(_s_, _f_));
        }

        public void onFriendInfoNotify(FriendFriendInfoNotify.FriendInfoNotify friendInfoNotify) {
            FriendFriendInfoNotify cls=new FriendFriendInfoNotify();
            cls.friendInfoNotify = friendInfoNotify;
            client.onNotify(cls);
            friendFriendInfoNotify= cls;
        }

        public void offFriendInfoNotify() {
            if (friendFriendInfoNotify != null){
                client.offNotify(((friendFriendInfoNotify.getClsID()&0xff)<<8)|(friendFriendInfoNotify.getMethodID()&0xff));
                friendFriendInfoNotify= null;
            }
        }

        public void onDeleteNotify(FriendDeleteNotify.DeleteNotify deleteNotify) {
            FriendDeleteNotify cls=new FriendDeleteNotify();
            cls.deleteNotify = deleteNotify;
            client.onNotify(cls);
            friendDeleteNotify= cls;
        }

        public void offDeleteNotify() {
            if (friendDeleteNotify != null){
                client.offNotify(((friendDeleteNotify.getClsID()&0xff)<<8)|(friendDeleteNotify.getMethodID()&0xff));
                friendDeleteNotify= null;
            }
        }

        public void delete(int userId, FriendDeleteResponse.Success _s_ =  null, FriendDeleteResponse.Fail _f_ =  null) {
            FriendDeleteRequest req=new FriendDeleteRequest();
            req.userId=userId;
            client.send(req, new FriendDeleteResponse(_s_, _f_));
        }

        public void confirm(int userId, bool isAgree, FriendConfirmResponse.Success _s_ =  null, FriendConfirmResponse.Fail _f_ =  null) {
            FriendConfirmRequest req=new FriendConfirmRequest();
            req.userId=userId;
            req.isAgree=isAgree;
            client.send(req, new FriendConfirmResponse(_s_, _f_));
        }

        public void cancelBlack(int userId, FriendCancelBlackResponse.Success _s_ =  null, FriendCancelBlackResponse.Fail _f_ =  null) {
            FriendCancelBlackRequest req=new FriendCancelBlackRequest();
            req.userId=userId;
            client.send(req, new FriendCancelBlackResponse(_s_, _f_));
        }

        public void black(int userId, FriendBlackResponse.Success _s_ =  null, FriendBlackResponse.Fail _f_ =  null) {
            FriendBlackRequest req=new FriendBlackRequest();
            req.userId=userId;
            client.send(req, new FriendBlackResponse(_s_, _f_));
        }

        public void apply(int userId, FriendApplyResponse.Success _s_ =  null, FriendApplyResponse.Fail _f_ =  null) {
            FriendApplyRequest req=new FriendApplyRequest();
            req.userId=userId;
            client.send(req, new FriendApplyResponse(_s_, _f_));
        }
    }
}

