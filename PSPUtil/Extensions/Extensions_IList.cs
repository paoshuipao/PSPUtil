using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PSPUtil.Extensions
{
    public static class Extensions_IList
    {

        public static bool IsNullOrEmpty<T>(this IList<T> items)      // 是否为空或者没有数据
        {
            return items == null || !items.Any();
        }


        public static void RandomIList<T>(this IList<T> list)         // 随机打乱这个集合
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do
                {
                    provider.GetBytes(box);
                }
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }




        /// <summary>
        /// List( 11,22,33 )  -> SetLength(1)  -> List( 11 )
        /// List( 11,22,33 )  -> SetLength(5)  -> List( 11,22,33,0,0 )
        /// </summary>
        public static void SetLength<T>(this IList<T> list, int length)              // 将 List 的数增加或减少到指定的数目
        {
            if (list == null)
            {
                throw new Exception("list 为 null");
            }

            if (length < 0)
            {
                throw new ArgumentException("设定的长度必须大于或等于 0");
            }

            if (list.GetType().IsArray)
            {
                throw new ArgumentException("无法在数组上使用SetLength扩展方法。 使用 Array.Resize 或 ListUtilities.SetLength");
            }
            else
            {
                while (list.Count < length)
                {
                    list.Add(default(T));
                }

                while (list.Count > length)
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
        }


        public static void SetLength<T>(this IList<T> list, int length, T defaultAddValue)   // 默认增加的值 如 int 默认是0，现在不要0，要其他
        {
            if (list == null)
            {
                throw new Exception("list 为 null");
            }

            if (length < 0)
            {
                throw new ArgumentException("设定的长度必须大于或等于 0");
            }

            if (list.GetType().IsArray)
            {
                throw new ArgumentException("无法在数组上使用SetLength扩展方法。 使用 Array.Resize 或 ListUtilities.SetLength");
            }
            else
            {
                while (list.Count < length)
                {
                    list.Add(defaultAddValue);
                }

                while (list.Count > length)
                {
                    list.RemoveAt(list.Count - 1);
                }
            }
        }





    }
}
