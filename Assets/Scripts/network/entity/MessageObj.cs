using System.Collections.Generic;

namespace network.entity
{
    public class MessageObj {
        public int id;

        public int owner;

        public int sender;

        public int characteristic;

        public int level;

        public string name;

        public string head;

        public VoiceObj voice;

        public bool readed;

        public long saveTime;

        public int getId() {
            return this.id;
        }

        public void setId(int id) {
            this.id = id;
        }

        public int getOwner() {
            return this.owner;
        }

        public void setOwner(int owner) {
            this.owner = owner;
        }

        public int getSender() {
            return this.sender;
        }

        public void setSender(int sender) {
            this.sender = sender;
        }

        public int getCharacteristic() {
            return this.characteristic;
        }

        public void setCharacteristic(int characteristic) {
            this.characteristic = characteristic;
        }

        public int getLevel() {
            return this.level;
        }

        public void setLevel(int level) {
            this.level = level;
        }

        public string getName() {
            return this.name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public string getHead() {
            return this.head;
        }

        public void setHead(string head) {
            this.head = head;
        }

        public VoiceObj getVoice() {
            return this.voice;
        }

        public void setVoice(VoiceObj voice) {
            this.voice = voice;
        }

        public bool isReaded() {
            return this.readed;
        }

        public void setReaded(bool readed) {
            this.readed = readed;
        }

        public long getSaveTime() {
            return this.saveTime;
        }

        public void setSaveTime(long saveTime) {
            this.saveTime = saveTime;
        }
    }
}

