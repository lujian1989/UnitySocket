using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnObjectStatusAndPropertiesChangedNotify : Notify {
        public OnObjectStatusAndPropertiesChangedNotify onObjectStatusAndPropertiesChangedNotify{ set; get; }

        public int objId;

        public int status;

        public List<PropertyValue> values;

        public override string getCmd() {
            return "Room:OnObjectStatusAndPropertiesChangedNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)46;
        }

        public delegate void OnObjectStatusAndPropertiesChangedNotify(int objId, int status, List<PropertyValue> values);

        public override void readBin(Block _block) {
            objId=_block.readInt();
            status=_block.readInt();
            values=RoomSerializer.readList_PropertyValue_(_block);
        }

        public override void handleResult() {
            onObjectStatusAndPropertiesChangedNotify?.Invoke( objId ,status ,values );
        }

        public override Response newInstance() {
            RoomOnObjectStatusAndPropertiesChangedNotify ins=new RoomOnObjectStatusAndPropertiesChangedNotify();
            ins.onObjectStatusAndPropertiesChangedNotify = onObjectStatusAndPropertiesChangedNotify;
            return ins;
        }
    }
}

