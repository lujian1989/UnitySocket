using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHospitalDropItemNotify : Notify {
        public HospitalDropItemNotify hospitalDropItemNotify{ set; get; }

        public List<HospitalDropObject> dropObjects;

        public override string getCmd() {
            return "Room:HospitalDropItemNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)72;
        }

        public delegate void HospitalDropItemNotify(List<HospitalDropObject> dropObjects);

        public override void readBin(Block _block) {
            dropObjects=RoomSerializer.readList_HospitalDropObject_(_block);
        }

        public override void handleResult() {
            hospitalDropItemNotify?.Invoke( dropObjects );
        }

        public override Response newInstance() {
            RoomHospitalDropItemNotify ins=new RoomHospitalDropItemNotify();
            ins.hospitalDropItemNotify = hospitalDropItemNotify;
            return ins;
        }
    }
}

