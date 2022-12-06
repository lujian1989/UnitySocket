using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHospitalResultNotify : Notify {
        public HospitalResultNotify hospitalResultNotify{ set; get; }

        public int result;

        public override string getCmd() {
            return "Room:HospitalResultNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)63;
        }

        public delegate void HospitalResultNotify(int result);

        public override void readBin(Block _block) {
            result=_block.readInt();
        }

        public override void handleResult() {
            hospitalResultNotify?.Invoke( result );
        }

        public override Response newInstance() {
            RoomHospitalResultNotify ins=new RoomHospitalResultNotify();
            ins.hospitalResultNotify = hospitalResultNotify;
            return ins;
        }
    }
}

