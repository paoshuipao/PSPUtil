using System.Text.RegularExpressions;
using UnityEngine;

namespace PSPUtil.StaticUtil
{
    public enum MyEnumColor
    {
        White,                                                   //白色  
        Hui,                                                     //灰色        
        LightBlue,                                               //浅蓝
        Blue,                                                    //蓝
        Yellow,                                                  //黄色
        Orange,                                                  //橙色
        Green,                                                   //绿色
        LightGreen,                                              //i浅绿色
        Red,                                                     //红色
    }


    public static class MyColor
    {

        public static Color GetColor(string str)                 //根据 "#FFFFFFFF" 或者 "#FFFF"格式来获取Color
        {
            if (ColorRegex.IsMatch(str))
            {
                if (str.Length == 5)                        //#RGBA
                {
                    string r = TwoChar2OneString(str[1]);
                    string g = TwoChar2OneString(str[2]);
                    string b = TwoChar2OneString(str[3]);
                    string a = TwoChar2OneString(str[4]);
                    int aa = GetNum(a);
                    int rr = GetNum(r);
                    int gg = GetNum(g);
                    int bb = GetNum(b);
                    return GetColor(rr, gg, bb,aa);
                }
                else if (str.Length == 9)                   //#RRGGBBAA
                {
                    int rr = GetNum(str.Substring(1, 2));
                    int gg = GetNum(str.Substring(3, 2));
                    int bb = GetNum(str.Substring(5, 2));
                    int aa = GetNum(str.Substring(7, 2));
                    return GetColor(rr, gg, bb,aa);
                }
                else
                {
                    MyLog.Red("不可能吧 返回白色");
                    return Color.white;
                }
            }
            else
            {
                MyLog.Red("颜色代码不符合 #FFFFFFFF 或者 #0000 —— " + str);
                return Color.white;
            }
        }


        public static Color GetColor(int r,int g,int b, int a = 256)   //根据 rgb 的值来获取Color
        {
            GetRGB(ref r);
            GetRGB(ref g);
            GetRGB(ref b);
            return new Color((float)r / 255, (float)g / 255, (float)b / 255, (float)a / 255);
        }





        public static Color GetColor(MyEnumColor enumColor)
        {
            return GetColor(GetColorString(enumColor));
        }


        public static string GetColorString(MyEnumColor enumColor)
        {
            string colorStr = "";
            switch (enumColor)
            {
                case MyEnumColor.White:
                    colorStr = "#ffffffff";
                    break;
                case MyEnumColor.Hui:
                    colorStr = "#c0c0c0ff";
                    break;
                case MyEnumColor.LightBlue:
                    colorStr = "#add8e6ff";
                    break;
                case MyEnumColor.Blue:
                    colorStr = "#00ffffff";
                    break;
                case MyEnumColor.Yellow:
                    colorStr = "#ffff00ff";
                    break;
                case MyEnumColor.Orange:
                    colorStr = "#ffa500E5";
                    break;
                case MyEnumColor.Green:
                    colorStr = "#00ff00E5";
                    break;
                case MyEnumColor.LightGreen:
                    colorStr = "#008000E5";
                    break;
                case MyEnumColor.Red:
                    colorStr = "#ff0000ff";
                    break;
                default:
                    colorStr = "#808000ff";
                    break;
            }
            return colorStr;
        }


        public static bool GetEnumColor(string str,ref MyEnumColor color)
        {
            bool res = true;
            switch (str)
            {
                case "red":
                    color=MyEnumColor.Red;
                    break;
                case "blue":
                    color = MyEnumColor.Blue;
                    break;
                case "green":
                    color = MyEnumColor.Green;
                    break;
                case "white":
                    color = MyEnumColor.White;
                    break;
                case "yellow":
                    color = MyEnumColor.Yellow;
                    break;
                case "orange":
                    color = MyEnumColor.Orange;
                    break;
                default:
                    res = false;
                    break;
            }
            return res;
        }



        #region 私有

        private static readonly Regex ColorRegex = new Regex(@"^#([0-9a-fA-F]{8}|[0-9a-fA-F]{4})$", RegexOptions.ExplicitCapture);

        private static void GetRGB(ref int num)
        {
            if (num < 0)
            {
                MyLog.Orange("设置颜色的RGB值小于0 —— " + num);
                num = 0;

            }
            if (num > 255)
            {
                MyLog.Orange("设置颜色的RGB值大于0 —— " + num);
                num = 255;
            }

        }


        //将16进制变为int
        private static int GetNum(string str)
        {
            int result = int.Parse(str, System.Globalization.NumberStyles.AllowHexSpecifier);
            return result;
        }


        private static string TwoChar2OneString(char c)
        {
            string str = c + "";
            return str + str;
        }

        #endregion


    }


}

