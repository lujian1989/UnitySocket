using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHospitalMonsterNotify : Notify {
        public HospitalMonsterNotify hospitalMonsterNotify{ set; get; }

        public HospitalRefreshObject refreshObjects;

        public override string getCmd() {
            return "Room:HospitalMonsterNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)68;
        }

        public delegate void HospitalMonsterNotify(HospitalRefreshObject refreshObjects);

        public override void readBin(Block _block) {
            refreshObjects=RoomSerializer.readHospitalRefreshObject(_block);
        }

        public override void handleResult() {
            hospitalMonsterNotify?.Invoke( refreshObjects );
        }

        public override Response newInstance() {
            RoomHospitalMonsterNotify ins=new RoomHospitalMonsterNotify();
            ins.hospitalMonsterNotify = hospitalMonsterNotify;
            return ins;
        }
    }
}

