using System.Collections.Generic;

namespace network.entity
{
    public class KillInfo {
        public int attackerUserId;

        public int weaponId;

        public int deaderUserId;

        public int attackKeepKillNum;

        public int attackKillNum;

        public int attackDeadNum;

        public int deaderKillNum;

        public int deaderDeadNum;

        public int getAttackerUserId() {
            return this.attackerUserId;
        }

        public void setAttackerUserId(int attackerUserId) {
            this.attackerUserId = attackerUserId;
        }

        public int getWeaponId() {
            return this.weaponId;
        }

        public void setWeaponId(int weaponId) {
            this.weaponId = weaponId;
        }

        public int getDeaderUserId() {
            return this.deaderUserId;
        }

        public void setDeaderUserId(int deaderUserId) {
            this.deaderUserId = deaderUserId;
        }

        public int getAttackKeepKillNum() {
            return this.attackKeepKillNum;
        }

        public void setAttackKeepKillNum(int attackKeepKillNum) {
            this.attackKeepKillNum = attackKeepKillNum;
        }

        public int getAttackKillNum() {
            return this.attackKillNum;
        }

        public void setAttackKillNum(int attackKillNum) {
            this.attackKillNum = attackKillNum;
        }

        public int getAttackDeadNum() {
            return this.attackDeadNum;
        }

        public void setAttackDeadNum(int attackDeadNum) {
            this.attackDeadNum = attackDeadNum;
        }

        public int getDeaderKillNum() {
            return this.deaderKillNum;
        }

        public void setDeaderKillNum(int deaderKillNum) {
            this.deaderKillNum = deaderKillNum;
        }

        public int getDeaderDeadNum() {
            return this.deaderDeadNum;
        }

        public void setDeaderDeadNum(int deaderDeadNum) {
            this.deaderDeadNum = deaderDeadNum;
        }
    }
}

