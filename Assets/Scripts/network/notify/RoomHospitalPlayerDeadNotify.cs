using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHospitalPlayerDeadNotify : Notify {
        public HospitalPlayerDeadNotify hospitalPlayerDeadNotify{ set; get; }

        public int target;

        public override string getCmd() {
            return "Room:HospitalPlayerDeadNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)64;
        }

        public delegate void HospitalPlayerDeadNotify(int target);

        public override void readBin(Block _block) {
            target=_block.readInt();
        }

        public override void handleResult() {
            hospitalPlayerDeadNotify?.Invoke( target );
        }

        public override Response newInstance() {
            RoomHospitalPlayerDeadNotify ins=new RoomHospitalPlayerDeadNotify();
            ins.hospitalPlayerDeadNotify = hospitalPlayerDeadNotify;
            return ins;
        }
    }
}

