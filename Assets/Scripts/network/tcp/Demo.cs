using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using network;
using network.entity;
using network.request;
using network.response;
using network.service;
using network.tcp.DataCenter;
using NewProto;

public class Demo : MonoBehaviour {

    private SocketChannel client;
    private SocketEventDispatcher diapatcher;

    public static int packetLength;

	// Use this for initialization
	void Start () {
        SocketCallBack callback = new SocketCallBack();
        callback.callback += GetServerMessage;
        TCPCMDProcess process = new TCPCMDProcess(callback);
        this.diapatcher = new SocketEventDispatcher(process);
        this.client = new SocketChannel();
        this.client.SocketMessageReceivedFromServer += new EventHandler<SocketMessageReceivedFromServer>(this.OnReceiveMessageFromServer);
        this.client.CreateConnectCompleted += new EventHandler<CreateConnectionAsyncArgs>(this.OnCreateConnectionComplete);
        this.client.CloseHandler += new EventHandler(this.CloseHandler);
        this.client.ConnectError += new EventHandler(this.ConnectError);
        
        
	}

    private void OnDestroy()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.diapatcher.IncomingData();
    }

    bool isConnnect = true;
    string inputTest = "input string to send.";
    string serverStr = string.Empty;
	
    void OnGUI()
    {
        if (isConnnect)
        {
            if (GUI.Button(new Rect(10, 10, 200, 50), "OpenConnect"))
            {
                NetManage.ins.tcpChannel = client;
                 client.CreateConnection(  "127.0.0.1",  8052); 
                 //  client.CreateConnection("192.168.50.146", 10001);
            }
        }
        else
        {
            if (GUI.Button(new Rect(10, 10, 200, 50), "CloseConnect"))
            {
                this.client.DisConnect();
            }

            inputTest = GUI.TextField(new Rect(10, 100, 400, 20), inputTest);

            if (GUI.Button(new Rect(10, 200, 200, 50), "客户端->服务器"))
            {
                // PacketReader rsp1 = new PacketReader();
                // // DataTestData2Request req=new DataTestData2Request();
                // DataTestData2Response rsp = new DataTestData2Response((reslut) =>
                // {
                //     Debug.Log("Success!!!!!"+reslut);
                //     
                // }, (code, info) =>
                // {
                //     Debug.Log("Fail!!!!!" + code + "  info:" + info);
                // });
                // //
                // // NodeClient.ins.send(req,rsp);
                // // Debug.Log("send");
                //
                // PacketWriter pw = new PacketWriter();
                // pw.clsID = 100;
                // pw.methodID = 100;
                // Request_Test_100_101 protoData = new Request_Test_100_101();
                // protoData.Account = "ASDASD";
                // protoData.Password = "123456";
                // pw.protoData = protoData;
                //
                // NodeClient.ins.send(pw,rsp1);

                // byte[] a =new byte[]
                // {
                //     100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54,100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54,100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54,100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54,100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54,100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54,100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54,100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54,100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54,100,100,10,6,65,83,68,65,83,68,18,6,49,50,51,52,53,54
                // };
                // bool end =  true;
                // BigPacketReader rsp1 = new BigPacketReader();
                // BigPacketWriter bigPacketWriter = new BigPacketWriter();
                // bigPacketWriter.clsID = 101;
                // bigPacketWriter.methodID = 101;
                // bigPacketWriter.isEnd = (byte)(end == true?1:0);
                // Debug.Log("aaa.："+end);
                // bigPacketWriter.body = a;
                //  NodeClient.ins.send(bigPacketWriter,rsp1);
                
                // for (int i = 0; i < 10; i++)
                // {
                //     Response_Test responseTest = new Response_Test(Callback_Player); //注册响应
                //     Request_Test_100_101 protoData = new Request_Test_100_101();
                //     protoData.Account = "ASDASD"+i;
                //     protoData.Password = "123456"+i;
                //     byte[] MsgBody = NetUtilcs.Serialize(protoData);
                //     NetUtilcs.PacketMsg<Request_Test>(MsgBody,responseTest,(byte)NET_CMD_TYPE.PB);
                // }
                string ppath = Application.persistentDataPath;
                var buffer = File.ReadAllBytes(ppath + "/log4j2.xml");
                string str = System.Text.Encoding.UTF8.GetString(buffer);
                List<byte[]> list = new List<byte[]>();
                
                for (int i = 0; i < 10; i++)
                {
                    Response_Test responseTest  = new Response_Test(Callback_Player,true);
                    Request_Test pw = new Request_Test();
                    Request_Test_100_101 protoData = new Request_Test_100_101();
                    protoData.Account = "ASDASD" + i * 1000;
                    protoData.Password = str;
                    pw.isEnd = 1;
                    pw.compress = 0;
                    pw.SetBodyData(protoData);
                    byte[] temp = DataCenter.PacketBuilder.Build(pw, (byte)NET_CMD_TYPE.PB, false);
                    list.Add(temp);
                }
                byte[] allMsg = list
                    .SelectMany(a => a)
                    .ToArray();
                NetUtilcs.PacketMsg<BigPacketWriter>(allMsg,null,(byte)NET_CMD_TYPE.COUSTOM);
            }

            
            if (GUI.Button(new Rect(10, 260, 200, 50), "客户端protoBuf->服务器"))
            {
                // Request_Test_100_101 protoData = new Request_Test_100_101();
                // protoData.Account = "ASDASD";
                // protoData.Password = "123456";
                //
                //
                // Request_Test requsetTestInfo = new Request_Test(protoData);
                //
                //
                // NodeClient.ins.send(requsetTestInfo);
                // Debug.Log("send");

                ChorusMember info = new ChorusMember();
                info.playerId = (int)8989;
                info.name = "";
                info.head = "";
                info.gender = 0;
                info.characteristic = 0;
                RoomNetService.ins.addChorusMember(info, () =>
                {
                    Debug.Log(" 添加操作---合唱成员成功 " );
                }, (int code, string info) =>
                {
                    Debug.Log(" 添加合唱成员失败 code:" + code+" "+info);
                });
                return;
                // PacketWriter pw = new PacketWriter();
                // pw.clsID = 100;
                // pw.methodID = 101;
                // pw.isEnd = 1;
                // pw.type = (byte)NET_CMD_TYPE.PB;
                // Request_Test_100_101 protoData = new Request_Test_100_101();
                // protoData.Account = "ASDASDASsaSAS";
                // protoData.Password = "123456AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
                // pw.protoData = protoData;
                // // byte[] temp = new byte[13+pw.getBinLength()];
                // // temp[0] = (byte)(13 + pw.getBinLength());
                // //
                // // temp[0] = pw.clsID;
                // // temp[1] = pw.methodID;
                // //Array.Copy(pw.protoData.ToByteArray(),0,temp,2,pw.protoData.CalculateSize());
                //
                // byte[] temp = DataCenter.PacketBuilder.Build(pw,(byte)NET_CMD_TYPE.PB,false);
                //
                // NetManage.ins.send(pw,(byte)NET_CMD_TYPE.PB);
                // // byte[] pbBytes = NetUtilcs.Serialize(requsetTestInfo.protoData);
                // // Block block = new Block(pbBytes);
                // // PacketWriter pw = new PacketWriter();
                


            }

            GUI.Label(new Rect(10, 300, 500, 20), "SeverCallBack : " + serverStr);
            
            
            if (GUI.Button(new Rect(10, 400, 200, 50), "服务器->客户端"))
            {
                
                DataTestData2Response rsp = new DataTestData2Response((reslut) =>
                {
                    Debug.Log("Success!!!!!"+reslut );
                    
                }, (code, info) =>
                {
                    Debug.Log("Fail!!!!!" + code + "  info:" + info);
                });
                NodeClient.ins.onNotify(rsp);
                
                // TCPTestServer server = GameObject.Find("GameObject").GetComponent<TCPTestServer>();
                // server.SendMessage();
                // server.SendMessage();
            }
        }
    }

    private void OnCreateConnectionComplete(object sender, CreateConnectionAsyncArgs e)
    {
        isConnnect = false;
    }

    private void OnReceiveMessageFromServer(object sender, SocketMessageReceivedFromServer e)
    {
        Debug.Log("=======================================OnReceiveMessageFromServer "+e.Message.Length+" "+e.BytesTransferred);
        this.diapatcher.AddData(e.Message, e.BytesTransferred);
    }

    private void ReconnectHandler(object sender, EventArgs e)
    {
        Debug.Log("ReconnectHandler");
    }

    private void CloseHandler(object sender, EventArgs e)
    {
        isConnnect = true;
    }

    private void ConnectError(object sender, EventArgs e)
    {

    }

    private void GetServerMessage(byte[] bytes)
    {
        Debug.Log("go to this GetServerMessage");
        // this.serverStr = ByteArrToString(bytes);
        DataCenter.PacketParser.Parse( bytes );
        
    }


    private byte[] StringToByteArr(string str)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(str);
        packetLength = bytes.Length;
        return bytes;
    }

    private string ByteArrToString(byte[] bytes)
    {
        string str = Encoding.UTF8.GetString(bytes);
        return str;
    }
    
    void Callback_Player(object o )
    {
        Response_Test_100_101 player = o as Response_Test_100_101;
        Debug.Log(player.Account+" "+player.Password + "    " + Time.time);
    }

    private void OnApplicationQuit()
    {
        NetManage.ins.tcpChannel.close();
    }
}
