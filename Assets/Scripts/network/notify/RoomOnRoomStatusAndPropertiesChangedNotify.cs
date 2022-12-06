using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnRoomStatusAndPropertiesChangedNotify : Notify {
        public OnRoomStatusAndPropertiesChangedNotify onRoomStatusAndPropertiesChangedNotify{ set; get; }

        public int status;

        public List<PropertyValue> values;

        public int playerId;

        public override string getCmd() {
            return "Room:OnRoomStatusAndPropertiesChangedNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)40;
        }

        public delegate void OnRoomStatusAndPropertiesChangedNotify(int status, List<PropertyValue> values, int playerId);

        public override void readBin(Block _block) {
            status=_block.readInt();
            values=RoomSerializer.readList_PropertyValue_(_block);
            playerId=_block.readInt();
        }

        public override void handleResult() {
            onRoomStatusAndPropertiesChangedNotify?.Invoke( status ,values ,playerId );
        }

        public override Response newInstance() {
            RoomOnRoomStatusAndPropertiesChangedNotify ins=new RoomOnRoomStatusAndPropertiesChangedNotify();
            ins.onRoomStatusAndPropertiesChangedNotify = onRoomStatusAndPropertiesChangedNotify;
            return ins;
        }
    }
}

