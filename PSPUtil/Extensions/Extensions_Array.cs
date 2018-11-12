using System;
using System.Text;
using JetBrains.Annotations;
using PSPUtil.StaticUtil;

namespace PSPUtil.Extensions
{
    public static class Extensions_Array                                         // 数组的扩展方法
    {

        //————————————————————————————————————

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


        //————————————————————————————————————


        public static bool IsNullOrEmpty<T>(this T[] array)                    // 是否为空或者没数据
        {
            return ((array == null) || (array.Length == 0));
        }



        public static T GetRandomElement<T>(this T[] array)                   // 从数组中随机获得一个值
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }



        public static void RandomArray<T>(this T[] array)                     // 随机数组
        {
            T temp;
            for (int i = array.Length - 1; i > 0; i--)
            {
                // Get a random position lower than i
                int randomPosition = UnityEngine.Random.Range(0, i);
                // Swap values
                temp = array[i];
                array[i] = array[randomPosition];
                array[randomPosition] = temp;
            }
        }





        //——————————————————ToString——————————————————


        public static string ToStr<T>(this T[] array, string splitStr = "\n")// ToString 打印
        {
            if (array.IsNullOrEmpty())
            {
                return "数组为 Null 或者没有数值";
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < array.Length - 1; i++)
            {
                builder.Append(i);
                builder.Append("->  ");
                builder.Append(array[i]);
                builder.Append(splitStr);
            }
            builder.Append(array.Length - 1);
            builder.Append("->  ");
            builder.Append(array[array.Length - 1]);
            return builder.ToString();
        }








    }
}
