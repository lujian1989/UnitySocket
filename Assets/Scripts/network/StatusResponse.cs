
namespace  network
{
    public abstract class StatusResponse:Response
    {
        public byte code;
        public string info;

        public delegate void Fail(int code, string info);
        public Fail fail { set; get; }

        public abstract void doSuccess();

        public override void readRsp(Block block)
        {
            //code = block.readByte();
            //if (code == 0)
            {
                readBin(block);
            }
            // else
            // {
            //     info = block.readString();
            // }
        }


        public override void handleResult()
        {
            if (code == 0)
            {
                doSuccess();
            }
            else
            {
                fail?.Invoke(code, info);
            }
        }

    }

}
