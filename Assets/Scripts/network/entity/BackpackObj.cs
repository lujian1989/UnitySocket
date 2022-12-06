using System.Collections.Generic;

namespace network.entity
{
    public class BackpackObj {
        public int id;

        public int itemCode;

        public int num;

        public int validTime;

        public int sender;

        public string content;

        public int getId() {
            return this.id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getItemCode() {
            return this.itemCode;
        }

        public void setItemCode(int itemCode) {
            this.itemCode = itemCode;
        }

        public int getNum() {
            return this.num;
        }

        public void setNum(int num) {
            this.num = num;
        }

        public int getValidTime() {
            return this.validTime;
        }

        public void setValidTime(int validTime) {
            this.validTime = validTime;
        }

        public int getSender() {
            return this.sender;
        }

        public void setSender(int sender) {
            this.sender = sender;
        }

        public string getContent() {
            return this.content;
        }

        public void setContent(string content) {
            this.content = content;
        }
    }
}

