using PSPUtil.StaticUtil;

namespace PSPUtil.ErrorException
{
    public class Error_ResourcesNoPath : System.Exception                      // Resources 路径加载错误
    {
        public Error_ResourcesNoPath(string resName)
        {
            MyLog.Red("Resources 加载都没有这个名字 —— "+ resName);
        }
    }
}
