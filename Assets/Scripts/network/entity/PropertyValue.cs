using System.Collections.Generic;

namespace network.entity
{
    public class PropertyValue {
        public byte index;

        public byte[] properties;

        public byte getIndex() {
            return this.index;
        }

        public void setIndex(byte index) {
            this.index = index;
        }

        public byte[] getProperties() {
            return this.properties;
        }

        public void setProperties(byte[] properties) {
            this.properties = properties;
        }
    }
}

