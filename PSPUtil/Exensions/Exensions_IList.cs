using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PSPUtil.Exensions
{
    public static class Exensions_IList
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






    }
}
