using System.Collections.Generic;

namespace network.entity
{
    public class ERoomPlayer {
        public int playerId;

        public string name;

        public int status;

        public List<PropertyValue> properties;

        public int getPlayerId() {
            return this.playerId;
        }

        public void setPlayerId(int playerId) {
            this.playerId = playerId;
        }

        public string getName() {
            return this.name;
        }

        public void setName(string name) {
            this.name = name;
        }

        public int getStatus() {
            return this.status;
        }

        public void setStatus(int status) {
            this.status = status;
        }

        public List<PropertyValue> getProperties() {
            return this.properties;
        }

        public void setProperties(List<PropertyValue> properties) {
            this.properties = properties;
        }
    }
}

