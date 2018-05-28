using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PSPUtil.Exensions
{
    public static class Exensions_List                                         // List 集合扩展
    {

        // 集合 for 每次加2 
        public static void ForAdd2<T>(this List<T> list, [NotNull]Action<T, T> twoValueAction, [NotNull]Action<T> oneValueAction)
        {
            list.ToArray().ForAdd2(twoValueAction, oneValueAction);
        }



    }
}
