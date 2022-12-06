using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoleOnDeclareNotify : Notify {
        public OnDeclareNotify onDeclareNotify{ set; get; }

        public string url;

        public override string getCmd() {
            return "Role:OnDeclareNotify";
        }

        public override byte getClsID() {
            return (byte)95;
        }

        public override byte getMethodID() {
            return (byte)12;
        }

        public delegate void OnDeclareNotify(string url);

        public override void readBin(Block _block) {
            url=_block.readString();
        }

        public override void handleResult() {
            onDeclareNotify?.Invoke( url );
        }

        public override Response newInstance() {
            RoleOnDeclareNotify ins=new RoleOnDeclareNotify();
            ins.onDeclareNotify = onDeclareNotify;
            return ins;
        }
    }
}

