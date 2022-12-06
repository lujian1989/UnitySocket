using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Json2CSharp;
using NewProto;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

/// <summary>
/// protobuf 生成工具
/// 
/// </summary>
public class ProtoEditor : EditorWindow
{
    [Serializable]
    public class Setting
    {
        public string ProtoFilesPath = string.Empty,
            CSharpGenerator = string.Empty,
            CSharpOutput = string.Empty,
            JsonFilesPath = string.Empty;
        public bool CSharp;
    }

    public string protoSettingKey = "ProtoSetting";
    private Setting setting;
    private Vector2 _scrollPos;
    private string[] protoFiles = { };
    private string[] jsonFiles = { };
    private bool[] protoFileFolds = { };
    [SerializeField] private Vector2 scrollPos;
    private int encodingNameIndex = 0;
    private float prevRefreshTime = 0;
    private bool csharpFold = true;
    private bool jsonFold = false;
    [MenuItem("Tools/ProtoBuf Generator")]
    public static void Init()
    {
        ProtoEditor window = GetWindow<ProtoEditor>();
        window.minSize = new Vector2(320, 100);
        window.Show();
    }

    private void OnEnable()
    {
        if (!EditorPrefs.HasKey(protoSettingKey))
        {
            setting = new Setting();
            var json = JsonUtility.ToJson(setting);
            EditorPrefs.SetString(protoSettingKey, json);
        }
        else
        {
            var json = EditorPrefs.GetString(protoSettingKey);
            setting = JsonUtility.FromJson<Setting>(json);
        }
    }

    private void RefreshFiles()
    {
        if (Time.time - prevRefreshTime < 1) return;
        if (!string.IsNullOrEmpty(setting.ProtoFilesPath))
        {
            protoFiles = Directory.GetFiles(setting.ProtoFilesPath, "*.proto", SearchOption.AllDirectories);
            protoFileFolds = new bool[protoFiles.Length];
        }

        prevRefreshTime = Time.time;
    }


    private void OnGUI()
    {
        if (GUILayout.Button("step1:Proto to CS", GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
        
            string _path = Application.dataPath.Replace("Assets", "");
           
            RunMyBat("aa.bat", _path + "/ProtobufBuilder/");
            // string command =  File.ReadAllText(_path + "/ProtobufBuilder/aa.bat");
            // Execute(command);
            AssetDatabase.Refresh();
            Debug.Log("<color=green>step1:生成CS文件完成</color>:Path:"+_path+"ProtobufBuilder/");
        }

        if (GUILayout.Button("step2:copy cs to project", GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            Debug.Log("<color=green>step2:拷贝至项目文件夹...</color>");
            string _path = Application.dataPath.Replace("Assets", "") + "ProtobufBuilder/net";
            string _path2 = Application.dataPath + "/Scripts/OlderProto";
            if (CopyFolder(_path, _path2))
            {
                AssetDatabase.Refresh();
            }
            Debug.Log("源路径："+_path);
            Debug.Log("目标路径："+_path2);
        }
        if (GUILayout.Button("step3:gen proto deserialize", GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            Debug.Log("<color=green>step3:生成解析文件...</color>");
           
            NetUtilcs.ReadProtoBuff();
        }
        csharpFold = EditorGUILayout.Foldout(csharpFold, "C# generate option");
        if (csharpFold)
        {
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            if (GUILayout.Button("C# generate tool", GUILayout.Width(120)))
            {
                string path = EditorUtility.OpenFilePanel("Select Tool ProtoGen.exe in ProtoBuf", "", "");
                setting.CSharpGenerator = path.Replace("/", "\\");
                Debug.Log(setting.CSharpGenerator);
            }

            setting.CSharpGenerator = EditorGUILayout.TextField(new GUIContent(""), setting.CSharpGenerator);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            if (GUILayout.Button("C# output", GUILayout.Width(120)))
            {
                string path = EditorUtility.OpenFolderPanel("Select C# Output Dir", "", "");

                setting.CSharpOutput = path.Replace("/", "\\");
            }
            setting.CSharpOutput = EditorGUILayout.TextField(new GUIContent(""), setting.CSharpOutput);
            EditorGUILayout.EndHorizontal();
        }
        GUILayout.Space(20f);
        EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
        if (GUILayout.Button("Proto Files Dir", GUILayout.Width(120)))
        {
            string path = EditorUtility.OpenFolderPanel("Select Proto Files Dir", "", "");
            if (!string.IsNullOrEmpty(path))
            {
                protoFiles = Directory.GetFiles(path);
                setting.ProtoFilesPath = path.Replace("/", "\\");
            }
        }

        setting.ProtoFilesPath = EditorGUILayout.TextField("", setting.ProtoFilesPath);

        EditorGUILayout.EndHorizontal();
        GUILayout.Space(20f);
        
        jsonFold = EditorGUILayout.Foldout(jsonFold, "json generate option");
        if (jsonFold)
        {
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            if (GUILayout.Button("Json Files Dir", GUILayout.Width(120)))
            {
                string path = EditorUtility.OpenFolderPanel("Select Json Files Dir", "", "");
                if (!string.IsNullOrEmpty(path))
                {
                    jsonFiles = Directory.GetFiles(path);
                    setting.JsonFilesPath = path.Replace("/", "\\");
                }
            }
            setting.JsonFilesPath = EditorGUILayout.TextField("", setting.JsonFilesPath);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            if (GUILayout.Button("生成Json To cs", GUILayout.ExpandWidth(true), GUILayout.Height(30)))
            {
                Debug.Log("<color=green>Json to cs...</color>");
                jsonFiles = Directory.GetFiles(setting.JsonFilesPath,"*.json");
                foreach (var VARIABLE in jsonFiles)
                {
                    Debug.Log(Path.GetFileNameWithoutExtension(VARIABLE));
                    string jsonText = File.ReadAllText(VARIABLE);
                    GenClassFromJson genClassFromJson =
                        new GenClassFromJson(jsonText, Path.GetFileNameWithoutExtension(VARIABLE));
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorPrefs.SetString(protoSettingKey, JsonUtility.ToJson(setting));
        
        
        EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
        if (GUILayout.Button("Test", GUILayout.Width(120)))
        {
            Debug.Log("测试方法");

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Debug.Log("queue:"+queue.Peek());

            byte[] a = new byte[4];
            a[0] = 1;
            a[1] = 1;
            a[2] = 1;
            a[3] = 1;
            Array.Reverse(a);
            byte[] b = new byte[4];
            b[0] = 2;
            b[1] = 2;
            b[2] = 2;
            b[3] = 2;
            Array.Reverse(b);
            Array.Copy( a, 0, b, 0, 1 );
            int len = BitConverter.ToInt32(a);
            Debug.Log("len:"+len);
            int len2= BitConverter.ToInt32(b);
            Debug.Log("len:"+len2);
          
            
            //NetUtilcs.TestEncryption();
            //NetUtilcs.PacketBigMsg();
            // return;
            // string aa = "asdsadcHello ssss";
            // byte[] buf = System.Text.Encoding.Default.GetBytes(aa);
            // NetUtilcs.DebugBytes(buf);
            // buf = NetUtilcs.ZLibDotnetCompress(buf);
            // NetUtilcs.ByteToHex(buf);
            // NetUtilcs.DebugBytes(buf);
            // buf = NetUtilcs.ZLibDotnetDecompress(buf);
            // NetUtilcs.DebugBytes(buf);
            // string ppath = Application.persistentDataPath;
            // var buffer = File.ReadAllBytes(ppath + "/log4j2.xml");
            // string  str    = System.Text.Encoding.UTF8.GetString(buffer); 
            // PacketWriter pw = new PacketWriter();
            // pw.clsID = 100;
            // pw.methodID = 101;
            // pw.isEnd = 1;
            // pw.type = (byte)NET_CMD_TYPE.PB;
            // Request_Test_100_101 protoData = new Request_Test_100_101();
            // protoData.Account = "ASDASD";
            // protoData.Password =str;
            // pw.protoData = protoData;
            // //byte[] temp = DataCenter.PacketBuilder.Build(pw,(byte)NET_CMD_TYPE.PB,false);
            // byte[] bytes = protoData.ToByteArray();
            // NetUtilcs.DebugBytes(bytes);
            // byte[] buf = NetUtilcs.ZLibDotnetCompress(bytes);
            // NetUtilcs.DebugBytes(buf);
        }
        EditorGUILayout.EndHorizontal();
    }

    private static void RunMyBat(string batFile, string workingDir)
    {
        var path = FormatPath(workingDir + batFile);
        if (!System.IO.File.Exists(path))
        {
            Debug.LogError("bat文件不存在：" + path);
        }
        else
        {
            System.Diagnostics.Process proc = null;
            try
            {
                proc = new System.Diagnostics.Process();
                proc.StartInfo.WorkingDirectory = workingDir;
                proc.StartInfo.FileName = batFile;
                //proc.StartInfo.Arguments = args;
                //proc.StartInfo.CreateNoWindow = true;
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//disable dos window
                proc.Start();
                proc.WaitForExit();
                proc.Close();
            }
            catch (System.Exception ex)
            {
                Debug.LogFormat("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }
    }

    static string FormatPath(string path)
    {
        path = path.Replace("/", "\\");
        if (Application.platform == RuntimePlatform.OSXEditor)
            path = path.Replace("\\", "/");
        return path;
    }

    static bool CopyFolder(string sourcePath, string desPath)
    {
        if (!Directory.Exists((sourcePath)))
        {
            return false;
        }

        List<string> files = new List<string>(Directory.GetFiles(sourcePath));
        files.ForEach(c =>
        {
            string desFile = Path.Combine(desPath + "/", Path.GetFileName(c));
            File.Copy(c, desFile, true);
        });
        List<string> folders = new List<string>(Directory.GetDirectories(sourcePath));
        files.ForEach(c =>
        {
            string desDir = Path.Combine(desPath + "/", Path.GetFileName(c));
            CopyFolder(c, desDir);
        });
        return true;
    }

    #region  CMD运行
    public delegate void OnDataReceived(string message);

    public static OnDataReceived OnDataReceivedHandler;

    public static void Execute(string command)
    {
        command = "/c chcp 437&&" + command.Trim().TrimEnd('&') + "&exit";

        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = command;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.OutputDataReceived += (sender, e) => { OnDataReceivedHandler?.Invoke(e.Data); };

        process.ErrorDataReceived += (sender, e) => { OnDataReceivedHandler?.Invoke(e.Data); };

        process.Start();

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        process.WaitForExit();
        process.Close();
    }
    #endregion
}