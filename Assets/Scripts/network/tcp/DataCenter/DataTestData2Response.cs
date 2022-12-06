using network.entity;
using UnityEngine;

namespace network.response
{
    public class DataTestData2Response : StatusResponse
    {
        public Success success { set; get; }
     
        public string str;
        public DataTestData2Response(Success susccess, Fail fail)
        {
            this.success = susccess;
            this.fail = fail;
        }

        public override string getCmd()
        {
            return "Data:TestData2";
        }

        public override byte getClsID()
        {
            return (byte)100;
        }

        public override byte getMethodID()
        {
            return (byte)100;
        }

        public override void doSuccess()
        {
            success?.Invoke(str);
        }

        public delegate void Success(string reslut);

        public override void readBin(Block _block)
        {
            str = _block.readString();
            Debug.Log("readBin："+str);
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