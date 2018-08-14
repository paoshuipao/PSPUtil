/*
using System;

namespace PSPUtil.Exensions
{
    public static class Exensions_Type             // Type 扩展方法
    {

        public static T GetAttribute<T>(this Type type, bool inherit) where T : System.Attribute
        {
            object[] attrs = type.GetCustomAttributes(typeof(T), inherit);

            if (attrs.Length == 0)
            {
                return null;
            }
            else
            {
                return (T)attrs[0];
            }
        }
    }
}
*/
