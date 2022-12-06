using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHospitalDropObjectExpireNotify : Notify {
        public HospitalDropObjectExpireNotify hospitalDropObjectExpireNotify{ set; get; }

        public int[] dropObjectIds;

        public override string getCmd() {
            return "Room:HospitalDropObjectExpireNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)71;
        }

        public delegate void HospitalDropObjectExpireNotify(int[] dropObjectIds);

        public override void readBin(Block _block) {
            dropObjectIds=_block.readIntArray();
        }

        public override void handleResult() {
            hospitalDropObjectExpireNotify?.Invoke( dropObjectIds );
        }

        public override Response newInstance() {
            RoomHospitalDropObjectExpireNotify ins=new RoomHospitalDropObjectExpireNotify();
            ins.hospitalDropObjectExpireNotify = hospitalDropObjectExpireNotify;
            return ins;
        }
    }
}

