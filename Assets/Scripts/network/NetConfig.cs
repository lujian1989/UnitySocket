using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace network
{
    public class NetConfig
    {
        public static NetConfig ins = new NetConfig();

        public const int version = 1300;            //版本号
        
        public const int ConnectReqTime      = 1000;     //连接请求时间
        public const int ChangeChannelCount  = 3;        //切换通道次数
        public const int ConnectTimeout      = 5000;     //连接超时时间
        
        public const int IdleReqTime = 2000;        //超时ping发送时间
        public const int SessionTimeout = 40000;    //断线时间
        
        public const int SegHead = 17;
        public const int MTU = 1360;
        public const int MSS = MTU - SegHead;

        public const bool ISLOG = false; 
        
        //public const string host = "192.168.50.192"; //svn 服务器
        //public const string host = "192.168.50.41"; //海哥
        //public  const string host="111.229.213.63"; //正式服务器
        //public const string host = "192.168.50.33"; //tanzai 
        //public const string host = "127.0.0.1";
        //public const string host = "1000.mangoxr.cn"; //正式服务器
        //public static string[] host = {   //tanzai 
        //  "192.168.50.33",// gate0
        //  "192.168.50.33",// gate1
        //  "192.168.50.33",// gate2
        //  "192.168.50.33",//gate3
        //  "192.168.50.33",//gate4
  
        //  "192.168.50.33",//gate5
        //  "192.168.50.33",//gate6
        //  "192.168.50.33",//gate7
        //  "192.168.50.33",//gate8
        //  "192.168.50.33",//gate9
        //};

        // public string[] host = {   //海哥 
        //   "192.168.50.204",// gate0
        //   "192.168.50.204",// gate1
        //   "192.168.50.204",// gate2
        //   "192.168.50.204",//gate3
        //   "192.168.50.204",//gate4
        //
        //   "192.168.50.204",//gate5
        //   "192.168.50.204",//gate6
        //   "192.168.50.204",//gate7
        //   "192.168.50.204",//gate8
        //   "192.168.50.204",//gate9
        // };
        
        public string[] host = {   //海哥 
            "127.0.0.1",// gate0
            "127.0.0.1",// gate1
            "127.0.0.1",// gate2
            "127.0.0.1",//gate3
            "127.0.0.1",//gate4
  
            "127.0.0.1",//gate5
            "127.0.0.1",//gate6
            "127.0.0.1",//gate7
            "127.0.0.1",//gate8
            "127.0.0.1",//gate9
        };
        
    public class Gate
        {
            public string name = "Gate";
            public string host = "127.0.0.1";
            public int port = 18421;
            public string type = "udp";

            public Gate(string name, string host, int port, string type)
            {
                this.name = name;
                this.host = host;
                this.port = port;
                this.type = type;
            }

            public override string ToString()
            {
                return "Gate name:" + name + " host:" + host + " port:" + port + " type:"+type;
            }
        }

        public Gate[] getAllGates()
        {
            return new Gate[] {
                 new Gate("gate0",host[0],8052,"tcp"),
                 new Gate("gate1",host[1],8052,"tcp"),
                 new Gate("gate2",host[2],8052,"tcp"),
                 new Gate("gate3",host[3],8052,"tcp"),
                 new Gate("gate4",host[4],8052,"tcp"),
                 new Gate("gate5",host[5],8052,"tcp"),
                 new Gate("gate6",host[6],8052,"tcp"),
                 new Gate("gate7",host[7],8052,"tcp"),
                 new Gate("gate8",host[8],8052,"tcp"),
                 new Gate("gate9",host[9],8052,"tcp"),
            };
        }


    }
}
