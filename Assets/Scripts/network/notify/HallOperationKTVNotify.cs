using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class HallOperationKTVNotify : Notify {
        public OperationKTVNotify operationKTVNotify{ set; get; }

        public bool oper;

        public override string getCmd() {
            return "Hall:OperationKTVNotify";
        }

        public override byte getClsID() {
            return (byte)232;
        }

        public override byte getMethodID() {
            return (byte)19;
        }

        public delegate void OperationKTVNotify(bool oper);

        public override void readBin(Block _block) {
            oper=_block.readBoolean();
        }

        public override void handleResult() {
            operationKTVNotify?.Invoke( oper );
        }

        public override Response newInstance() {
            HallOperationKTVNotify ins=new HallOperationKTVNotify();
            ins.operationKTVNotify = operationKTVNotify;
            return ins;
        }
    }
}

