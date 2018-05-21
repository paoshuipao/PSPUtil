using PSPUtil.StaticUtil;

namespace PSPUtil.ErrorException
{
    public class Exception_ResNoPath : System.Exception          // Resources 路径加载错误
    {
        public Exception_ResNoPath(string resName)
        {
            MyLog.Red("Resources 加载都没有这个名字 —— "+ resName);
        }
    }
}
