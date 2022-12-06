using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace network
{
    public class SocketChannel : Channel
    {

        private const int bufferSize = 65535;
        private Socket socket;
        public event EventHandler<SocketMessageReceivedFromServer> SocketMessageReceivedFromServer;
        public event EventHandler<CreateConnectionAsyncArgs> CreateConnectCompleted;
        public event EventHandler CloseHandler;
        public event EventHandler ConnectError;
        public event EventHandler ReconnectHandle;

        public SocketChannel()
        {
            
        }

        public SocketChannel(string ip, int port)
        {
            // this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // this.socket.NoDelay = true;
            // IPEndPoint end_point = new IPEndPoint(IPAddress.Parse(ip), port);
            // this.socket.BeginConnect(end_point, new AsyncCallback(this.Connected), this.socket);
            NetManage.ins.ConnectToServer(ip,port);
        }

        public override void send(byte[] packet )
        {
            Debug.Log("real send:"+this.socket.Connected);
            if (this.socket == null)
            {
                if (this.ReconnectHandle != null)
                {
                    this.ReconnectHandle(this, new EventArgs());
                }
                return;
            }
            if (!this.socket.Connected)
            {
                if (this.ReconnectHandle != null)
                {
                    this.ReconnectHandle(this, new EventArgs());
                }
                return;
            }
            this.socket.BeginSend(packet, 0,packet.Length, SocketFlags.None, new AsyncCallback(this.SendMessageToServerComplete), this.socket);

        }

        public override void send(Block block)
        {
          
        }

        public override void close()
        {
            DisConnect();
        }

        /// <summary>
        /// 新建Socket连接
        /// </summary>
        /// <param name="serverAddress">server地址</param>
        /// <param name="port">端口号</param>
        public void CreateConnection(string serverAddress, int port)
        {
            if (this.socket != null && this.socket.Connected)
            {
                
            }

            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.NoDelay = true;
            IPEndPoint end_point = new IPEndPoint(IPAddress.Parse(serverAddress), port);
            this.socket.BeginConnect(end_point, new AsyncCallback(this.Connected), this.socket);
        }

        
        /// <summary>
        /// socket连接创建成功回调
        /// </summary>
        /// <param name="iar"></param>
        private void Connected(IAsyncResult iar)
        {
            try
            {
                if (this.CreateConnectCompleted != null)
                {
                    this.CreateConnectCompleted(this, new CreateConnectionAsyncArgs(true));
                }

                this.socket.EndConnect(iar);
                byte[] array = new byte[bufferSize];
                this.socket.BeginReceive(array, 0, bufferSize, SocketFlags.None, new AsyncCallback(this.KeepConnect),
                    array);
            }
            catch (SocketException)
            {
                if (ConnectError != null)
                {
                    ConnectError(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// 保持socket连接, 一直监听server发过来的消息
        /// </summary>
        /// <param name="iar"></param>
        private void KeepConnect(IAsyncResult iar)
        {
            try
            {
                int num = this.socket.EndReceive(iar);
                if (num > 0)
                {
                    byte[] array = (byte[])iar.AsyncState;
                    if (this.SocketMessageReceivedFromServer != null && array != null)
                    {
                        this.SocketMessageReceivedFromServer(this, new SocketMessageReceivedFromServer(array, num));
                    }

                    array = new byte[bufferSize];
                    this.socket.BeginReceive(array, 0, bufferSize, SocketFlags.None,
                        new AsyncCallback(this.KeepConnect), array);
                }
                else
                {
                    if (this.CloseHandler != null)
                    {
                        this.CloseHandler(this, new EventArgs());
                    }
                }
            }
            catch (SocketException)
            {

            }
        }
        
        private void SendMessageToServerComplete(IAsyncResult iar)
        {
            this.socket.EndSend(iar);
        }
        
        /// <summary>
        /// 销毁socket连接
        /// 
        /// <para>注意：在不需要使用时关闭socket连接</para>
        /// </summary>
        public void DisConnect()
        {
            Debug.LogError("DisConnect:"+socket?.Connected);
            if (this.socket != null && this.socket.Connected)
            {
                try
                {
                    this.socket.Shutdown(SocketShutdown.Both);
                    this.socket.Close();
                    this.socket = null;
                }
                catch
                {
                    this.socket = null;
                }
            }
        }
    }
}