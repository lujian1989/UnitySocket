namespace network
{
    public abstract class SndBuf <T>{
	
        public int sndUna=0, sndNxt=0;		//未确认,已发送
        public T?[] pool = new T[16];	//缓冲池
        public int ts;
	
        public void ack(int ts, short una, short bits) {
            if(ts<=this.ts) {
                return;		//旧数据丢弃
            }
            this.ts = ts;

            int sndUna = (una&0xffff);
            if(this.sndUna>sndUna)sndUna+=(1<<16);
            
            int releaseIndex;
            for(;this.sndUna<sndUna;) {
                releaseIndex=this.sndUna&0xf;
                if(pool[releaseIndex]!=null) {
                    release(pool[releaseIndex]);
                    pool[releaseIndex]= default(T);
                }
                ++this.sndUna;
            }
            this.sndUna &= 0xffff;
		
            if(bits!=0) {
                if(sndNxt<sndUna)sndNxt+=(1<<16);
                for(;sndUna<sndNxt;) {
                    releaseIndex=sndUna&0xf;
                    if((bits&(1<<releaseIndex))!=0&&pool[releaseIndex]!=null){
                        release(pool[releaseIndex]);
                        pool[releaseIndex]=default(T);
                    }
                    ++sndUna;
                }
                this.sndNxt &= 0xffff;
            }

        }
        public abstract void release(T t);
	
        public void put(T t) {
            int nxt=sndNxt;
            int putIndex=nxt&0xf;
            pool[putIndex]=t;
            this.sndNxt= (nxt+1)&0xffff;
        }
	
        public int freeSize() {
            int una=sndUna;
            int nxt=sndNxt;
		
            if(nxt< una)
                nxt+=(1<<16);
		
            return una + 16 - nxt;
        }
        
    }
}