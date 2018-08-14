using System;
using System.Collections.Generic;
using UnityEngine;

namespace PSPUtil.Attribute
{

    [AttributeUsage(AttributeTargets.Field)]         // 只能作用于 枚举
    public class MyChinaEnumAttribute : PropertyAttribute
    {

        public string EnumTypeName { get; private set; }             // 枚举左边的中文名



        public MyChinaEnumAttribute(string enumTypeName)
        {
            EnumTypeName = enumTypeName;
        }



    }

}
