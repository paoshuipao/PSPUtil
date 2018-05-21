using System;
using PSPUtil.StaticUtil;

namespace PSPUtil.ErrorException
{
    public class Exception_SwitchEnumNoDefines : System.Exception// Switch 枚举没有定义
    {
        public Exception_SwitchEnumNoDefines(Enum enumName)
        {
            MyLog.Red("Switch 枚举 case 还没有定义 —— " + enumName);
        }


    }
} 
