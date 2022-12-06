
namespace  network
{
    public abstract class Response
    {

        public short sn = 0;

        public abstract void readBin(Block block);

        public abstract string getCmd();
        public abstract byte getClsID();
        public abstract byte getMethodID();

        public virtual void readRsp(Block block)
        {
            readBin(block);
        }

        public virtual bool isNotify()
        {
            return false;
        }

        public abstract void handleResult();


        public virtual Response newInstance()
        {
            return this;
        }

    }

}
