﻿using PSPUtil.StaticUtil;
using UnityEngine;

namespace PSPUtil.Exensions
{
    public static class Exensions_GameObject
    {

        public static T GetOrAddComponent<T>(this GameObject go) // 获得或者添加
            where T : Component
        {
            T tmp = go.GetComponent<T>();
            if (null == tmp)
            {
                tmp = go.AddComponent<T>();
            }
            return tmp;
        }



        public static T GetComponentNo2Log<T>(this GameObject go)// 获得这个组件，没有打Log
            where T : Component
        {
            T tmp = go.GetComponent<T>();
            if (null == tmp)
            {
                MyLog.Red("没有添加这个组件 —— "+typeof(T),go);
            }
            return tmp;
        }

    }
}
