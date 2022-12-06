using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using ComponentAce.Compression.Libs.zlib;
using Google.Protobuf;
using HardCordGirlData;
using network;
using ProtoBuf.Meta;
using ROLEMSG;
using UnityEngine;
using NewProto;


namespace ZipWrapper
{
    public class ZipTest :MonoBehaviour
    {
        public static string Compress(string source)
        {
            System.IO.FileStream outFileStream = new System.IO.FileStream(Application.persistentDataPath + "/333.xml", System.IO.FileMode.Create);
            var bytes = Encoding.UTF8.GetBytes(source);
            using (var compressedStream = new MemoryStream())
            {
                using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                {
                    zipStream.Write(bytes, 0, bytes.Length);
                }
                return Convert.ToBase64String(compressedStream.ToArray()) ;
            }
          
        }

        public static string Decompress(string result)
        {           
            
            var bytes = Convert.FromBase64String(result);
            using (var compressStream = new MemoryStream(bytes))
            {
                using (var zipStream = new GZipStream(compressStream, CompressionMode.Decompress))
                {
                    using (var resultStream = new MemoryStream())
                    {
                        zipStream.CopyTo(resultStream);
                        return     Encoding.UTF8.GetString(resultStream.ToArray());
                      
                    }
                }
            }
        }
        
        // 使用System.IO.Compression进行Deflate压缩
        public static byte[] MicrosoftCompress(byte[] data)
        {
            MemoryStream uncompressed = new MemoryStream(data); // 这里举例用的是内存中的数据；需要对文本进行压缩的话，使用 FileStream 即可
            MemoryStream compressed = new MemoryStream();
            DeflateStream deflateStream = new DeflateStream(compressed, CompressionMode.Compress); // 注意：这里第一个参数填写的是压缩后的数据应该被输出到的地方
            uncompressed.CopyTo(deflateStream); // 用 CopyTo 将需要压缩的数据一次性输入；也可以使用Write进行部分输入
            deflateStream.Close();  // 在Close中，会先后执行 Finish 和 Flush 操作。
            byte[] result = compressed.ToArray();
            return result;
        }
        
        public static byte[] ZLibDotnetCompress(byte[] data)
        {
            MemoryStream compressed = new MemoryStream();
            ZOutputStream outputStream = new ZOutputStream(compressed, 9); 
            outputStream.Write(data, 0, data.Length); // 这里采用的是用 Write 来写入需要压缩的数据；也可以采用和上面一样的方法
            outputStream.Close();
            byte[] result = compressed.ToArray();
            return result;
        }
        
        public static byte[] ZLibDotnetDecompress(byte[] data, int size)
        {
            MemoryStream compressed = new MemoryStream(data);
            ZInputStream inputStream = new ZInputStream(compressed);
            byte[] result = new byte[size];   // 由于ZInputStream 继承的是BinaryReader而不是Stream, 只能提前准备好输出的 buffer 然后用 read 获取定长数据。
            inputStream.read(result, 0, result.Length); // 注意这里的 read 首字母是小写
            return result;
        }
        
        
        private void Start()
        {

            
            
            // NetUtilcs.ReadProtoBuff();
            // return;
            
            // JsonData registerJson = new JsonData ();
            // registerJson ["cmd"] = "Login|register";
            // registerJson ["name"] = "wyq";
            // registerJson ["tel"] = username;
            // registerJson ["psd"] = password;
            //
            // string registrStr = registerJson.ToJson();
            // string jsonPath = Application.streamingAssetsPath+"/test.json";
            // string jsonText = File.ReadAllText(jsonPath);
            // Debug.Log("jsonText:"+jsonText);
            // GenClassFromJson genClassFromJson = new GenClassFromJson(jsonText,"AA");
           
            
            
            // PropsPickUpInfo info = new PropsPickUpInfo();
            // info.Id = 900;
            // info.playerId = 901;
            // byte[] data = ProtoBufUtils.ProtobufSerialize<PropsPickUpInfo>(info);
            // PropsPickUpInfo  info2 =ProtoBufUtils.ProtobufDeserialize<PropsPickUpInfo>(data);
            // Debug.Log("info2:"+info2.Id+" "+info2.playerId);
            
         
            ROLEMSG.CTS_LOGIN_MSG toServer = new CTS_LOGIN_MSG();
            toServer.Id = 12134;
            toServer.FastCertificate = "Jaihk66222";
            //将对象转换成字节数组
            byte[] databytes = toServer.ToByteArray();
 
            //将字节数据的数据还原到对象中
            IMessage IMperson = new ROLEMSG.CTS_LOGIN_MSG();
            ROLEMSG.CTS_LOGIN_MSG toClient = new ROLEMSG.CTS_LOGIN_MSG();
            toClient = (CTS_LOGIN_MSG)IMperson.Descriptor.Parser.ParseFrom(databytes);
            Debug.Log("toClient:"+toClient.Id+" "+toClient.FastCertificate);
            // PropsPickUp_Info info3 = new PropsPickUp_Info();
            // info3.Id = 100;
            // info3.playerId = 1223;
            // byte[] data2 = ProtoBufUtils.ProtobufSerialize<PropsPickUp_Info>(info3);
            // PropsPickUp_Info  info4 =ProtoBufUtils.ProtobufDeserialize<PropsPickUp_Info>(data2);
            // Debug.Log("info3:"+info4.Id+" "+info4.playerId);
            return;
            string ppath = Application.persistentDataPath;
            
            // string str = Compress(ppath + "/log4j2.xml");
            // Debug.Log(str.ToArray().Length);
            // return;
            Debug.Log("path:"+ppath);
            System.IO.FileStream outFileStream = new System.IO.FileStream(ppath + "/333.xml", System.IO.FileMode.Create);
            ZOutputStream outZStream = new ZOutputStream(outFileStream, zlibConst.Z_DEFAULT_COMPRESSION);
            //System.IO.FileStream inFileStream = new System.IO.FileStream(ppath + "/log4j2.xml", System.IO.FileMode.Open);	
            
            
            // var buffer = File.ReadAllBytes(ppath + "/log4j2.xml");
            // byte[] reusableBuffer4 = MicrosoftCompress(buffer);
            // for (int i = 0; i < reusableBuffer4.Length; i++)
            // {
            //     Debug.Log("buffer:"+ reusableBuffer4[i]);
            // }
            var buffer = File.ReadAllBytes(ppath + "/log4j2.xml");
            byte[] reusableBuffer4 = ZLibDotnetCompress(buffer);
            
            byte[] reusableBuffer5 = new byte[0];
            lzip.compressBuffer(buffer,ref reusableBuffer5,9);
            
            // for (int i = 0; i < reusableBuffer4.Length; i++)
            // {
            //     Debug.Log("buffer:"+ reusableBuffer4[i]);
            // }
           
            // int len;
            // while ((len = input.Read(buffer, 0, 2000)) > 0)
            // {
            //     output.Write(buffer, 0, len);
            // }
            // output.Flush();
            // string ppath = Application.persistentDataPath;
            // byte[] reusableBuffer2 = new byte[0];
            byte[] reusableBuffer3 = new byte[0];
            byte[] reusableBuffer8 = new byte[0];
           // var fileBuffer = File.ReadAllBytes(ppath + "/log4j2.xml"); 
            //
           // bool pass = lzip.compressBuffer(buffer, ref reusableBuffer3, 9);
            Debug.Log("zlib: "+ buffer.Length+" "+ reusableBuffer4.Length+" "+reusableBuffer5.Length);
            Debug.Log("buffer:"+ BitConverter.ToString(reusableBuffer4));
            Debug.Log("buffer:"+ BitConverter.ToString(reusableBuffer5));
           
            lzip.decompressBuffer(reusableBuffer5, ref reusableBuffer3);
            lzip.decompressBuffer(reusableBuffer4, ref reusableBuffer8);
            Debug.Log("buffer:"+" "+reusableBuffer3.Length+" "+ reusableBuffer8.Length);
            File.WriteAllBytes(ppath + "/log4j2222.xml",reusableBuffer3);
            File.WriteAllBytes(ppath + "/log4j3333.xml",reusableBuffer8);
            //   // int rr = lzip.gzip(reusableBuffer2,reusableBuffer3,9, true, true);
            //   // Debug.Log("gzip: " + pass.ToString()+fileBuffer.Length+" "+ reusableBuffer3.Length);
            //   for (int i = 0; i < reusableBuffer3.Length; i++)
            //   {
            //       Debug.Log(" " + reusableBuffer3[i]);
            //   }
            //
            //   sbyte[] a = new sbyte[]
            //   {
            //       120, -38, -19, 88, 93, 79, -37, 86, 24, -66, -122, 95, 113, 102, 53, -105, 118, -24, -74, 78, 19, 74,
            //       -88, 40, -124, -75, 18, 95, 34, 97, 85, 53, 77, -109, -79, 79, -100, -45, -39, 62, -87, -49, 9, -112,
            //       86, 92, -83, 12, 10, -84, 76, -5, -22, -24, 90, 105, -35, 96, 101, -19, -70, 114, 49, 33, 10, 101, -4,
            //       -103, -40, 73, -81, -10, 23, -10, 30, 59, 14, 118, -109, -112, 68, -86, 118, -77, 70, -118, -110, 115,
            //       -4, -66, -49, -5, -15, 60, -25, -40, -57, -87, -117, -117, -106, -119, -26, -79, -61, 8, -75, -45,
            //       -46, 121, 101, 64, 66, -40, -42, -88, 78, 108, 35, 45, -51, -26, -58, -28, 15, -91, -117, 67, -3, 41,
            //       -115, -38, 121, 98, -108, 28, -107, -125, 29, 98, 92, -27, 37, -106, -106, -90, -58, -58, -92, -95,
            //       -2, -66, -108, 90, 44, 98, 91, 7, -112, -95, -2, -2, -66, -66, -44, 8, -75, 25, 53, 49, -78, 85, 11,
            //       -89, -91, -6, 72, 66, 92, 117, 12, -52, -45, 82, -10, 90, 54, -105, -103, -8, 108, 106, 54, 39, -100,
            //       -63, -2, 29, 89, 118, 55, -97, 120, 119, 119, -36, -51, 123, -43, -35, 117, -9, 112, -77, 114, -16,
            //       108, 52, 115, 105, -10, -93, -22, -31, 99, 119, -11, 105, -11, -2, 109, -17, -34, -114, 123, 114, -81,
            //       118, -14, 83, -19, -47, -122, -69, 125, -69, -6, -11, -105, 72, -106, 3, -17, 92, -63, -63, -84, 64,
            //       77, 125, -116, -104, 28, 59, -56, -60, -13, -40, 76, 75, -66, -65, -124, -88, 61, -95, 114, -83, -112,
            //       -106, -122, 71, 70, 50, -45, 57, 73, -72, -12, -63, 36, 97, 86, 48, 63, -102, -103, -68, 38, -95, 100,
            //       -128, 53, -83, 114, -128, -80, -57, -43, 50, 45, 113, -33, -76, 24, -52, -92, -91, 79, 18, -6, -83,
            //       50, 124, -28, -119, 9, 89, -41, -47, -27, -53, -125, -106, 53, -56, -40, 96, 54, -101, 93, -6, 20, 37,
            //       -28, 11, 126, 92, -108, -32, 40, -95, -103, 42, 99, -73, -34, -5, 96, 9, 37, -58, 81, 98, 2, -55, 40,
            //       97, 49, 35, -79, -104, 89, 76, -40, -11, 80, -87, 100, -67, 45, 65, -57, 68, 7, -4, -86, 90, 85, -3,
            //       -49, -53, 13, -9, -59, -66, -73, -74, 86, 123, -66, 19, -52, 120, -33, -3, -19, -82, -18, -103, -44,
            //       96, 73, 29, -49, -107, 12, 5, -2, 122, 63, -84, 84, -114, -10, -95, 113, -11, -58, 8, 76, -17, -50,
            //       -73, -18, 87, 123, -18, -54, 97, 4, -74, -127, -23, 61, -33, -12, -2, 120, -28, 110, 63, 118, -9, 54,
            //       107, -5, -53, -75, -109, 21, 70, 110, 98, 17, 108, 117, -85, 118, -78, 37, 6, -63, -59, 70, 34, -107,
            //       -105, -9, 107, 43, 79, -36, -75, 93, -9, -39, -113, -18, -14, -114, -73, 113, -57, 125, -15, 87, -27,
            //       -24, 88, -10, 30, -84, -62, -113, 123, 116, 88, 125, -70, 46, -84, -3, 84, -36, -19, 23, -107, -125,
            //       -11, 87, 15, 127, -127, -28, -21, -60, -35, 93, -81, -66, -4, 29, 34, 84, -114, 31, 84, 14, 14, 1,
            //       -59, 123, -12, 107, -104, -18, 12, 53, 77, 16, 29, -112, 24, 10, 39, 50, 51, 42, -86, -12, -71, -53,
            //       -61, 104, -46, -65, -84, 36, -29, 13, 104, 92, -98, 14, 41, -13, -81, -97, 59, 119, 75, 87, 57, 30,
            //       -84, 115, -73, 20, 56, -56, 49, 54, -105, -28, 4, 17, 16, -118, 113, -77, 46, -55, 64, 75, -52, 31,
            //       116, -110, 88, -14, 108, -85, 43, -109, 99, 83, 17, 29, -6, 122, -13, 29, 98, 50, -100, -52, -52, -26,
            //       102, -122, -57, 27, 74, 76, 70, 51, -8, -17, 116, 9, -95, -88, 73, 52, -126, -61, -46, -77, 32, -125,
            //       75, 42, -61, 122, -50, 33, -122, -127, 29, 32, -60, -73, 40, 35, 33, -112, -76, 116, 97, 96, 0, 77,
            //       92, -118, 52, -127, 88, 109, -20, -61, -62, -94, 1, 82, -55, 8, -55, -81, 45, 5, -47, -73, 94, 86, 2,
            //       -79, -13, -76, -27, 66, 56, 83, 89, 87, -64, -85, -75, -80, 66, -68, 110, 117, 37, -20, 123, -109, 85,
            //       116, -33, 107, 83, -19, -14, 126, -27, 120, 11, 102, -36, -27, -35, 87, 95, -20, 122, -21, -33, 84,
            //       -113, 30, -58, -9, -65, 14, -70, -21, 32, -50, -85, -61, 51, -109, 111, -59, -39, -69, 56, 69, -33,
            //       122, 17, -25, -126, -22, -40, -67, -117, -13, 42, 120, -75, 22, 103, -120, -41, -83, 56, -123, -3, 27,
            //       -39, -13, 2, -63, 116, 80, 85, 102, 102, 102, 106, -26, -83, -84, 122, -105, 21, 118, 28, -22, -12,
            //       -94, 43, -33, -95, 119, 97, 101, -124, 91, 107, 101, 53, 16, -69, -107, -106, -17, -48, 73, 91, 103,
            //       11, 37, -7, 127, 100, 92, 119, 74, 68, 63, 125, -76, -3, 115, -49, 61, -2, -66, 118, 114, -20, -82,
            //       -3, -20, 110, -19, -94, 22, -4, -7, 14, -39, 27, 102, -28, -118, -124, -102, -97, -121, -124, -107,
            //       -52, 110, -104, 62, -121, -88, 75, 18, -43, 34, 57, -125, 66, 20, -89, -58, 7, -19, 68, 77, -116,
            //       -106, -106, 68, -96, 83, 22, 124, -60, 30, 88, 64, 103, 50, -128, 94, -93, 0, -59, 9, 8, 86, 72, 42,
            //       25, 59, -75, -92, -96, 86, -93, -66, -9, -92, 28, 74, 121, -20, 54, 26, -112, 26, 58, -56, 14, -50,
            //       35, -8, 70, -50, 54, -55, 118, 22, 77, 15, -79, 93, -103, -6, 79, 37, 93, 89, -6, -73, -120, -82, 44,
            //       -125, 53, 31, 30, 63, 68, -119, 13, 41, 6, -30, 107, 40, 7, 68, 25, -52, -96, 122, 87, -94, 2, 84,
            //       -124, -76, -78, 112, 0, -60, 22, -74, -71, 20, -74, 73, 15, -118, 83, 117, -99, 112, 50, 79, 120, 57,
            //       45, -27, 85, -109, 97, -87, -50, 70, 115, 106, 45, -27, 44, -88, 77, 6, 65, -121, -70, -119, 46, -80,
            //       59, 103, -48, 109, 116, -127, 22, -53, -32, -12, 40, 5, 51, -17, 95, 127, 23, -119, -13, -49, -63,
            //       111, 112, 86, -14, -114, -74, -125, -123, -117, 82, -29, -47, 44, -87, 99, 40, 106, 81, -43, 10, 88,
            //       -47, 84, -82, 2, -74, -86, -64, 113, -39, -31, -91, -94, 50, 74, 12, -52, 96, -47, -116, -87, 26, -89,
            //       78, 57, -106, 61, 14, -39, -23, 2, -81, -60, -119, -87, -116, -109, 60, -42, -54, -102, -23, -81,
            //       -126, 6, 13, 117, -104, -80, -112, -74, 80, -76, 76, 57, 86, 10, -100, 23, -49, -97, 87, 46, -5, 63,
            //       -109, -124, 78, 59, -108, 83, -115, -102, 13, -72, 5, 95, 93, 33, -102, -39, 6, -115, -79, -126, 14,
            //       -112, -106, 69, -19, 32, -73, 44, -42, 74, 14, 48, 48, 11, 3, -42, 6, -84, 93, 106, -100, 90, 80, 104,
            //       -128, 99, 99, -82, 64, 90, 89, 108, 98, -47, -79, 105, -38, 54, -75, 38, 52, -51, 97, 5, -91, 104,
            //       -106, 12, 98, -65, -26, -46, -78, 18, -33, 28, -22, -120, 113, 114, 106, -33, 4, -113, 53, -109, 20,
            //       25, 86, -82, 99, -50, -53, 65, -78, -48, -128, 34, -75, 65, -107, -54, -16, 28, -29, 14, 112, 44, 40,
            //       26, 17, 20, 117, -51, 116, -127, -52, -63, -98, 10, -22, 86, -26, -127, 106, -40, -94, -31, 86, 76,
            //       108, -79, -49, -86, 102, 16, -27, -29, -32, 85, 77, -101, 60, -101, -22, 98, 69, -79, 51, -26, 29,
            //       -104, 88, -96, -50, -25, -54, 28, 44, 123, 5, 82, 43, -119, 24, 106, 73, -80, 29, -68, -40, -63, -54,
            //       8, -76, 96, 24, 102, 70, -94, -81, 122, -34, 72, 28, 88, 122, 69, 10, 101, 40, -41, -83, -59, 110, 1,
            //       121, -95, 108, 1, -19, 106, -66, -103, -67, -6, -10, -35, -40, -80, 83, -55, -40, -37, -87, -95, 127,
            //       1, 34, -77, -69, -16
            //   };
        }
        public static void CopyStream(System.IO.Stream input, System.IO.Stream output)
        {
            byte[] buffer = new byte[2000];
            int len;
            while ((len = input.Read(buffer, 0, 2000)) > 0)
            {
                output.Write(buffer, 0, len);
            }
            output.Flush();
        }

    }
}