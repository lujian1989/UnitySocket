using network;
using network.entity;
using network.notify;
using network.request;
using network.response;

namespace network.service
{
    public class SystemNetService {
        public static SystemNetService ins = new SystemNetService();

        NodeClient client;

        SystemUserOnlineNotify systemUserOnlineNotify;

        SystemLeaveRoomNotify systemLeaveRoomNotify;

        SystemKickNotify systemKickNotify;

        SystemHostNotify systemHostNotify;

        SystemEnterRoomNotify systemEnterRoomNotify;

        SystemEnterHallNotify systemEnterHallNotify;

        SystemEncryptNotify systemEncryptNotify;

        SystemCloseNotify systemCloseNotify;

        public SystemNetService() {
            client =NodeClient.get("SystemNetService");
        }

        public void onUserOnlineNotify(SystemUserOnlineNotify.UserOnlineNotify userOnlineNotify) {
            SystemUserOnlineNotify cls=new SystemUserOnlineNotify();
            cls.userOnlineNotify = userOnlineNotify;
            client.onNotify(cls);
            systemUserOnlineNotify= cls;
        }

        public void offUserOnlineNotify() {
            if (systemUserOnlineNotify != null){
                client.offNotify(((systemUserOnlineNotify.getClsID()&0xff)<<8)|(systemUserOnlineNotify.getMethodID()&0xff));
                systemUserOnlineNotify= null;
            }
        }

        public void reconnect(int userId, int token, int reqIdx, int rspIdx, SystemReconnectResponse.Success _s_ =  null, SystemReconnectResponse.Fail _f_ =  null) {
            SystemReconnectRequest req=new SystemReconnectRequest();
            req.userId=userId;
            req.token=token;
            req.reqIdx=reqIdx;
            req.rspIdx=rspIdx;
            client.send(req, new SystemReconnectResponse(_s_, _f_));
        }

        public void pingpong(SystemPingpongResponse.Success _s_ =  null, SystemPingpongResponse.Fail _f_ =  null) {
            SystemPingpongRequest req=new SystemPingpongRequest();
            client.send(req, new SystemPingpongResponse(_s_, _f_));
        }

        public void offline(SystemOfflineResponse.Success _s_ =  null, SystemOfflineResponse.Fail _f_ =  null) {
            SystemOfflineRequest req=new SystemOfflineRequest();
            client.send(req, new SystemOfflineResponse(_s_, _f_));
        }

        public void login(int version, int userId, int token, SystemLoginResponse.Success _s_ =  null, SystemLoginResponse.Fail _f_ =  null) {
            SystemLoginRequest req=new SystemLoginRequest();
            req.version=version;
            req.userId=userId;
            req.token=token;
            client.send(req, new SystemLoginResponse(_s_, _f_));
        }

        public void onLeaveRoomNotify(SystemLeaveRoomNotify.LeaveRoomNotify leaveRoomNotify) {
            SystemLeaveRoomNotify cls=new SystemLeaveRoomNotify();
            cls.leaveRoomNotify = leaveRoomNotify;
            client.onNotify(cls);
            systemLeaveRoomNotify= cls;
        }

        public void offLeaveRoomNotify() {
            if (systemLeaveRoomNotify != null){
                client.offNotify(((systemLeaveRoomNotify.getClsID()&0xff)<<8)|(systemLeaveRoomNotify.getMethodID()&0xff));
                systemLeaveRoomNotify= null;
            }
        }

        public void leaveRoom(SystemLeaveRoomResponse.Success _s_ =  null, SystemLeaveRoomResponse.Fail _f_ =  null) {
            SystemLeaveRoomRequest req=new SystemLeaveRoomRequest();
            client.send(req, new SystemLeaveRoomResponse(_s_, _f_));
        }

        public void leaveHall(SystemLeaveHallResponse.Success _s_ =  null, SystemLeaveHallResponse.Fail _f_ =  null) {
            SystemLeaveHallRequest req=new SystemLeaveHallRequest();
            client.send(req, new SystemLeaveHallResponse(_s_, _f_));
        }

        public void onKickNotify(SystemKickNotify.KickNotify kickNotify) {
            SystemKickNotify cls=new SystemKickNotify();
            cls.kickNotify = kickNotify;
            client.onNotify(cls);
            systemKickNotify= cls;
        }

        public void offKickNotify() {
            if (systemKickNotify != null){
                client.offNotify(((systemKickNotify.getClsID()&0xff)<<8)|(systemKickNotify.getMethodID()&0xff));
                systemKickNotify= null;
            }
        }

        public void onHostNotify(SystemHostNotify.HostNotify hostNotify) {
            SystemHostNotify cls=new SystemHostNotify();
            cls.hostNotify = hostNotify;
            client.onNotify(cls);
            systemHostNotify= cls;
        }

        public void offHostNotify() {
            if (systemHostNotify != null){
                client.offNotify(((systemHostNotify.getClsID()&0xff)<<8)|(systemHostNotify.getMethodID()&0xff));
                systemHostNotify= null;
            }
        }

        public void onEnterRoomNotify(SystemEnterRoomNotify.EnterRoomNotify enterRoomNotify) {
            SystemEnterRoomNotify cls=new SystemEnterRoomNotify();
            cls.enterRoomNotify = enterRoomNotify;
            client.onNotify(cls);
            systemEnterRoomNotify= cls;
        }

        public void offEnterRoomNotify() {
            if (systemEnterRoomNotify != null){
                client.offNotify(((systemEnterRoomNotify.getClsID()&0xff)<<8)|(systemEnterRoomNotify.getMethodID()&0xff));
                systemEnterRoomNotify= null;
            }
        }

        public void onEnterHallNotify(SystemEnterHallNotify.EnterHallNotify enterHallNotify) {
            SystemEnterHallNotify cls=new SystemEnterHallNotify();
            cls.enterHallNotify = enterHallNotify;
            client.onNotify(cls);
            systemEnterHallNotify= cls;
        }

        public void offEnterHallNotify() {
            if (systemEnterHallNotify != null){
                client.offNotify(((systemEnterHallNotify.getClsID()&0xff)<<8)|(systemEnterHallNotify.getMethodID()&0xff));
                systemEnterHallNotify= null;
            }
        }

        public void onEncryptNotify(SystemEncryptNotify.EncryptNotify encryptNotify) {
            SystemEncryptNotify cls=new SystemEncryptNotify();
            cls.encryptNotify = encryptNotify;
            client.onNotify(cls);
            systemEncryptNotify= cls;
        }

        public void offEncryptNotify() {
            if (systemEncryptNotify != null){
                client.offNotify(((systemEncryptNotify.getClsID()&0xff)<<8)|(systemEncryptNotify.getMethodID()&0xff));
                systemEncryptNotify= null;
            }
        }

        public void onCloseNotify(SystemCloseNotify.CloseNotify closeNotify) {
            SystemCloseNotify cls=new SystemCloseNotify();
            cls.closeNotify = closeNotify;
            client.onNotify(cls);
            systemCloseNotify= cls;
        }

        public void offCloseNotify() {
            if (systemCloseNotify != null){
                client.offNotify(((systemCloseNotify.getClsID()&0xff)<<8)|(systemCloseNotify.getMethodID()&0xff));
                systemCloseNotify= null;
            }
        }
    }
}

