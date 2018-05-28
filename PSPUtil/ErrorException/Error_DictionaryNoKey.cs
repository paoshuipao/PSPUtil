using PSPUtil.StaticUtil;

namespace PSPUtil.ErrorException
{
    public class Error_DictionaryNoKey : System.Exception                      // 字典没有对应 Key
    {
        public Error_DictionaryNoKey(string keyName) 
        {
            MyLog.Red("Dictionary 没有注册过这个 Key"+ keyName);

        }

    }
}
