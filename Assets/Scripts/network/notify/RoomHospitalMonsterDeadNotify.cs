using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHospitalMonsterDeadNotify : Notify {
        public HospitalMonsterDeadNotify hospitalMonsterDeadNotify{ set; get; }

        public int weaponId;

        public int monsterObjectId;

        public List<HospitalDropObject> dropObjects;

        public override string getCmd() {
            return "Room:HospitalMonsterDeadNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)69;
        }

        public delegate void HospitalMonsterDeadNotify(int weaponId, int monsterObjectId, List<HospitalDropObject> dropObjects);

        public override void readBin(Block _block) {
            weaponId=_block.readInt();
            monsterObjectId=_block.readInt();
            dropObjects=RoomSerializer.readList_HospitalDropObject_(_block);
        }

        public override void handleResult() {
            hospitalMonsterDeadNotify?.Invoke( weaponId ,monsterObjectId ,dropObjects );
        }

        public override Response newInstance() {
            RoomHospitalMonsterDeadNotify ins=new RoomHospitalMonsterDeadNotify();
            ins.hospitalMonsterDeadNotify = hospitalMonsterDeadNotify;
            return ins;
        }
    }
}

