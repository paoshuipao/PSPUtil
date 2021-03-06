﻿using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using PSPUtil.StaticUtil;
using System.Text;

namespace PSPUtil.Extensions
{
    public static class Extensions_Dictionary                      // 字典 扩展方法
    {

        //移除指定的
        public static Dictionary<T1, T2> RemoveWhere<T1, T2>(this Dictionary<T1, T2> dic,[NotNull]Func<T1, T2, bool> removeWhere)
        {
            List<T1> l_Key = new List<T1>(dic.Keys);

            for (int i = 0; i < l_Key.Count; i++)
            {
                if (removeWhere(l_Key[i], dic[l_Key[i]]))
                {
                    l_Key.Remove(l_Key[i]);
                }
            }
            return l_Key.ToDictionary(t => t, t => dic[t]);
        }


        //如果Key存在就修改
        public static void AddOrUpdate<T1, T2>(this Dictionary<T1, T2> dic, T1 key, T2 value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }


        /// <summary>
        /// 包含这个Key然后做什么
        /// </summary>
        /// <param name="dic">本体</param>
        /// <param name="key">key</param>
        /// <param name="warningLog">不包含给出的警告</param>
        /// <param name="action">包含做什么</param>
        public static void ContainsKey2Do<T1, T2>(this Dictionary<T1, T2> dic, T1 key,string warningLog,Action<T2> action)
        {
            if (dic.ContainsKey(key))
            {
                if (null!= action)
                {
                    action(dic[key]);
                }
            }
            else
            {
                MyLog.Orange(warningLog);
            }
        }



        public static bool IsNullOrEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dict)   // 是否为空或者没数据
        {
            return ((dict == null) || (dict.Count == 0));
        }






        //——————————————————ToString——————————————————


        public static string ToStr<TKey, TValue>(this Dictionary<TKey, TValue> dict, string separator = "\n")   // ToString 打印
        {
            if (dict.IsNullOrEmpty())
            {
                return "集合为 Null 或者没有数值";
            }
            StringBuilder sb = new StringBuilder();
            List<TKey> keyList =new List<TKey>(dict.Keys);

            for (int i = 0; i < keyList.Count - 1; i++)
            {
                TKey key = keyList[i];
                sb.Append(key);
                sb.Append("->  ");
                sb.Append(dict[key]);
                sb.Append(separator);
            }
            TKey lastKey = keyList[keyList.Count - 1];
            sb.Append(lastKey);
            sb.Append("->  ");
            sb.Append(dict[lastKey]);
            return sb.ToString();
        }








    }

}
