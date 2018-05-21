using System;
using System.Reflection;


namespace PSPUtil.StaticUtil
{
    public static class MyType
    {
        public static Type GetType(this string typeFullName)       //string -> Type
        {
            if (string.IsNullOrEmpty(typeFullName))
            {
                MyLog.Red("过分了传个空值过来");
                return null;
            }
            Type t = Type.GetType(typeFullName, false, true);
            if (null == t)
            {
                MyLog.Red("Type的全名称写错了 —— " + typeFullName);
                MyLog.Green("给个全称看看： —— " + "UnityEditorInternal.LogEntries,UnityEditor.dll");
            }
            return t;
        }



        public static void ShowAllMethods<T>(                    //Log出这个Class的所有方法
            ShowMethodType showMethodType)
        {
            ShowAllMethods(typeof(T), showMethodType);
        }
        #region ShowAllMethods 其他重载
        public enum ShowMethodType
        {
            None,                                                //默认 全部    
            OnlyPublic,                                          //全部Public
            NoPublic,                                            //除了Public
            PublicStatic,                                        //Public static
            PublicNoStatic,                                      //只有Public的
        }


        static void ShowAllMethods(Type t, ShowMethodType showMethodType)
        {
            MemberInfo[] infos = null;
            switch (showMethodType)
            {
                case ShowMethodType.OnlyPublic:
                    infos = t.GetMethods(BindingFlags.Public);
                    break;
                case ShowMethodType.NoPublic:
                    infos = t.GetMethods(BindingFlags.NonPublic);
                    break;
                case ShowMethodType.PublicStatic:
                    infos = t.GetMethods(BindingFlags.Public & BindingFlags.Static);
                    break;
                case ShowMethodType.PublicNoStatic:
                    infos = t.GetMethods(BindingFlags.Public & BindingFlags.Instance);
                    break;
                default:
                    infos = t.GetMethods();
                    break;
            }
            foreach (MemberInfo info in infos)
            {
                MyLog.Blue(info.Name);
            }
        }
        public static void ShowAllMethods(object obj, ShowMethodType showMethodType)
        {
            ShowAllMethods(obj.GetType(), showMethodType);
        }

        public static void ShowAllMethods(string typeString, ShowMethodType showMethodType)
        {
            ShowAllMethods(GetType(typeString), showMethodType);
        }



        #endregion



        public static T NewTypeClass<T>()                        //相当于 new T() 
        {
            return (T)NewTypeClass(typeof(T));
        }
        #region NewTypeClass 其他重载
        public static object NewTypeClass(string typeFullName)
        {
            return NewTypeClass(GetType(typeFullName));
        }
        public static object NewTypeClass(Type t)
        {
            return Activator.CreateInstance(t);
        }
        #endregion



        public static void RunStaticMethod<T>(                   //运行Static方法 /methodName方法名 /values 参数
            string methodName, params object[] values)
        {
            Type t = typeof(T);
            RunStaticMethod(t, methodName, values);
        }
        #region RunStaticMethod 其他重载
        public static void RunStaticMethod(Type t, string methodName, params object[] values)
        {
            MethodInfo methodInfo = t.GetMethod(methodName);
            if (null == methodInfo)
            {
                MyLog.Red(t + "  方法名写错了，找不到这个方法 ——" + methodName);
                return;
            }

            methodInfo.Invoke(null, values.Length == 0 ? null : values);
        }


        public static void RunStaticMethod(string typeFullName, string methodName, params object[] values)
        {
            RunStaticMethod(GetType(typeFullName), methodName, values);
        }
        #endregion




        public static void RunNormalMethod(object obj, string methodName , params object[] values)
        {
            MethodInfo methodInfo = obj.GetType().GetMethod(methodName);
            if (null == methodInfo)
            {
                MyLog.Red(obj + "  方法名写错了，找不到这个方法 ——" + methodName);
                return;
            }
            methodInfo.Invoke(obj, values.Length == 0 ? null : values);
        }

        public static void RunNormalMethod<T>(string methodName, //运行普通的方法 /methodName方法名 /values 参数
            params object[] values)
        {
            RunNormalMethod(typeof(T), methodName, values);
        }
        #region RunNormalMethod 其他重载

        public static void RunNormalMethod(Type t, string methodName, object[] values)
        {
            object obj = NewTypeClass(t);
            MethodInfo methodInfo = t.GetMethod(methodName);
            if (null == methodInfo)
            {
                MyLog.Red(t + "  方法名写错了，找不到这个方法 ——" + methodName);
                return;
            }
            methodInfo.Invoke(obj, values.Length == 0 ? null : values);
            obj = null;
        }



        public static void RunNormalMethod(string typeFullName, string methodName, params object[] values)
        {
            RunNormalMethod(GetType(typeFullName), methodName, values);
        }


        #endregion





    }
}

