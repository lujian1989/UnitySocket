using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHospitalDamageNotify : Notify {
        public HospitalDamageNotify hospitalDamageNotify{ set; get; }

        public int type;

        public int id;

        public int remainHp;

        public override string getCmd() {
            return "Room:HospitalDamageNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)73;
        }

        public delegate void HospitalDamageNotify(int type, int id, int remainHp);

        public override void readBin(Block _block) {
            type=_block.readInt();
            id=_block.readInt();
            remainHp=_block.readInt();
        }

        public override void handleResult() {
            hospitalDamageNotify?.Invoke( type ,id ,remainHp );
        }

        public override Response newInstance() {
            RoomHospitalDamageNotify ins=new RoomHospitalDamageNotify();
            ins.hospitalDamageNotify = hospitalDamageNotify;
            return ins;
        }
    }
}

