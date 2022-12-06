using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class RoomOnChangePlayerNetworkStateNotify : Notify {
        public OnChangePlayerNetworkStateNotify onChangePlayerNetworkStateNotify{ set; get; }

        public int changePlayerId;

        public NetworkState networkState;

        public override string getCmd() {
            return "Room:OnChangePlayerNetworkStateNotify";
        }

        public override byte getClsID() {
            return (byte)105;
        }

        public override byte getMethodID() {
            return (byte)54;
        }

        public delegate void OnChangePlayerNetworkStateNotify(int changePlayerId, NetworkState networkState);

        public override void readBin(Block _block) {
            changePlayerId=_block.readInt();
            networkState=(NetworkState)(_block.readShort());
        }

        public override void handleResult() {
            onChangePlayerNetworkStateNotify?.Invoke( changePlayerId ,networkState );
        }

        public override Response newInstance() {
            RoomOnChangePlayerNetworkStateNotify ins=new RoomOnChangePlayerNetworkStateNotify();
            ins.onChangePlayerNetworkStateNotify = onChangePlayerNetworkStateNotify;
            return ins;
        }
    }
}

