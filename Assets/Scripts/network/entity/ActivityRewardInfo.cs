using System.Collections.Generic;

namespace network.entity
{
    public class ActivityRewardInfo {
        public string sign;

        public string SevenDayLogin;

        public string OnlineReward;

        public long serverTime;

        public string LoginGifts;

        public string getSign() {
            return this.sign;
        }

        public void setSign(string sign) {
            this.sign = sign;
        }

        public string getSevenDayLogin() {
            return this.SevenDayLogin;
        }

        public void setSevenDayLogin(string SevenDayLogin) {
            this.SevenDayLogin = SevenDayLogin;
        }

        public string getOnlineReward() {
            return this.OnlineReward;
        }

        public void setOnlineReward(string OnlineReward) {
            this.OnlineReward = OnlineReward;
        }

        public long getServerTime() {
            return this.serverTime;
        }

        public void setServerTime(long serverTime) {
            this.serverTime = serverTime;
        }

        public string getLoginGifts() {
            return this.LoginGifts;
        }

        public void setLoginGifts(string LoginGifts) {
            this.LoginGifts = LoginGifts;
        }
    }
}

