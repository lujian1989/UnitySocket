using System.Collections.Concurrent;
using System.Collections.Generic;

namespace network
{
    public abstract class Channel
    {
        public static Channel createUDPChannel(string ip,int port)
        {
            return new UdpChannel(ip,port);
        }
        
        public static Channel createSocketChannel(string ip,int port)
        {
            return new SocketChannel(ip,port);
        }
        
        public abstract void send(Block block);
        public abstract void send(byte[] data);
        public abstract void close();

        public void interrupted()
        {
            NetManage.ins.channelEvent();
        }
        
        public  ConcurrentQueue<Block> _receivePackage = new  ConcurrentQueue<Block>();  //网络接收的包    
        public void receive(Block block)
        {
            _receivePackage.Enqueue(block);   
        }

  
    }
}