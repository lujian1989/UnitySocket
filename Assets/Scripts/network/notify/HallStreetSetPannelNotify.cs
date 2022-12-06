using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallStreetSetPannelNotify : Notify {
        public StreetSetPannelNotify streetSetPannelNotify{ set; get; }

        public int type;

        public string url;

        public override string getCmd() {
            return "Hall:StreetSetPannelNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)3;
        }

        public delegate void StreetSetPannelNotify(int type, string url);

        public override void readBin(Block _block) {
            type=_block.readInt();
            url=_block.readString();
        }

        public override void handleResult() {
            streetSetPannelNotify?.Invoke( type ,url );
        }

        public override Response newInstance() {
            HallStreetSetPannelNotify ins=new HallStreetSetPannelNotify();
            ins.streetSetPannelNotify = streetSetPannelNotify;
            return ins;
        }
    }
}

