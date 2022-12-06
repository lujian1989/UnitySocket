using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnSystemTipNotify : Notify {
        public OnSystemTipNotify onSystemTipNotify{ set; get; }

        public SystemTipInfo tip;

        public override string getCmd() {
            return "Room:OnSystemTipNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)36;
        }

        public delegate void OnSystemTipNotify(SystemTipInfo tip);

        public override void readBin(Block _block) {
            tip=RoomSerializer.readSystemTipInfo(_block);
        }

        public override void handleResult() {
            onSystemTipNotify?.Invoke( tip );
        }

        public override Response newInstance() {
            RoomOnSystemTipNotify ins=new RoomOnSystemTipNotify();
            ins.onSystemTipNotify = onSystemTipNotify;
            return ins;
        }
    }
}

