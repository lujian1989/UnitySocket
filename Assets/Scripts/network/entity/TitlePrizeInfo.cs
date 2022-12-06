using System.Collections.Generic;

namespace network.entity
{
    public class TitlePrizeInfo {
        public int userId;

        public string name;

        public int titleId;

        public int getUserId() {
            return this.userId;
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public string getName() {
            return this.name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public int getTitleId() {
            return this.titleId;
        }

        public void setTitleId(int titleId) {
            this.titleId = titleId;
        }
    }
}

