using System;
using System.IO;

namespace PSPUtil.StaticUtil
{
    public static class MyIO
    {

        //—————————————————— 针对文件 ——————————————————

        public static void FileExistsDelte(string path)                        // 文件存在就删除
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }


        public static void FileCreate(string filePath)                         // 文件创建
        {
            FileExistsDelte(filePath);                    //   先删除旧的
            CreateFileUpperFolder(filePath);              //   创建父文件夹
            File.Create(filePath);                        //   最后才是创建文件
        }


        public static void FileCopy(string copyPath, string newPath)           // 复制文件

        {
            if (!File.Exists(copyPath))
            {
                MyLog.Red("复制文件都没有 —— "+ copyPath);
                return;
            }
            if (File.Exists(newPath))
            {
                File.Delete(newPath);
                MyLog.Green("覆盖旧的文件");
            }
            File.Copy(copyPath, newPath);
        }


        public static void FileMove(string oldPath, string newPath)            // 文件移动、剪切
        {
            FileExistsDelte(newPath);
            CreateFileUpperFolder(newPath);
            File.Move(oldPath, newPath);
        }

        public static void FileRename(string path, string name)                // 重改名文件
        {
            if (File.Exists(path))
            {
                path = path.Replace(@"\", "/");
                int tmpCount = path.LastIndexOf("/", StringComparison.Ordinal);
                string newFolderPath = path.Substring(0, tmpCount + 1);    // 前路径
                if (Path.HasExtension(path))      // 判断原路径是否有后缀
                {
                    if (!name.Contains("."))   // 如果 name 没有后缀就帮它加下
                    {
                        name = "." + Path.GetExtension(path);
                    }
                }

                File.Move(path, newFolderPath + name);
            }
            else
            {
                MyLog.Red("路径不存在文件 —— " + path);
            }

        }


        public static string GetUpperFile(string path)                         // 获得上一级文件 C:/abc/a.txt => C:/a.txt
        {
            path = path.Replace(@"\", "/");
            string suffix = MyAssetUtil.GetFileSuffix(path);
            int tmpCount = path.LastIndexOf("/", StringComparison.Ordinal);
            if (!string.IsNullOrEmpty(suffix))
            {
                suffix = "." + suffix;
            }
            return path.Substring(0, tmpCount) + suffix;
        }



        //——————————————————针对 文件夹——————————————————


        public static void DeteleFolder(string path)                           // 删除文件夹
        {
            if (!Directory.Exists(path))
            {
                return;
            }
            Directory.Delete(path, true);
        }


        //——————————————————文件/文件夹——————————————————

        public static void DeleteFileAndFolder(params string[] paths)          // 删除集合中所有的文件或者文件夹
        {
            foreach (string path in paths)
            {
                if (path.Contains("."))
                {
                    FileExistsDelte(path);
                }
                else
                {
                    DeteleFolder(path);
                }
            }
        }


        //——————————————————针对 txt 文本——————————————————


        public static StreamWriter TxtFileCreate(string filePath,ETxtFileType txtType = ETxtFileType.Txt)  // 创建文本 txt/xml/json
        {
            if (File.Exists(filePath))
            {
                MyLog.Red("文件原来是存在的，现先删除了 —— "+filePath);
                File.Delete(filePath);
            }
            CreateFileUpperFolder(filePath);
            string lastStr = "";
            switch (txtType)
            {
                case ETxtFileType.Txt:
                    lastStr = ".txt";
                    break;
                case ETxtFileType.Xml:
                    lastStr = ".xml";
                    break;
                case ETxtFileType.Json:
                    lastStr = ".json";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(txtType), txtType, null);
            }

            if (!filePath.Contains("."))
            {
                filePath += lastStr;
            }
            return File.CreateText(filePath);
        }


        #region 私有
        public enum ETxtFileType
        {
            Txt,
            Xml,
            Json,

        }



        private static void CreateFileUpperFolder(string path)                 // 创建文件前先创建上一级的文件夹
        {
            path = path.Replace(@"\", "/");
            int tmpCount = path.LastIndexOf("/", StringComparison.Ordinal);
            string newFolderPath = path.Substring(0, tmpCount);
            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
            }
        }

        #endregion


    }
}
