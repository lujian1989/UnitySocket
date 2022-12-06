using network;
using network.request;
using network.response;

namespace network.service
{
    public class AccountNetService {
        public static AccountNetService ins = new AccountNetService();

        NodeClient client;

        public AccountNetService() {
            client =NodeClient.get("AccountNetService");
        }

        public void resetPwd(int version, string phone, string password, string identityCode, AccountResetPwdResponse.Success _s_ =  null, AccountResetPwdResponse.Fail _f_ =  null) {
            AccountResetPwdRequest req=new AccountResetPwdRequest();
            req.version=version;
            req.phone=phone;
            req.password=password;
            req.identityCode=identityCode;
            client.send(req, new AccountResetPwdResponse(_s_, _f_));
        }

        public void registGuest(int version, AccountRegistGuestResponse.Success _s_ =  null, AccountRegistGuestResponse.Fail _f_ =  null) {
            AccountRegistGuestRequest req=new AccountRegistGuestRequest();
            req.version=version;
            client.send(req, new AccountRegistGuestResponse(_s_, _f_));
        }

        public void regist(int version, string phone, string password, string identityCode, AccountRegistResponse.Success _s_ =  null, AccountRegistResponse.Fail _f_ =  null) {
            AccountRegistRequest req=new AccountRegistRequest();
            req.version=version;
            req.phone=phone;
            req.password=password;
            req.identityCode=identityCode;
            client.send(req, new AccountRegistResponse(_s_, _f_));
        }

        public void login(int version, string phone, string password, AccountLoginResponse.Success _s_ =  null, AccountLoginResponse.Fail _f_ =  null) {
            AccountLoginRequest req=new AccountLoginRequest();
            req.version=version;
            req.phone=phone;
            req.password=password;
            client.send(req, new AccountLoginResponse(_s_, _f_));
        }

        public void deviceIdLogin(int version, string deviceId, AccountDeviceIdLoginResponse.Success _s_ =  null, AccountDeviceIdLoginResponse.Fail _f_ =  null) {
            AccountDeviceIdLoginRequest req=new AccountDeviceIdLoginRequest();
            req.version=version;
            req.deviceId=deviceId;
            client.send(req, new AccountDeviceIdLoginResponse(_s_, _f_));
        }
    }
}

