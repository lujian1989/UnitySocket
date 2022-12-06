using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnPlayerStatusAndPropertiesChangedNotify : Notify {
        public OnPlayerStatusAndPropertiesChangedNotify onPlayerStatusAndPropertiesChangedNotify{ set; get; }

        public int playerId;

        public int playerStatus;

        public List<PropertyValue> values;

        public override string getCmd() {
            return "Room:OnPlayerStatusAndPropertiesChangedNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)45;
        }

        public delegate void OnPlayerStatusAndPropertiesChangedNotify(int playerId, int playerStatus, List<PropertyValue> values);

        public override void readBin(Block _block) {
            playerId=_block.readInt();
            playerStatus=_block.readInt();
            values=RoomSerializer.readList_PropertyValue_(_block);
        }

        public override void handleResult() {
            onPlayerStatusAndPropertiesChangedNotify?.Invoke( playerId ,playerStatus ,values );
        }

        public override Response newInstance() {
            RoomOnPlayerStatusAndPropertiesChangedNotify ins=new RoomOnPlayerStatusAndPropertiesChangedNotify();
            ins.onPlayerStatusAndPropertiesChangedNotify = onPlayerStatusAndPropertiesChangedNotify;
            return ins;
        }
    }
}

