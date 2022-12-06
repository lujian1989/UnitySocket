using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace network
{
    public abstract class Request
    {

        public short sn = -1;
 

        public abstract String getCmd();
        public abstract byte getClsID();
        public abstract byte getMethodID();

        public abstract void writeBin(Block block);

        public abstract int getBinLength ();

        public virtual  byte end()
        {
            return 1;
        }
        
        public virtual  byte getType()
        {
            return (byte)NET_CMD_TYPE.OLD;
        }
        public virtual byte isCompress()
        {
            return 0;
        }
        
    }
}
