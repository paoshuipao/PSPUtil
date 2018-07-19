using System.Text;
using PSPUtil.Exensions;
using UnityEngine;

namespace PSPUtil.StaticUtil
{
    public static class MyLog
    {
        public static void HideAllLog()                          // 不使用 Log
        {
            m_IsLog = false;
        }

        //——————————————————可以使用格式——————————————————
        public static void Green(object str)
        {
            DoLog(str, MyEnumColor.Green);
        }
        public static void Green(string str, object arg0)
        {
            Green(string.Format(str, arg0));
        }
        public static void Green(string str, object arg0, object arg1)
        {
            Green(string.Format(str, arg0, arg1));
        }
        public static void Green(string str, object arg0, object arg1, object arg2)
        {
            Green(string.Format(str, arg0, arg1, arg2));
        }

        public static void Blue(object str)
        {
            DoLog(str, MyEnumColor.Blue);
        }
        public static void Blue(string str, object arg0)
        {
            Blue(string.Format(str, arg0));
        }
        public static void Blue(string str, object arg0, object arg1)
        {
            Blue(string.Format(str, arg0, arg1));
        }
        public static void Blue(string str, object arg0, object arg1, object arg2)
        {
            Blue(string.Format(str, arg0, arg1, arg2));
        }

        public static void Yellow(object str)
        {
            DoLog(str, MyEnumColor.Yellow);
        }
        public static void Yellow(string str, object arg0)
        {
            Yellow(string.Format(str, arg0));
        }
        public static void Yellow(string str, object arg0, object arg1)
        {
            Yellow(string.Format(str, arg0, arg1));
        }
        public static void Yellow(string str, object arg0, object arg1, object arg2)
        {
            Yellow(string.Format(str, arg0, arg1, arg2));
        }


        //—————————————————其他———————————————————
        public static void Red(object str)
        {
            DoLog(str, MyEnumColor.Red);
        }
        public static void Red(object str, Object obj)
        {
            DoLog(obj, MyEnumColor.Red, obj);
        }
        public static void Hui(object str)
        {
            DoLog(str, MyEnumColor.Hui);
        }
        public static void LightBlue(object str)
        {
            DoLog(str, MyEnumColor.LightBlue);
        }
        public static void Orange(object str) 
        {
            DoLog(str, MyEnumColor.Orange);
        }
        public static void Orange(object str, Object obj)
        {
            DoLog(str, MyEnumColor.Orange,obj);
        }


        //————————————————报错————————————————————

        public static void Error(object str,Object obj = null)
        {
            if (null != obj)
            {
                Debug.LogError(str.ToString().AddRed(true), obj);
            }
            else
            {
                Debug.LogError(str.ToString().AddRed(true));
            }
        }


        #region 私有
        private static bool m_IsLog = true;

        private static void DoLog(object obj,MyEnumColor color ,Object choose = null)
        {
            string tmp = (null == obj) ? "null" : obj.ToString();
            if (m_IsLog)
            {
                if (null!=choose)
                {
                    Debug.Log(tmp.AddColor(color, true),choose);
                }
                else
                {
                    Debug.Log(tmp.AddColor(color, true));
                }
                
            }
        }


        #endregion

    }

}

