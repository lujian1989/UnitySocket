using System.Collections.Generic;

namespace network.entity
{
    public class ReplyDialogueObj {
        public int bottleId;

        public bool readed;

        public RoleShareInfo replyRole;

        public List<DialogueObj> dialogues;

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

        public RoleShareInfo getReplyRole() {
            return this.replyRole;
        }

        public void setReplyRole(RoleShareInfo replyRole) {
            this.replyRole = replyRole;
        }

        public List<DialogueObj> getDialogues() {
            return this.dialogues;
        }

        public void setDialogues(List<DialogueObj> dialogues) {
            this.dialogues = dialogues;
        }
    }
}

