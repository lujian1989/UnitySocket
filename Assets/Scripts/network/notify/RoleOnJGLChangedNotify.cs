using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoleOnJGLChangedNotify : Notify {
        public OnJGLChangedNotify onJGLChangedNotify{ set; get; }

        public int jgl;

        public override string getCmd() {
            return "Role:OnJGLChangedNotify";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)11;
        }

        public delegate void OnJGLChangedNotify(int jgl);

        public override void readBin(Block _block) {
            jgl=_block.readInt();
        }

        public override void handleResult() {
            onJGLChangedNotify?.Invoke( jgl );
        }

        public override Response newInstance() {
            RoleOnJGLChangedNotify ins=new RoleOnJGLChangedNotify();
            ins.onJGLChangedNotify = onJGLChangedNotify;
            return ins;
        }
    }
}

