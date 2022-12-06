using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class SystemHostNotify : Notify {
        public HostNotify hostNotify{ set; get; }

        public string name;

        public string host;

        public int port;

        public string serialization;

        public string protocal;

        public int token;

        public override string getCmd() {
            return "System:HostNotify";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)101;
        }

        public delegate void HostNotify(string name, string host, int port, string serialization, string protocal, int token);

        public override void readBin(Block _block) {
            name=_block.readString();
            host=_block.readString();
            port=_block.readInt();
            serialization=_block.readString();
            protocal=_block.readString();
            token=_block.readInt();
        }

        public override void handleResult() {
            hostNotify?.Invoke( name ,host ,port ,serialization ,protocal ,token );
        }

        public override Response newInstance() {
            SystemHostNotify ins=new SystemHostNotify();
            ins.hostNotify = hostNotify;
            return ins;
        }
    }
}

