using System.Collections.Generic;

namespace network.entity
{
    public class SystemTipInfo {
        public byte type;

        public int sender;

        public string content;

        public int interval;

        public int count;

        public byte getType() {
            return this.type;
        }

        public void setType(byte type) {
            this.type = type;
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

        public int getInterval() {
            return this.interval;
        }

        public void setInterval(int interval) {
            this.interval = interval;
        }

        public int getCount() {
            return this.count;
        }

        public void setCount(int count) {
            this.count = count;
        }
    }
}

