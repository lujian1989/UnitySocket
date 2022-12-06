using network.entity;
using UnityEngine;

namespace network.response
{
    public class DataKeyResponse : StatusResponse
    {
        public Success success { set; get; }

        public int privateKey;
        public int publicKey;
       
        public DataKeyResponse(Success susccess, Fail fail)
        {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd()
        {
            return "Data:Key";
        }

        public override byte getClsID()
        {
            return (byte)0;
        }

        public override byte getMethodID()
        {
            return (byte)0;
        }

        public override void doSuccess()
        {
            success?.Invoke(privateKey);
        }

        public delegate void Success(int privateKey);

        public override void readBin(Block _block)
        {
            privateKey = _block.readInt();
            Debug.Log("privateKey："+privateKey);
            // AwardInfo data = new AwardInfo();
            // data.setUserId(_block.readInt());
            // data.setRank(_block.readInt());
            // data.setGuluCoin(_block.readInt());
            // data.setTip(_block.readString());
            // data.setScore(_block.readInt());
            // reslut =data;
        }
    }
}