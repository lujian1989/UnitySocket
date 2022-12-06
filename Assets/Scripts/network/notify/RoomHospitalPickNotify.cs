using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHospitalPickNotify : Notify {
        public HospitalPickNotify hospitalPickNotify{ set; get; }

        public int target;

        public int dropObjectId;

        public override string getCmd() {
            return "Room:HospitalPickNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)66;
        }

        public delegate void HospitalPickNotify(int target, int dropObjectId);

        public override void readBin(Block _block) {
            target=_block.readInt();
            dropObjectId=_block.readInt();
        }

        public override void handleResult() {
            hospitalPickNotify?.Invoke( target ,dropObjectId );
        }

        public override Response newInstance() {
            RoomHospitalPickNotify ins=new RoomHospitalPickNotify();
            ins.hospitalPickNotify = hospitalPickNotify;
            return ins;
        }
    }
}

