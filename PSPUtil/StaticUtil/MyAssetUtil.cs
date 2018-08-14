using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace PSPUtil.StaticUtil
{
    public static class MyAssetUtil                                     
    {

        public static string GetApplicationDataPathNoAssets()    // E://abc/Assets ->E://abc/
        {
            string dataPath = Application.dataPath;
            return dataPath.Remove(dataPath.Length - 7, 7);
        }


        // 截取Assets后面的路径：fullName:E://abc/Assets/xx ->Assets/xx  返回：Assets/xx
        public static string GetAssetsBackPath(string fullName)
        {
            int tmpCount = fullName.IndexOf("Assets", StringComparison.Ordinal);
            if (tmpCount == -1)
            {
                throw new Exception("路径中都没有包含Assets ——" + fullName);
            }
            return fullName.Substring(tmpCount, fullName.Length - tmpCount);
        }


        public static string[] GetAssetsBackPath(string[] fullNames)
        {
            string[] tmp = new string[fullNames.Length];
            for (int i = 0; i < fullNames.Length; i++)
            {
                tmp[i] = GetAssetsBackPath(fullNames[i]);
            }
            return tmp;
        }




        // 截取Assets前面的路径：fullName:E://abc/Assets/xx ->Assets/xx  返回：E://abc/
        public static string GetAssetsProPath(string fullName)
        {
            string[] strArray = fullName.Split(new[] { "Assets" }, StringSplitOptions.None);
            return strArray[0];
        }


        //从全路径获得文件名,带后缀的 
        public static string GetFileNameByFullName(string fullName)
        {
            fullName= fullName.Replace(@"\", "/");
            int tmpCount = fullName.LastIndexOf("/", StringComparison.Ordinal);
            string fileName = fullName.Remove(0, tmpCount + 1);
            return fileName;
        }



        //从全路径获得文件名,不带后缀的 
        public static string GetFileNameByFullNameNoSuffix(string fullName)
        {
            string withSuffix = GetFileNameByFullName(fullName);
            string[] str = withSuffix.Split('.');
            switch (str.Length)
            {
                case 0:
                    MyLog.Red("为空？——" + fullName);
                    return null;
                case 1:
                    return withSuffix; //没有后缀名
                case 2:
                    return str[0];
                default:
                    MyLog.Orange("是有多个 点 ？ ——" + fullName);
                    return str[0];
            }

        }


        //获得文件后缀
        public static string GetFileSuffix(string fullName)
        {
            string[] str = fullName.Split('.');
            switch (str.Length)
            {
                case 0:
                    MyLog.Red("为空？——" + fullName);
                    return null;
                case 1:
                    return "";
                case 2:
                    return str[1];
                default:
                    MyLog.Orange("是有多个 点 ？ ——" + fullName);
                    return str[1];
            }

        }


        /*-------------------------------从全路径 得到 string ---------------------------------------------------*/


        public static string GetFullName(string assetPath)
        {
            return Application.dataPath.TrimEnd("Assets".ToCharArray()) + assetPath;
        }



        //————————————————从单一个名称来获取路径————————————————————


        public static string GetFullPathInAssets(string specialName)    // Assets\_Scripts_Function\ThirdParty\Ez
        {
            string[] paths = Directory.GetDirectories(Application.dataPath, specialName, SearchOption.AllDirectories);
            if (paths.Length > 1)
            {
                MyLog.Red("有多个这个名称的文件夹名 —— " + specialName);
            }
            return paths[0].Replace("/", "\\");
        }


        public static string GetAssetPathInAssets(string specialName)     // E:\Pro\NewPSPFrameWork\Assets\_Scripts_Function\ThirdParty\Ez
        {

            string[] paths = Directory.GetDirectories(Application.dataPath, specialName, SearchOption.AllDirectories);
            if (paths.Length > 1)
            {
                MyLog.Red("有多个这个名称的文件夹名 —— " + specialName);
            }
            string directoryPath = paths[0].Replace(Application.dataPath, "Assets");
            return directoryPath;
        }




    }

}


