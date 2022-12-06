using System.Collections.Generic;
using network;
using network.entity;
using network.parser;

namespace network.notify
{
    public class SystemEncryptNotify : Notify {
        public EncryptNotify encryptNotify{ set; get; }

        public int userId;

        public byte[] iv;

        public byte[] key;

        public override string getCmd() {
            return "System:EncryptNotify";
        }

        public override byte getClsID() {
            return (byte)255;
        }

        public override byte getMethodID() {
            return (byte)100;
        }

        public delegate void EncryptNotify(int userId, byte[] iv, byte[] key);

        public override void readBin(Block _block) {
            userId=_block.readInt();
            iv=_block.readByteArray();
            key=_block.readByteArray();
        }

        public override void handleResult() {
            encryptNotify?.Invoke( userId ,iv ,key );
        }

        public override Response newInstance() {
            SystemEncryptNotify ins=new SystemEncryptNotify();
            ins.encryptNotify = encryptNotify;
            return ins;
        }
    }
}

