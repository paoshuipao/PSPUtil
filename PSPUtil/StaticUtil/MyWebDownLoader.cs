using System;
using System.Collections;
using System.IO;
using PSPUtil.Control;
using UnityEngine;
using UnityEngine.Networking;

namespace PSPUtil.StaticUtil
{
    public static class MyWebDownLoader
    {

        public static bool IsWifi                                // 是否是无线
        {
            get
            {
                return Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
            }
        }


        public static bool GetWebConnection()                    // 获得网络情况，有网络就返回 true
        {
            bool isHasWeb = false;
            switch (Application.internetReachability)
            {
                case NetworkReachability.NotReachable:
                    MyLog.Red("没有网络");
                    break;
                case NetworkReachability.ReachableViaCarrierDataNetwork:
                    MyLog.Blue("使用移动网络");
                    isHasWeb = true;
                    break;
                case NetworkReachability.ReachableViaLocalAreaNetwork:
                    isHasWeb = true;
                    break;
            }
            return isHasWeb;
        }


        //下载 1.url 2.回调 3.设置超过多少秒中止下载，默认没限制----------------------------------------------------------------------------------

        public static void DownAssetBundle(string url,               // 下载 AssetBundle  如 xxx.u3d
            Action<AssetBundle> onFinish, Action<float> onProgress = null, int timeOut = 0)
        {
            if (GetWebConnection())
            {
                Ctrl_Coroutine.Instance.StartCoroutine(GetAssetBundle(url, onFinish, onProgress, timeOut));
            }
        }

        public static void DownAudioClip(string url,                 // 下载 声频 如 xxx.ogg
            Action<AudioClip> onFinish, int timeOut = 0)
        {
            if (GetWebConnection())
            {
                Ctrl_Coroutine.Instance.StartCoroutine(GetAudioClip(url, onFinish, timeOut));
            }
        }

        public static void DownTexture(string url,                   // 下载图片
            Action<Texture2D> onFinish, int timeOut = 0)
        {
            if (GetWebConnection())
            {
                Ctrl_Coroutine.Instance.StartCoroutine(GetTexture(url, onFinish, timeOut));
            }
        }


#if UNITY_STANDALONE_WIN
        public static void DownMovieTexture(string url,              // 下载视频 只能给win用
            Action<MovieTexture> onFinish, int timeOut = 0)
        {
            if (GetWebConnection())
            {
                Ctrl_Coroutine.Instance.StartCoroutine(GetMovieTexture(url, onFinish, timeOut));
            }
        }
#endif


        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="savePath">文件保存的完整路径</param>
        /// <param name="onFinish">完成回调</param>
        /// <param name="onProgress">进度回调</param>
        /// <param name="timeOut">设置超过多少秒中止下载，默认没限制</param>
        public static void DownFile(string url, string savePath,     // 下载文件
            Action onFinish, Action<float> onProgress, int timeOut = 0)
        {
            if (GetWebConnection())
            {
                Ctrl_Coroutine.Instance.StartCoroutine(GetFile(url, savePath, timeOut, onFinish, onProgress));
            }
        }

        public static void DownFile(string url, string savePath,Action<string> onFinish) 
        {
            if (GetWebConnection())
            {
                Ctrl_Coroutine.Instance.StartCoroutine(GetFile(url, savePath, 0, () =>
                {
                    if (null!= onFinish)
                    {
                        onFinish(savePath);
                    }
                },null));
            }
        }



        public static void DownTxt(string url, Action<string> onFinish)
        {
            if (GetWebConnection())
            {
                Ctrl_Coroutine.Instance.StartCoroutine(GetText(url, onFinish));
            }
        }
        public static void DownTxt(string url, string txtPath)    // 下载txt到本地
        {
            if (GetWebConnection())
            {
                Ctrl_Coroutine.Instance.StartCoroutine(GetText(url, txtPath));
            }
        }


        public static IEnumerator GetTexture(string url, Action<Texture2D> onFinish, int timeOut)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
            {
                if (timeOut > 0)
                {
                    request.timeout = timeOut;
                }
                yield return request.SendWebRequest();
                if (isNoError(request))
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(request);
                    if (null != onFinish && null != texture)
                    {
                        onFinish(texture);
                    }
                }
            }
            yield return 0;
        }


        public static IEnumerator GetAssetBundle(string url, Action<AssetBundle> onFinish)
        {
            using (UnityWebRequest request = UnityWebRequest.GetAssetBundle(url))
            {
                UnityWebRequestAsyncOperation uwraq = request.SendWebRequest();
                yield return uwraq;
                if (isNoError(request))
                {
                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                    if (null != onFinish && null != bundle)
                    {
                        onFinish(bundle);
                    }
                }
            }
            yield return 0;
        }


        public static IEnumerator GetAssetBundle(string url, Action<AssetBundle> onFinish, Action<float> onProgress, int timeOut)
        {

            using (UnityWebRequest request = UnityWebRequest.GetAssetBundle(url))
            {
                if (timeOut > 0)
                {
                    request.timeout = timeOut;
                }
                UnityWebRequestAsyncOperation uwraq = request.SendWebRequest();
                while (!uwraq.isDone)
                {
                    if (null != onProgress)
                    {
                        onProgress(uwraq.progress);
                    }
                    yield return 0;
                }
                if (isNoError(request))
                {
                    AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
                    if (null != onFinish && null != bundle)
                    {
                        onFinish(bundle);
                    }
                }
            }
            yield return 0;

        }

        public static IEnumerator GetAudioClip(string url, Action<AudioClip> onFinish, int timeOut)
        {
            using (UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.OGGVORBIS))
            {
                if (timeOut > 0)
                {
                    request.timeout = timeOut;
                }
                yield return request.SendWebRequest();
                if (isNoError(request))
                {
                    AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
                    if (null != onFinish && null != clip)
                    {
                        onFinish(clip);
                    }
                }
            }
            yield return 0;
        }


        public static IEnumerator GetFile(string url, string fileFullPath, int timeOut, Action onFinish, Action<float> onProgress)
        {
            MyIO.FileExistsDelte(fileFullPath);
            string dir = Path.GetDirectoryName(fileFullPath);
            if (string.IsNullOrEmpty(dir))
            {
                MyLog.Red("这个路径得出的文件夹路径为空 —— " + fileFullPath);
                yield break;
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                if (timeOut > 0)
                {
                    request.timeout = timeOut;
                }
                DownloadHandlerFile file = new DownloadHandlerFile(fileFullPath);
                file.removeFileOnAbort = true;                   // 下载被中止或错误删除创建的文件
                request.disposeUploadHandlerOnDispose = true;
                request.downloadHandler = file;
                UnityWebRequestAsyncOperation asy = request.SendWebRequest();
                while (!asy.isDone)
                {
                    if (null != onProgress)
                    {
                        onProgress(asy.progress);
                    }
                    yield return null;
                }
                if (isNoError(request) && null != onFinish)
                {
                    onFinish();
                }
            }
            yield return 0;
        }


#if UNITY_STANDALONE_WIN
        public static IEnumerator GetMovieTexture(string url, Action<MovieTexture> onFinish, int timeOut)
        {
            using (UnityWebRequest request = UnityWebRequestMultimedia.GetMovieTexture(url))
            {
                if (timeOut > 0)
                {
                    request.timeout = timeOut;
                }
                yield return request.SendWebRequest();
                if (isNoError(request))
                {
                    MovieTexture mt = DownloadHandlerMovieTexture.GetContent(request);
                    if (null != onFinish && null != mt)
                    {
                        onFinish(mt);
                    }
                }
            }
        }
#endif



        // 返回字符串
        public static IEnumerator GetText(string url, Action<string> onFinish)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                if (isNoError(request) && null != onFinish)
                {
                    string res = request.downloadHandler.text;
                    if (!string.IsNullOrEmpty(res))
                    {
                        onFinish(res);
                    }
                    else
                    {
                        MyLog.Red("下载的文本数据为空");
                    }
                }
            }
        }



        // 记录在文本中
        public static IEnumerator GetText(string url, string txtPath)
        {
            string dir = Path.GetDirectoryName(txtPath);
            if (string.IsNullOrEmpty(dir))
            {
                MyLog.Red("这个路径得出的文件夹路径为空 —— " + txtPath);
                yield break;
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                MyIO.FileExistsDelte(txtPath);
                using (StreamWriter sw = File.CreateText(txtPath))
                {
                    sw.Write(request.downloadHandler.text);
                    sw.Close();
                }
            }
        }

        // 记录在文本中 + 返回字符串
        public static IEnumerator GetText(string url, string txtPath, Action<string> action)
        {
            string dir = Path.GetDirectoryName(txtPath);
            if (string.IsNullOrEmpty(dir))
            {
                MyLog.Red("这个路径得出的文件夹路径为空 —— " + txtPath);
                yield break;
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                MyIO.FileExistsDelte(txtPath);
                using (StreamWriter sw = File.CreateText(txtPath))
                {
                    string webTest = request.downloadHandler.text;
                    if (string.IsNullOrEmpty(webTest))
                    {
                        MyLog.Red("网络下载的 files 文本为空");
                    }
                    else
                    {
                        sw.Write(request.downloadHandler.text);
                        if (null != action)
                        {
                            action(webTest);
                        }
                    }
                    sw.Close();
                }
            }
            yield return 0;
        }


        /// <summary>
        /// 使用 www 下载文件
        /// </summary>
        /// <param name="url">网络文件Url</param>
        /// <param name="localPath">下载文件的路径</param>
        /// <param name="action">完成</param>
        /// <returns></returns>
        public static IEnumerator UseWWWGetFile(string url, string localPath, Action action)
        {
            string dir = Path.GetDirectoryName(localPath);
            if (string.IsNullOrEmpty(dir))
            {
                MyLog.Red("这个路径得出的文件夹路径为空 —— " + localPath);
                yield break;
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            WWW www = new WWW(url);
            yield return www;
            if (www.isDone)
            {
                File.WriteAllBytes(localPath, www.bytes);
                if (null != action)
                {
                    action();
                }
            }
            www.Dispose();
            yield return 0;
        }



        private static bool isNoError(UnityWebRequest request)
        {
            bool tmp = true;
            if (!string.IsNullOrEmpty(request.error) || request.isNetworkError)
            {
                MyLog.Red(request.error + " 请求错误 —— " + request.url);
                tmp = false;
            }
            else if (request.isHttpError)
            {
                MyLog.Red("网络连接错误,错误号码为 —— " + request.responseCode);
                tmp = false;
            }
            return tmp;
        }


    }

}

