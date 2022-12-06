using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using ComponentAce.Compression.Libs.zlib;
using Google.Protobuf;
using network;
using network.response;
using network.tcp.DataCenter;
using ProtoBuf;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;
using Random = System.Random;

namespace NewProto
{
    public class NetUtilcs
    {
        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                .ToArray();
        }

        public static void ReadProtoBuff()
        {
            List<string> clsIDList = new List<string>();
            List<string> methodIDList = new List<string>();
            List<string> genClassNameList = new List<string>();
            List<string> classNameList = new List<string>();
            //step1 =====生成 proto CS 文件
            Assembly assembly = Assembly.GetExecutingAssembly();
            var files = GetTypesInNamespace(assembly, "NewProto");
            using (StreamWriter sw =
                   new StreamWriter(UnityEngine.Application.dataPath + "/Scripts/network/ProtoBufTest.cs", false))
            {
                sw.WriteLine("//动态生成，不要手动修改\n");
                sw.WriteLine("using NewProto;");
                foreach (var VARIABLE in files)
                {
                    //Debug.Log(VARIABLE.Name);

                    if (VARIABLE.Name.StartsWith("Request_") || VARIABLE.Name.StartsWith("Response_"))
                    {
                        string[] sArray = VARIABLE.Name.Split('_');
                        string clsID = sArray[sArray.Length - 2];
                        string methodID = sArray[sArray.Length - 1];
                        string genClassName = "";
                        for (int i = 0; i < sArray.Length - 2; i++)
                        {
                            if (i == sArray.Length - 3)
                            {
                                genClassName += sArray[i];
                            }
                            else
                                genClassName += sArray[i] + "_";
                        }

                        string className = VARIABLE.Name;
                        Debug.Log("clsID:" + clsID + ":methodID:" + methodID + " className:" + className +
                                  " genClassName:" + genClassName);


                        sw.WriteLine("public class {0} :PacketWriter", genClassName);
                        sw.WriteLine("{");
                        sw.WriteLine("  public const int CLSID    ={0};", clsID);
                        sw.WriteLine("  public const int METHODID ={0};", methodID);
                        sw.WriteLine("  public {0}({1} protoData)", genClassName, className);
                        sw.WriteLine("  {");
                        sw.WriteLine("    this.clsID   = {0};", clsID);
                        sw.WriteLine("    this.methodID = {0};", methodID);
                        sw.WriteLine("    this.type     = {0};", "(byte)NET_CMD_TYPE.PB");
                        sw.WriteLine("    this.protoData = protoData;");
                        sw.WriteLine("  }");
                        sw.WriteLine("}");


                        clsIDList.Add(clsID);
                        methodIDList.Add(methodID);
                        genClassNameList.Add(genClassName);
                        classNameList.Add(className);
                    }
                }
            }

            Debug.Log("<color=green>包装类路径：</color>" + UnityEngine.Application.dataPath +
                      "/Scripts/network/ProtoBufTest.cs");
            //step2 =====生成 解析器
            using (StreamWriter sw =
                   new StreamWriter(UnityEngine.Application.dataPath + "/Scripts/network/CreateProtoBuf.cs", false))
            {
                sw.WriteLine("//动态生成，不要手动修改\n");
                sw.WriteLine("using NewProto;");
                sw.WriteLine("using Google.Protobuf;");
                sw.WriteLine("namespace NewProto");
                sw.WriteLine("{");
                sw.WriteLine("    public static class CreateProtoBuf");
                sw.WriteLine("    {");
                sw.WriteLine("        public static IMessage GetProtoData(int protoId, byte[] msgData)");
                sw.WriteLine("        {");
                sw.WriteLine("            switch (protoId)");
                sw.WriteLine("            {");
                for (int i = 0; i < clsIDList.Count; i++)
                {
                    if (genClassNameList[i].StartsWith("Request")) //只生成响应类
                    {
                        continue;
                    }


                    sw.WriteLine("                case {0}.CLSID<<8 | {0}.METHODID:", genClassNameList[i]);
                    sw.WriteLine("                    return NetUtilcs.Deserialize<{0}>(msgData);", classNameList[i]);
                }

                sw.WriteLine("                default:");
                sw.WriteLine("                    return null;");
                sw.WriteLine("            }");
                sw.WriteLine("         }");
                sw.WriteLine("    }");
                sw.WriteLine("}");
            }

            Debug.Log("<color=green>解析类路径：</color>" + UnityEngine.Application.dataPath +
                      "/Scripts/network/CreateProtoBuf.cs");
        }

        public static byte[] Serialize(IMessage msg)
        {
            // using (MemoryStream rawOutput = new MemoryStream())
            // {
            //     CodedOutputStream output = new CodedOutputStream(rawOutput);
            //     output.WriteMessage(msg);
            //     output.Flush();
            //     byte[] result = rawOutput.ToArray();
            //     return result;
            // }
            using (MemoryStream output = new MemoryStream())
            {
                msg.WriteTo(output);
                return output.ToArray();
            }
        }

        public static T Deserialize<T>(byte[] message) where T : IMessage, new()
        {
            // CodedInputStream stream = new CodedInputStream(message);
            // T msg = new T();
            // stream.ReadMessage(msg);
            // return msg;

            T msg = new T();
            msg.MergeFrom(message);
            return msg;
        }

        public static void TestEncryption()
        {
            // string content = "GER";
            // string key = "BIO";
            // var content_char = System.Text.Encoding.Unicode.GetBytes(content);
            // var key_char = System.Text.Encoding.Unicode.GetBytes(key);
            byte[] content_char = new byte[] { 3, 1, 0, 0, 0, 30, 97, 0, 0 };
            //uint key_char = 9;
            byte[] key_char = new byte[] { 1, 1, 1, 0, 0, 1, 2, 0, 0 };
            byte result = 9;
            byte[] src = new byte[4];
            // src[3] = (byte)((key_char >> 24) & 0xFF);
            // src[2] = (byte)((key_char >> 16) & 0xFF);
            // src[1] = (byte)((key_char >> 8) & 0xFF);
            // src[0] = (byte)(key_char & 0xFF);

            // var n = BitConverter.ToInt32(src, 0);
            // Debug.Log("n"+result);
            //加密
            byte[] content_after_char = new byte[content_char.Length]; //加密后的字符数组
            Array.Copy(content_char, content_after_char, content_char.Length);
            for (int i = 0; i < content_char.Length - 3; i += 3)
            {
                Debug.Log(i);
                content_after_char[i] = (byte)(content_char[i] ^ result);
            }

            //解密

            byte[] content_before_char = new byte[content_char.Length]; //解密后的字符数组
            Array.Copy(content_after_char, content_before_char, content_char.Length);
            for (int i = 0; i < content_char.Length - 3; i += 3)
            {
                Debug.Log("i：" + i);
                content_before_char[i] = (byte)(content_after_char[i] ^ result);
            }


            DebugBytes(content_char);
            DebugBytes(content_after_char);
            DebugBytes(content_before_char);
            // Debug.Log(string.Format("加密后的内容：{0}",));
            // Debug.Log(string.Format("解密后的内容：{0}", content_before_string));
        }

        public static byte[] EncryptionBytes(byte[] sourceBytes, int key)
        {
            for (int i = 4; i < sourceBytes.Length; i++)
            {
                sourceBytes[i] = (byte)(sourceBytes[i] ^ key);
            }

            return sourceBytes;
        }

        public static byte[] DecodeBytes(byte[] sourceBytes, int key)
        {
            for (int i = 4; i < sourceBytes.Length; i++)
            {
                sourceBytes[i] = (byte)(sourceBytes[i] ^ key);
            }

            return sourceBytes;
        }

        public static byte[] ZLibDotnetCompress(byte[] data)
        {
            // MemoryStream compressed = new MemoryStream();
            // ZOutputStream outputStream = new ZOutputStream(compressed, 9); 
            // outputStream.Write(data, 0, data.Length); // 这里采用的是用 Write 来写入需要压缩的数据；也可以采用和上面一样的方法
            // outputStream.Close();
            // byte[] result = compressed.ToArray();
            // return result;
            byte[] buffer = new byte[0];
            lzip.compressBuffer(data, ref buffer, 9);
            return buffer;
        }

        public static byte[] ZLibDotnetDecompress(byte[] data)
        {
            // MemoryStream compressed = new MemoryStream(data);
            // ZInputStream inputStream = new ZInputStream(compressed);
            // byte[] result = new byte[size];   // 由于ZInputStream 继承的是BinaryReader而不是Stream, 只能提前准备好输出的 buffer 然后用 read 获取定长数据。
            // inputStream.read(result, 0, result.Length); // 注意这里的 read 首字母是小写
            // return result;
            byte[] buffer = new byte[0];
            lzip.decompressBuffer(data, ref buffer);
            return buffer;
        }

        public static void DebugBytes(byte[] buf)
        {
            string str = "[";
            // for (int i = 0; i < buf.Length; i++)
            // {
            //     str += buf[i] + ",";
            // }
            //
            // str += "]";
            Debug.Log("Byte Aarry size:" + buf.Length + " " + str);
        }

        public static void DebugBytes2(byte[] buf)
        {
            string str = "[";
            // for (int i = 0; i < buf.Length; i++)
            // {
            //     str += buf[i] + ",";
            // }
            //
            // str += "]";
            Debug.LogError("Byte Aarry size:" + buf.Length + " " + str);
        }

        /// <summary>
        /// Byte 数组转十六进制字符串
        /// </summary>
        /// <param name="Bytes"></param>
        /// <returns></returns>
        public static string ByteToHex(byte[] Bytes)
        {
            string str = string.Empty;
            foreach (byte Byte in Bytes)
            {
                str += String.Format("{0:X2}", Byte) + " ";
            }

            Debug.Log("byte to hex:" + str.Trim());
            return str.Trim();
        }

        /// <summary>
        /// 字符串转十六进制Byte数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] strToToHexByte(string hexString)
        {
            try
            {
                hexString = hexString.Replace(" ", "");
                if ((hexString.Length % 2) != 0)
                    hexString += " ";
                byte[] returnBytes = new byte[hexString.Length / 2];
                for (int i = 0; i < returnBytes.Length; i++)
                    returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                return returnBytes;
            }
            catch
            {
                return null;
            }
        }

        public static void PacketMsg<T>(byte[] body,Response response,byte type) where T : PacketWriter
        {
            //T pw = default(T);
            T pw = Activator.CreateInstance<T>();
            byte[] allMsg = body;
            bool isCompress = false;
            if (allMsg.Length > DataCenter.packetProcesser.MaxZipSize)
            {
                isCompress = true;
                allMsg = NetUtilcs.ZLibDotnetCompress(allMsg);
                Debug.LogError("压缩后:" + allMsg.Length);
                NetUtilcs.DebugBytes(allMsg);
            }
            if (allMsg.Length > DataCenter.packetProcesser.MaxPaketSize)
            {
                Queue<byte[]> queue = splitBody(allMsg);
                for (;;)
                {
                    byte[] b = queue.Dequeue();
                    bool end = queue.Count == 0 ? true : false;
                 
                    PacketWriter packetWriter = new PacketWriter();
                    packetWriter.clsID = pw.clsID;
                    packetWriter.methodID = pw.methodID;
                    packetWriter.type = type;
                    packetWriter.isEnd = (byte)(end == true ? 1 : 0);
                    packetWriter.compress = (byte)(isCompress == true ? 1 : 0);
                    Debug.Log("aaa.：" + end + " isCompress:" + isCompress);
                    packetWriter.body = b;
                    //NodeClient.ins.send(bigPacketWriter,rsp1);
                    NodeClient.ins.send(packetWriter,response);
                    //NetManage.ins.send(packetWriter, (byte)NET_CMD_TYPE.PB);
                    if (end)
                        break;
                }
            }
            else
            {
                bool end = true;
                PacketWriter packetWriter = new PacketWriter();
                packetWriter.clsID = pw.clsID;
                packetWriter.methodID = pw.methodID;
                packetWriter.type = type;
                packetWriter.isEnd = (byte)(end == true ? 1 : 0);
                packetWriter.compress = (byte)(isCompress == true ? 1 : 0);
                Debug.Log("aaa.：" + end + " isCompress:" + isCompress);
                packetWriter.body = allMsg;
                //NetManage.ins.send(packetWriter, (byte)NET_CMD_TYPE.PB);
                NodeClient.ins.send(packetWriter,response);
            }
        }

        public static Queue<byte[]> queue = new Queue<byte[]>();


        public static void PacketBigMsg2()
        {
            Debug.Log("PacketBigMsg2");
            string ppath = Application.persistentDataPath;
            var buffer = File.ReadAllBytes(ppath + "/log4j2.xml");
            string str = System.Text.Encoding.UTF8.GetString(buffer);
            Debug.Log(buffer.Length + " " + str);
            List<byte[]> list = new List<byte[]>();
            PacketWriter pw = new PacketWriter();
            pw.clsID = 100;
            pw.methodID = 101;
            pw.isEnd = 1;
            pw.type = (byte)NET_CMD_TYPE.PB;
            Request_Test_100_101 protoData = new Request_Test_100_101();
            protoData.Account = "ASDASD";
            protoData.Password = str;
            pw.SetBodyData(protoData);
            byte[] allMsg = NetUtilcs.Serialize(protoData);


            NetUtilcs.DebugBytes(allMsg);

            // allMsg = NetUtilcs.ZLibDotnetCompress(allMsg);
            // NetUtilcs.DebugBytes(allMsg);
            // allMsg = NetUtilcs.ZLibDotnetDecompress(allMsg);
            // NetUtilcs.DebugBytes(allMsg);
            int MAX_LENGTH = DataCenter.packetProcesser.MaxPaketSize;

            bool isCompress = false;
            if (allMsg.Length > MAX_LENGTH)
            {
                isCompress = false;
                //allMsg = NetUtilcs.ZLibDotnetCompress(allMsg);
                Debug.LogError("压缩后:" + allMsg.Length);
                NetUtilcs.DebugBytes(allMsg);
            }

            if (allMsg.Length > MAX_LENGTH)
            {
                Queue<byte[]> queue = splitBody(allMsg);
                for (;;)
                {
                    byte[] b = queue.Dequeue();
                    bool end = queue.Count == 0 ? true : false;
                    BigPacketReader rsp1 = new BigPacketReader();
                    BigPacketWriter bigPacketWriter = new BigPacketWriter();
                    bigPacketWriter.clsID = 100;
                    bigPacketWriter.methodID = 101;
                    bigPacketWriter.type = (byte)NET_CMD_TYPE.PB;
                    bigPacketWriter.isEnd = (byte)(end == true ? 1 : 0);
                    bigPacketWriter.compress = (byte)(isCompress == true ? 1 : 0);
                    ;
                    Debug.Log("aaa.：" + end + " isCompress:" + isCompress);
                    bigPacketWriter.body = b;
                    //NodeClient.ins.send(bigPacketWriter,rsp1);
                    NetManage.ins.send(bigPacketWriter, (byte)NET_CMD_TYPE.COUSTOM);
                    if (end)
                        break;
                }
            }
            else
            {
                bool end = true;
                BigPacketReader rsp1 = new BigPacketReader();
                BigPacketWriter bigPacketWriter = new BigPacketWriter();
                bigPacketWriter.clsID = 127;
                bigPacketWriter.methodID = 127;
                bigPacketWriter.type = (byte)NET_CMD_TYPE.COUSTOM;
                bigPacketWriter.isEnd = (byte)(end == true ? 1 : 0);
                bigPacketWriter.compress = (byte)(isCompress == true ? 1 : 0);
                ;
                Debug.Log("aaa.：" + end + " isCompress:" + isCompress);
                bigPacketWriter.body = allMsg;

                NetManage.ins.send(bigPacketWriter, (byte)NET_CMD_TYPE.COUSTOM);
            }
            // byte[] data= new byte[messageBytes1.Length + messageBytes2.Length];
            // messageBytes1.CopyTo(data, 0);
            // messageBytes2.CopyTo(data, messageBytes1.Length);
        }

        /// <summary>
        /// 打包超大消息体
        /// </summary>
        public static void PacketBigMsg()
        {
            Debug.Log("PacketBigMsg");
            string ppath = Application.persistentDataPath;
            var buffer = File.ReadAllBytes(ppath + "/log4j2.xml");
            string str = System.Text.Encoding.UTF8.GetString(buffer);
            Debug.Log(buffer.Length + " " + str);
            List<byte[]> list = new List<byte[]>();

            for (int i = 0; i < 10; i++)
            {
                PacketWriter pw = new PacketWriter();
                pw.clsID = 100;
                pw.methodID = 101;
                pw.isEnd = 1;
                pw.type = (byte)NET_CMD_TYPE.PB;
                Request_Test_100_101 protoData = new Request_Test_100_101();
                protoData.Account = "ASDASD" + i * 1000;
                protoData.Password = str;
                pw.SetBodyData(protoData);
                // byte[] temp = new byte[13+pw.getBinLength()];
                // temp[0] = (byte)(13 + pw.getBinLength());
                //
                // temp[0] = pw.clsID;
                // temp[1] = pw.methodID;
                //Array.Copy(pw.protoData.ToByteArray(),0,temp,2,pw.protoData.CalculateSize());

                byte[] temp = DataCenter.PacketBuilder.Build(pw, (byte)NET_CMD_TYPE.PB, false);

                list.Add(temp);
                //Debug.LogError("实际包:"+temp.Length);
                //NetUtilcs.DebugBytes(temp);
            }


            byte[] allMsg = list
                .SelectMany(a => a)
                .ToArray();

            NetUtilcs.DebugBytes(allMsg);

            // allMsg = NetUtilcs.ZLibDotnetCompress(allMsg);
            // NetUtilcs.DebugBytes(allMsg);
            // allMsg = NetUtilcs.ZLibDotnetDecompress(allMsg);
            // NetUtilcs.DebugBytes(allMsg);
            int MAX_LENGTH = DataCenter.packetProcesser.MaxPaketSize;

            bool isCompress = false;
            if (allMsg.Length > DataCenter.packetProcesser.MaxZipSize)
            {
                isCompress = true;
                allMsg = NetUtilcs.ZLibDotnetCompress(allMsg);
                Debug.LogError("压缩后:" + allMsg.Length);
                NetUtilcs.DebugBytes(allMsg);
            }

            if (allMsg.Length > MAX_LENGTH)
            {
                Queue<byte[]> queue = splitBody(allMsg);
                for (;;)
                {
                    byte[] b = queue.Dequeue();
                    bool end = queue.Count == 0 ? true : false;
                    BigPacketReader rsp1 = new BigPacketReader();
                    BigPacketWriter bigPacketWriter = new BigPacketWriter();
                    bigPacketWriter.clsID = 127;
                    bigPacketWriter.methodID = 127;
                    bigPacketWriter.type = (byte)NET_CMD_TYPE.COUSTOM;
                    bigPacketWriter.isEnd = (byte)(end == true ? 1 : 0);
                    bigPacketWriter.compress = (byte)(isCompress == true ? 1 : 0);
                    ;
                    Debug.Log("aaa.：" + end + " isCompress:" + isCompress + " body:" + b.Length);
                    bigPacketWriter.body = b;
                    //NodeClient.ins.send(bigPacketWriter,rsp1);
                    NetManage.ins.send(bigPacketWriter, (byte)NET_CMD_TYPE.COUSTOM);
                    if (end)
                        break;
                }
            }
            else
            {
                bool end = true;
                BigPacketReader rsp1 = new BigPacketReader();
                BigPacketWriter bigPacketWriter = new BigPacketWriter();
                bigPacketWriter.clsID = 127;
                bigPacketWriter.methodID = 127;
                bigPacketWriter.type = (byte)NET_CMD_TYPE.COUSTOM;
                bigPacketWriter.isEnd = (byte)(end == true ? 1 : 0);
                bigPacketWriter.compress = (byte)(isCompress == true ? 1 : 0);
                ;
                Debug.Log("aaa.：" + end + " isCompress:" + isCompress);
                bigPacketWriter.body = allMsg;

                NetManage.ins.send(bigPacketWriter, (byte)NET_CMD_TYPE.COUSTOM);
            }
            // byte[] data= new byte[messageBytes1.Length + messageBytes2.Length];
            // messageBytes1.CopyTo(data, 0);
            // messageBytes2.CopyTo(data, messageBytes1.Length);
        }

        /// <summary>
        /// 解包超大消息体
        /// </summary>
        public static void UnPacketBigMsg()
        {
            Debug.Log("UnPacketBigMsg");
        }

        static void ConvertToBytes(Request[] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                object obj = matrix[i];
                ObjectToByteArray(obj);
            }
        }

        public static Queue<byte[]> splitBody(byte[] body)
        {
            int MAX_LENGTH = DataCenter.packetProcesser.MaxPaketSize;
            ;
            if (body == null || body.Length < 1)
                throw new NullReferenceException();
            byte[] b = body;
            Queue<byte[]> q = new Queue<byte[]>();
            int index = 0;
            int count = 0;
            for (;;)
            {
                int len = b.Length - index < MAX_LENGTH ? b.Length - count * MAX_LENGTH : MAX_LENGTH;
                byte[] tempData = new byte[len];
                System.Array.Copy(b, index, tempData, 0, tempData.Length);
                q.Enqueue(tempData);
                index += tempData.Length;
                ++count;
                if (index == b.Length)
                    break;
            }

            return q;
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}