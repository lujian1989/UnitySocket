using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnShutupNotify : Notify {
        public OnShutupNotify onShutupNotify{ set; get; }

        public byte type;

        public int roomID;

        public int playerId;

        public override string getCmd() {
            return "Room:OnShutupNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)39;
        }

        public delegate void OnShutupNotify(byte type, int roomID, int playerId);

        public override void readBin(Block _block) {
            type=_block.readByte();
            roomID=_block.readInt();
            playerId=_block.readInt();
        }

        public override void handleResult() {
            onShutupNotify?.Invoke( type ,roomID ,playerId );
        }

        public override Response newInstance() {
            RoomOnShutupNotify ins=new RoomOnShutupNotify();
            ins.onShutupNotify = onShutupNotify;
            return ins;
        }
    }
}

