using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using PSPUtil.StaticUtil;

namespace PSPUtil.Exensions
{
    public static class Exensions_Array                                         // 数组的扩展方法
    {

        public static T[] AddArray<T>(                           //在一个数组上再添加另一个数组
            this T[] firstArray,                                 //原数组
            T[] appendArray)                                     //增加的数组
        {

            if (appendArray == null)
            {
                MyLog.Red("添加的数组为null");
                return firstArray;
            }
            T[] ret = new T[firstArray.Length + appendArray.Length];
            firstArray.CopyTo(ret, 0);
            appendArray.CopyTo(ret, firstArray.Length);
            return ret;
        }



        // 数组 for 每次加2 
        public static void ForAdd2<T>(this T[] list, [NotNull]Action<T, T> twoValueAction, [NotNull]Action<T> oneValueAction)
        {
            int tmpLength = list.Length;                         // 总数
            for (int i = 0; i < tmpLength;)
            {
                if (i + 2 < tmpLength)                           // 多的是情况
                {
                    twoValueAction(list[i], list[i + 1]);
                    i += 2;
                }
                else if (i + 1 == tmpLength)                     // 最后剩下一个情况
                {
                    oneValueAction(list[i]);
                    break;

                }
                else if (i + 2 == tmpLength)                     // 最后剩下两个情况
                {
                    twoValueAction(list[i], list[i + 1]);
                    break;
                }
                else
                {
                    break;
                }
            }
        }



    }
}
