//using ICSharpCode.SharpZipLib.Zip;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
 
namespace ZipWrapper
{
    public class TestzipWrapper : MonoBehaviour
    {
        // //  压缩和解压缩的输出路径
        // string zipOutputPath ;
        // string unzipOutputPath ;
        //
        //
        // // Start is called before the first frame update
        // void Start()
        // {
        //     zipOutputPath = Application.dataPath + "/ZipTestWithChineseFilesOrDirs中文.zip";
        //     unzipOutputPath = Application.dataPath + "/TestUnZip";
        //
        //     // 压缩和解压缩
        //     ZipWithChineseFilesOrDirs();
        //     UnzipWithChineseFilesOrDirs();
        //
        //     // 刷新资源文件夹
        //     AssetDatabase.Refresh();
        // }
        //
        // #region 中文压缩   
        // void ZipWithChineseFilesOrDirs() {
        //     // 要打包zip的路径数组
        //     string[] zipPaths = new string[] {
        //         Application.dataPath+ "/TestZip"
        //     };
        //     Debug.Log("zipOutputPath : " + zipOutputPath);
        //     ZipWrapper.Zip(zipPaths, zipOutputPath,null, new MyChineseZipCallback());
        // }
        //
        // public class MyChineseZipCallback : ZipWrapper.ZipCallback
        // {
        //
        //     public override bool OnPreZip(ZipEntry _entry)
        //     {
        //         _entry.IsUnicodeText = true;    // 支持中文
        //         return base.OnPreZip(_entry);
        //     }
        //
        //     public override void OnFinished(bool _result)
        //     {
        //         Debug.Log(GetType()+ "/OnFinished()/ Zip Finished……");
        //         base.OnFinished(_result);
        //     }
        // }
        //
        // #endregion
        //
        // #region 中文解压
        // void UnzipWithChineseFilesOrDirs()
        // {
        //     Debug.Log("zipOutputPath : " + zipOutputPath);
        //     ZipWrapper.UnzipFile(zipOutputPath, unzipOutputPath, null, new MyChineseUnzipCallback());
        //    
        // }
        //
        // public class MyChineseUnzipCallback : ZipWrapper.UnzipCallback
        // {
        //
        //     public override bool OnPreUnzip(ZipEntry _entry)
        //     {
        //         _entry.IsUnicodeText = true;    // 支持中文（后面测试，不带这个也可以解压中文文件（可能插件内部已经支持了））
        //         return base.OnPreUnzip(_entry);
        //     }
        //
        //     public override void OnFinished(bool _result)
        //     {
        //         Debug.Log(GetType() + "/OnFinished()/ Unzip Finished……");
        //         base.OnFinished(_result);
        //     }
        // }
        //
        // #endregion
    }
}