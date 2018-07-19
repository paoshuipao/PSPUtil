/*
using System.Collections.Generic;
using PSPUtil.MyComponent;
using UnityEngine;

namespace PSPUtil.StaticUtil
{
    public static class MyGetComponent
    {
        public static T Get<T>(string name, bool isLog = true)   //获得想要的脚本 1. GameObject名 2.是否打Log
            where T : Component
        {
            return GetFunc(name, isLog).GetComponent<T>();
        }


        public static Func_Base GetFunc(string name,             // 获得 Func_Base 组件
            bool isNeedError = true)
        {
            Func_Base func = null;
            if (nameK_MCBV.ContainsKey(name))                    // 包含情况
            {
                func = nameK_MCBV[name];
            }
            else                                                 // 不包含情况
            {
                if (isNeedError)
                {
                    GameObject go = GameObject.Find(name);
                    if (null != go)
                    {
                        MyLog.Orange("未添加 Func_Base 脚本 ", go);
                        func = go.AddComponent<Func_Base>();
                    }
                    else
                    {
                        MyLog.Red("这个名字不正确 —— " + name);
                    }
                }
            }
            return func;
        }


        public static GameObject GetGameObject(string name, bool isNeedError = true)
        {
            return GetFunc(name, isNeedError).CachedGameObject;
        }


        public static Transform GeTransform(string name)
        {
            return GetFunc(name).CachedTransform;
        }


        #region 私有

        private static readonly Dictionary<string, Func_Base> nameK_MCBV = new Dictionary<string, Func_Base>();

        public static void RegistUIFunction(string name, Func_Base subFunction)
        {
            if (!nameK_MCBV.ContainsKey(name))
            {
                nameK_MCBV.Add(name, subFunction);
            }
            else
            {
                MyLog.Red("这个名字重复注册 ——" + name);
            }

        }

        public static void UnregistUIFunction(string name)
        {
            if (nameK_MCBV.ContainsKey(name))
            {
                nameK_MCBV.Remove(name);
            }
        }


        #endregion





    }


}
*/
