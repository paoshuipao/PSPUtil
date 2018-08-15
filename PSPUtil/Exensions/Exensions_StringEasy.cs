using System.Text;
using PSPUtil.StaticUtil;

namespace PSPUtil.Exensions
{
    public enum StringGeShi
    {
        English,                                             // 全英文
        China,                                               // 全中文
        EnglishChinaMix                                      // 中英混合 
    }


    public static class Exensions_StringEasy
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


        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

    }

}

