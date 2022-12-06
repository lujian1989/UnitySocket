using System.Collections.Generic;

namespace network.entity
{
    public class ActivityStatus {
        public bool sign;

        public bool SevenDayLogin;

        public bool OnlineReward;

        public bool LoginGifts;

        public bool isSign() {
            return this.sign;
        }

        public void setSign(bool sign) {
            this.sign = sign;
        }

        public bool isSevenDayLogin() {
            return this.SevenDayLogin;
        }

        public void setSevenDayLogin(bool SevenDayLogin) {
            this.SevenDayLogin = SevenDayLogin;
        }

        public bool isOnlineReward() {
            return this.OnlineReward;
        }

        public void setOnlineReward(bool OnlineReward) {
            this.OnlineReward = OnlineReward;
        }

        public bool isLoginGifts() {
            return this.LoginGifts;
        }

        public void setLoginGifts(bool LoginGifts) {
            this.LoginGifts = LoginGifts;
        }
    }
}

