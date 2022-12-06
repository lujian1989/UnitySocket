using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomHomePhotoFramesUrlNotify : Notify {
        public HomePhotoFramesUrlNotify homePhotoFramesUrlNotify{ set; get; }

        public HomePhotoFramesUrl info;

        public override string getCmd() {
            return "Room:HomePhotoFramesUrlNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)75;
        }

        public delegate void HomePhotoFramesUrlNotify(HomePhotoFramesUrl info);

        public override void readBin(Block _block) {
            info=RoomSerializer.readHomePhotoFramesUrl(_block);
        }

        public override void handleResult() {
            homePhotoFramesUrlNotify?.Invoke( info );
        }

        public override Response newInstance() {
            RoomHomePhotoFramesUrlNotify ins=new RoomHomePhotoFramesUrlNotify();
            ins.homePhotoFramesUrlNotify = homePhotoFramesUrlNotify;
            return ins;
        }
    }
}

