using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHospitalSavePlayerNotify : Notify {
        public HospitalSavePlayerNotify hospitalSavePlayerNotify{ set; get; }

        public int type;

        public int target;

        public int remainHp;

        public override string getCmd() {
            return "Room:HospitalSavePlayerNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)60;
        }

        public delegate void HospitalSavePlayerNotify(int type, int target, int remainHp);

        public override void readBin(Block _block) {
            type=_block.readInt();
            target=_block.readInt();
            remainHp=_block.readInt();
        }

        public override void handleResult() {
            hospitalSavePlayerNotify?.Invoke( type ,target ,remainHp );
        }

        public override Response newInstance() {
            RoomHospitalSavePlayerNotify ins=new RoomHospitalSavePlayerNotify();
            ins.hospitalSavePlayerNotify = hospitalSavePlayerNotify;
            return ins;
        }
    }
}

