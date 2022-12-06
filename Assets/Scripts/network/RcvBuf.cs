namespace network
{
    public abstract class RcvBuf<T>
    {
        public int bits = 0;
        public T[] pool = new T[16];
	
        public int rcvNxt = 0,rcvMax = 0;
	
        public int getBits() {
            return bits;
        }

        public void put(short sn, T data) {
            int nxt=rcvNxt;
            int max=rcvMax;
            int putSn=sn&0xffff;
		
            if(max<nxt)max+=1<<16;
            if(putSn<nxt)putSn+=(1<<16);
            if(putSn<nxt||putSn>=nxt+16)return ;  //废弃
		
            int putIndex=sn&0xf;
            if(pool[putIndex]!=null)return ; //已经填充
	 	
            if(nxt==putSn) {	
                sequence(sn,data);
			
                ++nxt;
                putIndex=nxt&0xf;
                while(pool[putIndex]!=null) {
                    bits &= ~(1<<putIndex);
                    sequence((short) nxt,pool[putIndex]);
                    pool[putIndex] = default(T);

                    ++nxt;
                    putIndex=nxt&0xf;
                }
			
                rcvNxt = nxt & 0xffff;
                if(nxt>max) {
                    rcvMax = rcvNxt;
                }
            }else {
                pool[putIndex]=data;
                bits |= 1<<putIndex;
                if(putSn>max) {
                    rcvMax = putSn&0xffff;
//				System.out.println("最大值:"+rcvMax);
                }
//			else {
//				System.out.println("插入"+putSn);
//			}
            }
		
        }
	
        public bool checkNext(short sn) {
            return rcvNxt == sn ;
        }
	
        public abstract void sequence(short sn, T data);
    }
}