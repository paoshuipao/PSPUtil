/*
using System;
using PSPUtil.StaticUtil;
using UnityEngine;

namespace PSPUtil.Attribute
{
    [AttributeUsage(AttributeTargets.Field)]                     //只能给字段使用
    public class MyUseColorAttribute : PropertyAttribute
    {
        public readonly MyEnumColor TextColor;
        public readonly int Min;
        public readonly int Max;


        public MyUseColorAttribute(MyEnumColor color)
        {
            TextColor = color;
            Min = -1;
            Max = -1;
        }


        //使用滑动条
        public MyUseColorAttribute(MyEnumColor textColor, int min, int max)
        {
            TextColor = textColor;
            Min = min;
            Max = max;
        }

    }

}

*/
