using System;
using System.Collections.Generic;
using System.Text;
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



        //————————————————————————————————————
        public static bool IsNullOrEmpty<T>(this List<T> list)                  // 是否为空或者没数据
        {
            return ((list == null) || (list.Count == 0));
        }


        public static T GetRandomElement<T>(this List<T> list)                 // 从List中随机获得一个值
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static void RandomList<T>(this List<T> list)                    // 随机集合
        {
            T temp;
            for (int i = list.Count - 1; i > 0; i--)
            {
                // Get a random position lower than i
                int randomPosition = UnityEngine.Random.Range(0, i);
                // Swap values
                temp = list[i];
                list[i] = list[randomPosition];
                list[randomPosition] = temp;
            }
        }

        public static string ToStr<T>(this List<T> list, string separator = "\n")// ToString 打印
        {
            if (list.IsNullOrEmpty())
            {
                return "集合为 Null 或者没有数值";
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count - 1; i++)
            {
                builder.Append(i);
                builder.Append("->  ");
                builder.Append(list[i]);
                builder.Append(separator);
            }
            builder.Append(list.Count - 1);
            builder.Append("->  ");
            builder.Append(list[list.Count - 1]);
            return builder.ToString();
        }


    }
}
