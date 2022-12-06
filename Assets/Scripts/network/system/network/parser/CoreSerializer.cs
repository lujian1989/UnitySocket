using network.entity;

namespace network.parser
{
    public class CoreSerializer : Serializer {

        public static ReconnectResult readReconnectResult(Block block) {
            if(!block.readBoolean()) {return null;}
            
            ReconnectResult data = new ReconnectResult();
            
            data.setRealReqIdx(block.readInt());
            data.setToken(block.readInt());
            
            return data;
        }
    }
}

