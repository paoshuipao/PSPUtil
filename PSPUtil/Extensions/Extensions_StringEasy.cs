using System;
using System.Text;
using PSPUtil.StaticUtil;

namespace PSPUtil.Extensions
{
    public enum StringGeShi
    {
        English,                                             // 全英文
        China,                                               // 全中文
        EnglishChinaMix                                      // 中英混合 
    }


    public static class Extensions_StringEasy
    {

        //——————————————————富文本 扩展——————————————————


        /// <summary>
        /// 富文本 —— 加粗
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行 </param>
        /// <returns></returns>
        public static string AddBold(this string str, bool isAddSpaceLine = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<b>");
            sb.Append(str);
            sb.Append("</b>");
            if (isAddSpaceLine)
            {
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// 富文本 —— 斜体
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行 </param>
        /// <returns></returns>
        public static string AddItalic(this string str, bool isAddSpaceLine = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<i>");
            sb.Append(str);
            sb.Append("</i>");
            if (isAddSpaceLine)
            {
                sb.AppendLine();
            }
            return sb.ToString();
        }

        /// <summary>
        /// 富文本 —— 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="size">大小</param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddSize(this string str, int size, bool isAddSpaceLine = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<size=");
            sb.Append(size);
            sb.Append(">");
            sb.Append(str);
            sb.Append("</size>");
            if (isAddSpaceLine)
            {
                sb.AppendLine();
            }
            return sb.ToString();
        }


        public static string AddColor(this string str, MyEnumColor color, bool isAddSpaceLine)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<color=");
            sb.Append(MyColor.GetColorString(color));
            sb.Append(">");
            sb.Append(str);
            sb.Append("</color>");
            if (isAddSpaceLine)
            {
                sb.AppendLine();
            }
            return sb.ToString();
        }
        #region 颜色


        /// <summary>
        /// 富文本 —— 加白色
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddWhite(this string str, bool isAddSpaceLine = false)
        {
            return AddColor(str, MyEnumColor.White, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加蓝色
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddBlue(this string str, bool isAddSpaceLine = false)
        {
            return AddColor(str, MyEnumColor.Blue, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加浅蓝
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddLightBlue(this string str, bool isAddSpaceLine = false)
        {
            return AddColor(str, MyEnumColor.LightBlue, isAddSpaceLine);
        }
        /// <summary>
        /// 富文本 —— 加绿色
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddGreen(this string str, bool isAddSpaceLine = false)
        {
            return AddColor(str, MyEnumColor.Green, isAddSpaceLine);
        }
        /// <summary>
        /// 富文本 —— 加浅绿
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddLightGreen(this string str, bool isAddSpaceLine = false)
        {
            return AddColor(str, MyEnumColor.LightGreen, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加红色
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddRed(this string str, bool isAddSpaceLine = false)
        {
            return AddColor(str, MyEnumColor.Red, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加橙色
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddOrange(this string str, bool isAddSpaceLine = false)
        {
            return AddColor(str, MyEnumColor.Orange, isAddSpaceLine);
        }


        /// <summary>
        /// 富文本 —— 加黄色
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddYellow(this string str, bool isAddSpaceLine = false)
        {
            return AddColor(str, MyEnumColor.Yellow, isAddSpaceLine);
        }


        /// <summary>
        /// 富文本 —— 加灰色
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddHui(this string str, bool isAddSpaceLine = false)
        {
            return AddColor(str, MyEnumColor.Hui, isAddSpaceLine);
        }



        #endregion


        public static string AddBoldAndColor(this string str, MyEnumColor color, bool isAddSpaceLine)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<color=");
            sb.Append(MyColor.GetColorString(color));
            sb.Append(">");
            sb.Append("<b>");
            sb.Append(str);
            sb.Append("</b>");
            sb.Append("</color>");
            if (isAddSpaceLine)
            {
                sb.AppendLine();
            }
            return sb.ToString();
        }
        #region 颜色 + 加粗


        /// <summary>
        /// 富文本 —— 加白色 + 加粗
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddWhiteBold(this string str, bool isAddSpaceLine = false)
        {
            return AddBoldAndColor(str, MyEnumColor.White, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加蓝色 + 加粗
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddBlueBold(this string str, bool isAddSpaceLine = false)
        {
            return AddBoldAndColor(str, MyEnumColor.Blue, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加浅蓝 + 加粗
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddLightBlueBold(this string str, bool isAddSpaceLine = false)
        {
            return AddBoldAndColor(str, MyEnumColor.LightBlue, isAddSpaceLine);
        }
        /// <summary>
        /// 富文本 —— 加绿色 + 加粗
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddGreenBold(this string str, bool isAddSpaceLine = false)
        {
            return AddBoldAndColor(str, MyEnumColor.Green, isAddSpaceLine);
        }
        /// <summary>
        /// 富文本 —— 加浅绿 + 加粗
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddLightGreenBold(this string str, bool isAddSpaceLine = false)
        {
            return AddBoldAndColor(str, MyEnumColor.LightGreen, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加红色 + 加粗
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddRedBold(this string str, bool isAddSpaceLine = false)
        {
            return AddBoldAndColor(str, MyEnumColor.Red, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加橙色 + 加粗
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddOrangeBold(this string str, bool isAddSpaceLine = false)
        {
            return AddBoldAndColor(str, MyEnumColor.Orange, isAddSpaceLine);
        }


        /// <summary>
        /// 富文本 —— 加黄色 + 加粗
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddYellowBold(this string str, bool isAddSpaceLine = false)
        {
            return AddBoldAndColor(str, MyEnumColor.Yellow, isAddSpaceLine);
        }


        /// <summary>
        /// 富文本 —— 加灰色 + 加粗
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddHuiBold(this string str, bool isAddSpaceLine = false)
        {
            return AddBoldAndColor(str, MyEnumColor.Hui, isAddSpaceLine);
        }



        #endregion


        public static string AddColorAndSize(this string text, MyEnumColor color, int size, bool isAddSpaceLine)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<color=");
            sb.Append(MyColor.GetColorString(color));
            sb.Append(">");
            sb.Append("<size=");
            sb.Append(size);
            sb.Append(">");
            sb.Append(text);
            sb.Append("</size>");
            sb.Append("</color>");
            if (isAddSpaceLine)
            {
                sb.AppendLine();
            }
            return sb.ToString();
        }
        #region 颜色 + 大小


        /// <summary>
        /// 富文本 —— 加白色 + 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddWhiteSize(this string str, int size, bool isAddSpaceLine = false)
        {
            return AddColorAndSize(str, MyEnumColor.White, size, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加蓝色 + 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddBlueSize(this string str, int size, bool isAddSpaceLine = false)
        {
            return AddColorAndSize(str, MyEnumColor.Blue, size, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加浅蓝 + 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddLightBlueSize(this string str, int size, bool isAddSpaceLine = false)
        {
            return AddColorAndSize(str, MyEnumColor.LightBlue, size, isAddSpaceLine);
        }
        /// <summary>
        /// 富文本 —— 加绿色 + 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddGreenSize(this string str, int size, bool isAddSpaceLine = false)
        {
            return AddColorAndSize(str, MyEnumColor.Green, size, isAddSpaceLine);
        }
        /// <summary>
        /// 富文本 —— 加浅绿 + 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddLightGreenSize(this string str, int size, bool isAddSpaceLine = false)
        {
            return AddColorAndSize(str, MyEnumColor.LightGreen, size, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加红色 + 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddRedSize(this string str, int size, bool isAddSpaceLine = false)
        {
            return AddColorAndSize(str, MyEnumColor.Red, size, isAddSpaceLine);
        }

        /// <summary>
        /// 富文本 —— 加橙色 + 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddOrangeSize(this string str, int size, bool isAddSpaceLine = false)
        {
            return AddColorAndSize(str, MyEnumColor.Orange, size, isAddSpaceLine);
        }


        /// <summary>
        /// 富文本 —— 加黄色 + 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddYellowSize(this string str, int size, bool isAddSpaceLine = false)
        {
            return AddColorAndSize(str, MyEnumColor.Yellow, size, isAddSpaceLine);
        }



        /// <summary>
        /// 富文本 —— 加灰色 + 大小
        /// </summary>
        /// <param name="str">原字符串></param>
        /// <param name="isAddSpaceLine">是否在最后加上一空行</param>
        /// <returns></returns>
        public static string AddHuiSize(this string str, int size, bool isAddSpaceLine = false)
        {
            return AddColorAndSize(str, MyEnumColor.Hui, size,isAddSpaceLine);
        }

        #endregion



        //————————————————————————————————————

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }


        /// <summary>
        /// 是否包含这个字符串 
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <param name="toCheck">是否包含的字符串</param>
        /// <param name="comparisonType">例如 StringComparison.OrdinalIgnoreCase ->可以包含大写</param>
        /// <returns></returns>
        public static bool IsContains(this string source, string toCheck, StringComparison comparisonType)
        {
            return source.IndexOf(toCheck, comparisonType) >= 0;
        }


        /// <summary>
        /// 如果此字符串为null，为空或仅包含空格，则返回 true
        /// </summary>
        /// <param name="str">要检查的字符串</param>
        public static bool IsNullOrWhitespace(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (char.IsWhiteSpace(str[i]) == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }



        //——————————————————关于 value 在原字符串的应用——————————————————


        /// <summary>
        /// 系统就是没有用 string 分割的
        /// </summary>
        public static string[] Split(this string s, string value, StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            return s.Split(new string[] { value }, splitOptions);
        }


        /// <summary>
        /// 如：abc123cdf123  -> 2
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static int GetValueCount(this string str, string value)              // 获得 value 在字符串中的数量
        {
            int occurrences = 0;
            int startingIndex = 0;

            while ((startingIndex = str.IndexOf(value, startingIndex, StringComparison.Ordinal)) >= 0)
            {
                ++occurrences;
                ++startingIndex;
            }

            return occurrences;
        }


        /// <summary>
        /// 如： abc123cdf123  -> 找到123 的第 num 个索引位置 -> num = 1   -> 3 ，找不到返回 -1
        /// </summary>
        /// <param name="target">原字符串</param>
        /// <param name="value">要找的值</param>
        /// <param name="num">第几个  如 num = 2  -> 9</param>
        /// <returns></returns>
        public static int IndexOfValue(this string target, string value, int num)   // value 在字符串的索引
        {

            string[] result = target.Split(value);
            num--;
            if (num >= 0 && num < result.Length)
            {
                int index = 0;
                for (int i = 0; i <= num; i++)
                {
                    index += result[i].Length + value.Length;
                }
                return index - value.Length;
            }
            else
            {
                return -1;
            }
        }



    }

}

