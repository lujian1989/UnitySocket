using System.Collections.Generic;

namespace network.entity
{
    public class MailObj {
        public int id;

        public int sender;

        public string title;

        public string content;

        public int guluCoin;

        public List<ItemObj> items;

        public int accepted;

        public int readed;

        public long sendTime;

        public int getId() {
            return this.id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getSender() {
            return this.sender;
        }

        public void setSender(int sender) {
            this.sender = sender;
        }

        public string getTitle() {
            return this.title;
        }

        public void setTitle(string title) {
            this.title = title;
        }

        public string getContent() {
            return this.content;
        }

        public void setContent(string content) {
            this.content = content;
        }

        public int getGuluCoin() {
            return this.guluCoin;
        }

        public void setGuluCoin(int guluCoin) {
            this.guluCoin = guluCoin;
        }

        public List<ItemObj> getItems() {
            return this.items;
        }

        public void setItems(List<ItemObj> items) {
            this.items = items;
        }

        public int getAccepted() {
            return this.accepted;
        }

        public void setAccepted(int accepted) {
            this.accepted = accepted;
        }

        public int getReaded() {
            return this.readed;
        }

        public void setReaded(int readed) {
            this.readed = readed;
        }

        public long getSendTime() {
            return this.sendTime;
        }

        public void setSendTime(long sendTime) {
            this.sendTime = sendTime;
        }
    }
}

