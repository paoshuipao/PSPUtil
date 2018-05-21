using System;
using PSPUtil.StaticUtil;
using UnityEngine;

namespace PSPUtil.Attribute
{

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]//只能给字段 ，可以使用多个
    public class MyHeadAttribute : PropertyAttribute
    {
        public readonly string Description;                      //头部说明文字

        public readonly MyEnumColor TextColor;                   //文字颜色

        public readonly int OffsetX = 10;                          //X轴偏移


        public MyHeadAttribute(string description, MyEnumColor colorEnum)
        {
            Description = description;
            TextColor = colorEnum;
        }

        public MyHeadAttribute(string description)
        {
            Description = description;
            TextColor = MyEnumColor.Green;
        }

        public MyHeadAttribute(string description, MyEnumColor textColor, int offsetX)
        {
            Description = description;
            TextColor = textColor;
            OffsetX = offsetX;
        }



    }

}

