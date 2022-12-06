using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnRecvFrameNotify : Notify {
        public OnRecvFrameNotify onRecvFrameNotify{ set; get; }

        public Frame frame;

        public override string getCmd() {
            return "Room:OnRecvFrameNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)44;
        }

        public delegate void OnRecvFrameNotify(Frame frame);

        public override void readBin(Block _block) {
            frame=RoomSerializer.readFrame(_block);
        }

        public override void handleResult() {
            onRecvFrameNotify?.Invoke( frame );
        }

        public override Response newInstance() {
            RoomOnRecvFrameNotify ins=new RoomOnRecvFrameNotify();
            ins.onRecvFrameNotify = onRecvFrameNotify;
            return ins;
        }
    }
}

