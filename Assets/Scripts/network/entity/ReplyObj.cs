using System.Collections.Generic;

namespace network.entity
{
    public class ReplyObj {
        public RoleShareInfo replyRole;

        public int bottleId;

        public bool readed;

        public RoleShareInfo getReplyRole() {
            return this.replyRole;
        }

        public void setReplyRole(RoleShareInfo replyRole) {
            this.replyRole = replyRole;
        }

        public int getBottleId() {
            return this.bottleId;
        }

        public void setBottleId(int bottleId) {
            this.bottleId = bottleId;
        }

        public bool isReaded() {
            return this.readed;
        }

        public void setReaded(bool readed) {
            this.readed = readed;
        }
    }
}

