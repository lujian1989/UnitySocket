
using network.response;
using network.service;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static network.NetConfig;
using Debug = UnityEngine.Debug;

namespace network
{
   public class NetManage
    {
        public static NetManage ins = new NetManage();
        
        public enum State
        {
            STOP,     //停止中
            LOGINING, //登陆中
            LOGINED,  //已登录
        };

        public State state = State.STOP;
        
        public NetManage()
        {
            //changeChannel(false);
        }
        
        internal void update(float deltaTime)
        {
            // if (state == State.STOP) return;
            //
            // if (needChangeChannel) changeChannel(true);
            // if (needChangeSession) changeSession();
            //
            //
            // session.DoFrameUpdate(deltaTime);
            // handleReceive();
            this.dispatcher.IncomingData();
            //AIWorld.instance.update(deltaTime);
        }

        public bool isOutput = true; 
        public void output(Block data)
        {
           // if(rnd.Next(10)<8)  
             if(isOutput)  channel.send(data);
        }
        
        public void send(object msgObject,byte type)
        {
             byte[] messageBytes = DataCenter.PacketBuilder.Build( msgObject,type );
             tcpChannel.send(messageBytes);
           
        }
        public void handleReceive()
        {
            ConcurrentQueue<Block> _receivePackage  = channel._receivePackage;
            Block message;
            _receivePackage.TryDequeue(out message);
            while (message != null)
            {
               if(NetConfig.ISLOG) Debug.Log("1 处理原始Block: size:"+message.readerRemaining());
                session.input(message);
                _receivePackage.TryDequeue(out message);
            }
        }

        public void offline()
        {
            closeNotify();
        }
        
        //session管理-----------------------------------------------
        public Session session;
        public bool needChangeSession=true;
        public void changeSession()
        {
            needChangeSession = false;
            session = new Session();
        }

        public void sessionEvent()
        {
            needChangeSession = true;
        }
        
        //channel管理------------------------------------------------
        public Channel channel;
        public SocketChannel tcpChannel;
        private SocketEventDispatcher dispatcher;  //消息调度处理器
        private bool isConnected = false;
        
        public int channelID = -1;
        public bool needChangeChannel=true;
        
        public void channelEvent()
        {
            needChangeChannel = true;
        }
        public void setChannel(Gate gate)
        {
            if (channel != null)
            {
                
                channel.close();
                channel = null;
            }

            gate.type = "tcp";
            switch (gate.type)
            {
                case "udp":
                    channel = new UdpChannel(gate.host,gate.port);
                    break;
                case "tcp":
                    channel = new SocketChannel(gate.host,gate.port);
                    break;
                case "http":
                    break;
                case "https":
                    break;
                case "websocket":
                    break;
                case "wss":
                    break;
            }
        }

        public Channel getChannel()
        {
            return channel;
        }

        System.Random rnd = new System.Random();
        public void changeChannel(bool force)
        {
            needChangeChannel = false;
           // int channelID = AsgardGame.LocalStorage.GetInt("channel");
            if (channelID > 0)
            {
                if (force)
                {
                    channelID += rnd.Next(9);
                    channelID %= 10;      
                   // AsgardGame.LocalStorage.SetInt("channel",channelID+1);
                }
                else
                {
                    channelID -= 1;
                    if (this.channelID == channelID)
                    {
                        if(NetConfig.ISLOG)Debug.Log("当前ChannelID为: " + channelID+" 不需要切换");
                        return;
                    }
                }
            }
            else
            {
                channelID  = rnd.Next(10);
               // AsgardGame.LocalStorage.SetInt("channel",channelID+1);
            }
            
            Gate[] gates = NetConfig.ins.getAllGates();
            Gate curGate= gates[channelID];
            this.channelID = channelID;
            Debug.Log("切换网络通道:"+curGate.ToString());
            setChannel(curGate);
        }



        #region 原登录相关接口
        //网络登陆接口------------------------------------------------
        public void registGuest(AccountRegistGuestResponse.Success _s_ = null, AccountRegistGuestResponse.Fail _f_ = null)
        {
            switch (state)
            {
                case State.LOGINED:
                    offline();
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.registGuest(NetConfig.version, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.STOP:
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.registGuest(NetConfig.version, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.LOGINING:
                     _f_?.Invoke(-1,"正在登录中,请稍后........");
                    break;
            }

        }

        public void regist(string phone, string password, string identityCode, AccountRegistResponse.Success _s_ = null, AccountRegistResponse.Fail _f_ = null)
        {
            switch (state)
            {
                case State.LOGINED:
                    offline();
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.regist(NetConfig.version, phone, password, identityCode, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.STOP:
                    offline();
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.regist(NetConfig.version, phone, password, identityCode, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.LOGINING:
                    _f_?.Invoke(-1,"正在登录中,请稍后........");
                    break;
            }
           
        }

        public void resetPwd(string phone, string password, string identityCode, AccountResetPwdResponse.Success _s_ = null, AccountResetPwdResponse.Fail _f_ = null)
        {
            switch (state)
            {
                case State.LOGINED:
                    offline();
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.resetPwd(NetConfig.version, phone, password, identityCode, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.STOP:
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.resetPwd(NetConfig.version, phone, password, identityCode, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.LOGINING:
                    _f_?.Invoke(-1,"正在登录中,请稍后........");
                    break;
            }

        }

        public void login(string phone, string password, AccountLoginResponse.Success _s_ = null, AccountLoginResponse.Fail _f_ = null)
        {
            switch (state)
            {
                case State.LOGINED:
                    offline();
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.login(NetConfig.version, phone, password, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.STOP:
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.login(NetConfig.version, phone, password, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.LOGINING:
                    _f_?.Invoke(-1,"正在登录中,请稍后........");
                    break;
            }

        }

        public void deviceIdLogin(string deviceId, AccountDeviceIdLoginResponse.Success _s_ = null, AccountDeviceIdLoginResponse.Fail _f_ = null)
        {
            switch (state)
            {
                case State.LOGINED:
                    offline();
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.deviceIdLogin(NetConfig.version, deviceId, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.STOP:
                    changeChannel(false);
                    changeSession();
                    AccountNetService.ins.deviceIdLogin(NetConfig.version, deviceId, _s_, _f_);
                    state = State.LOGINING;
                    break;
                case State.LOGINING:
                    _f_?.Invoke(-1,"正在登录中,请稍后........");
                    break;
            }
        }
        
        #endregion
        //回调接口-----------------------------------------------------------------
        #region 原掉线超时处理
        
        public Action OnKick { get; set; }
        public Action OnNetClose { get; set; }
        public Action OnInvalidUser { get; set; }

       
        public bool isTimeout2=false, isTimeout5=false, isTimeout10=false;
        public Action OnNetTimeout2 { get; set; }
        public Action OnNetTimeout5 { get; set; }
        public Action OnNetTimeout10 { get; set; }


        public void timeoutReset()
        {
            isTimeout2 = false;
            isTimeout5 = false; 
            isTimeout10=false;
        }
        
        public void timeout2Notify()
        {
            if (isTimeout2) return;

            isTimeout2 = true;
            this.OnNetTimeout2?.Invoke();
            
            Debug.Log("timeout2Notify------------------");
        }
        
        public void timeout5Notify()
        {
            if (isTimeout5) return;

            isTimeout5 = true;
            this.OnNetTimeout5?.Invoke();
            
            Debug.Log("timeout5Notify------------------");
        }
        
        
        public void timeout10Notify()
        {
            if (isTimeout10) return;
            
            isTimeout10 = true;
            this.OnNetTimeout10?.Invoke();
            Debug.Log("timeout10Notify------------------");
        }
        
        public void kickNotify()
        {
            Debug.Log("被踢通知------------");
            state = State.STOP;
            NodeClient.ins.timeout();
            this.OnKick?.Invoke();
        }

        public void closeNotify()
        {
            Debug.Log("主动关闭------------");
            state = State.STOP;
            NodeClient.ins.timeout();
            this.OnNetClose?.Invoke();
        }
        
        public void leaveRoomNotify()
        {
            this.OnInvalidUser?.Invoke();
        }

        
        
        public int userId;
        public byte[] iv;
        public byte[] key;

        bool hasEncryptInfo;
        bool isLogin = false;
        int loginTime;
        public void resetEncryptInfo(int userId, byte[] iv, byte[] key)
        {
            this.userId = userId;
            this.iv = iv;
            this.key = key;

            // AsgardGame.LocalStorage.SetInt("EdenUser", userId);
            // AsgardGame.LocalStorage.SetString("EdenIv", Convert.ToBase64String(iv));
            // AsgardGame.LocalStorage.SetString("EdenKey", Convert.ToBase64String(key));

            Debug.Log("Login success:"+this.userId );

            hasEncryptInfo = true;
            state = State.LOGINED;
        }
        #endregion
        public void closeAllSever()
        {

        }
        
        private void OnCreateConnectionComplete( object sender, CreateConnectionAsyncArgs e ) {
            isConnected = true;
        }

        public void OnReceiveMessageFromServer(object sender,SocketMessageReceivedFromServer e) {
            this.dispatcher.AddData( e.Message, e.BytesTransferred );
        }

        private void CloseHandler( object sender, EventArgs e ) {
            isConnected = false;
            Debug.Log("CloseHandler");
        }

        private void ConnectError( object sender, EventArgs e ) {
            Debug.Log("ConnectError");
        }
        public void InitClient() {
            SocketCallBack callback = new SocketCallBack();
            callback.callback += GetServerMessage;
            TCPCMDProcess process = new TCPCMDProcess( callback );
            this.dispatcher = new SocketEventDispatcher( process );
            this.tcpChannel = new SocketChannel();
            
            this.tcpChannel.SocketMessageReceivedFromServer += new System.EventHandler<SocketMessageReceivedFromServer>( this.OnReceiveMessageFromServer );
            this.tcpChannel.CreateConnectCompleted += new EventHandler<CreateConnectionAsyncArgs>( this.OnCreateConnectionComplete );
            this.tcpChannel.CloseHandler += new EventHandler( this.CloseHandler );
            this.tcpChannel.ConnectError += new EventHandler( this.ConnectError );
        }


        public void ConnectToServer( string ip, int port ) {
            if ( this.channel == null ) {
                InitClient();
            }
            this.tcpChannel.CreateConnection( ip, port );
        }


        /// <summary>
        /// 当消息来自服务器后，此函数被DemoCMDProcess 回调，数据包被传入解析并派发
        /// </summary>
        /// <param name="data">一个完整的消息数据包</param>
        private void GetServerMessage(byte[] data) {
            Debug.Log("GetServerMessage");
            DataCenter.PacketParser.Parse( data );
        }


        // /// <summary>
        // /// 将定义好的 protobuf 消息对象发给服务器
        // /// </summary>
        // /// <param name="messageObject"></param>
        // public void SendMessage( object messageObject ) {
        //     byte[] messageBytes = DataCenter.PacketBuilder.Build( messageObject );
        //     //this.tcpChannel.SendMessageToServer( messageBytes );
        // }
    }
   
}
