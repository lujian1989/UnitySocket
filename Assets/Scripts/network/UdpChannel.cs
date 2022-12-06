using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Collections.Concurrent;
using UnityEngine;


namespace network
{
    public class UdpChannel:Channel
    {
        public Socket socket;
        public IPEndPoint client,server;
        
        public Thread connectThread;
        public UdpChannel(string host, int port)
        {
            client = new IPEndPoint(IPAddress.Any, 0);
            server = new IPEndPoint(IPAddress.Parse(host), port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(client);

            connectThread = new Thread(new ThreadStart(SocketReceive));
            connectThread.Start();
        }
        

        public override void send(Block block)
        {
            send(block.getData(),block.writerPosition());
        }

        public override void send(byte[] data)
        {
            
        }

        public void send(byte[] data,int length)
        {
            socket.SendTo(data, length, SocketFlags.None, server);
        }

        void SocketReceive()
        {
            int recvLen = 0;
            EndPoint serverEnd = new IPEndPoint(IPAddress.Any, 0);
            while (connectThread!=null)
            {
                try
                {
                    byte[] recvData = new byte[NetConfig.MTU];
                    recvLen = socket.ReceiveFrom(recvData, ref serverEnd);
                    if (recvLen > 0)
                    {
                        Block block = new Block(recvData);
                        block.setWriterPosition(recvLen);
                        receive(block);
                    }
                }
                catch (Exception e)
                {
                    
                }
            }
            Debug.Log("Thread stop!!!!!!!");
        }
        
        
        //连接关闭
        public override void close()
        {
            //关闭线程
            if (connectThread != null)
            {
                connectThread.Interrupt();
                connectThread = null;
            }

            //最后关闭socket
            if (socket != null)
            {
                socket.Close();
                socket = null;
            }
        }
        
        
    }
}