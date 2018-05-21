using System;
using System.IO;

namespace PSPUtil.StaticUtil
{
    public static class MyIO
    {

        public static void DeteleFolder(string path)             // 删除文件夹
        {
            if (!Directory.Exists(path))
            {
                return;
            }
            Directory.Delete(path, true);
        }


        public static void CopyFile(string copyPath,             // 复制文件
            string newPath)
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


        public static void FileExistsDelte(string path)          // 文件存在就删除
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

        }


        public static string GetUpperFile(string path)           // 获得上一级文件 C:/abc/a.txt => C:/a.txt
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


        public static void DeleteFileAndFolder(                  // 删除集合中所有的文件或者文件夹
            params string[] paths)
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


        public static void FileMove(string oldPath,              // 文件移动、剪切
            string newPath)
        {
            FileExistsDelte(newPath);
            CreateFileUpperFolder(newPath);
            File.Move(oldPath, newPath);

        }

        public static void FileCreate(string filePath)           // 文件创建
        {
            FileExistsDelte(filePath);
            CreateFileUpperFolder(filePath);
            File.Create(filePath);
        }


        public static StreamWriter FileTxtCreate(string filePath)// 文本txt创建
        {
            FileExistsDelte(filePath);
            CreateFileUpperFolder(filePath);
            return File.CreateText(filePath);
        }


        private static void CreateFileUpperFolder(string path)   // 创建文件前先创建上一级的文件夹
        {
            path = path.Replace(@"\", "/");
            int tmpCount = path.LastIndexOf("/", StringComparison.Ordinal);
            string newFolderPath = path.Substring(0, tmpCount);
            if (!Directory.Exists(newFolderPath))
            {
                Directory.CreateDirectory(newFolderPath);
            }
        }


    }
}
