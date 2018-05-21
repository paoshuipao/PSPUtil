using System;
using System.IO;
using System.Security.Cryptography;
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


    public static class Exensions_String
    {

        //——————————————————加密——————————————————

        /// <summary>
        /// 带密码的加密字符串 如加密失败返回源串
        /// </summary>
        /// <param name="jiaMiString">加密字符串 </param>
        /// <param name="key">定义一个8位的密码串</param>
        /// <returns></returns>
        public static string AddPassword(this string jiaMiString,string key = "58741236") 
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(jiaMiString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                cStream.Close();
                mStream.Close();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return jiaMiString;
            }
        }


        /// <summary>
        /// 解密字符串   如解密失败返源串
        /// </summary>
        /// <param name="jieMiString">要解密的字符串</param>
        /// <param name="key">密码</param>
        /// <returns></returns>
        public static string ParsePassword(this string jieMiString, string key = "58741236") 
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(key);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(jieMiString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                cStream.Close();
                mStream.Close();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                MyLog.Red("解密失败，返回原来的string ——" + jieMiString);
                return jieMiString;
            }
        }



        //———————————————————下面是Md5加密—————————————————


        public static string Md5AddPassword(this string source)       // Md5加密
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(source);
            byte[] md5Data = md5.ComputeHash(data, 0, data.Length);
            md5.Clear();

            string destString = "";
            for (int i = 0; i < md5Data.Length; i++)
            {
                destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
            }
            destString = destString.PadLeft(32, '0');
            return destString;
        }

        public static string Md5ParsePassword(this string file)       // Md5解密
        {
            try
            {
                FileStream fs = new FileStream(file, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(fs);
                fs.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("md5file() fail, error:" + ex.Message);
            }
        }





        //——————————————————格式 扩展——————————————————

        /// <summary>
        /// 判断这段字符串是什么格式（全中文/全英文/中英混合）
        /// </summary>
        /// <returns></returns>
        public static StringGeShi GetStringGeShi(this string str)
        {
            bool isEnglish = str[0] <= 127;

            for (int i = 0; i < str.Length; i++)
            {
                // 是汉字而且第1个是英文  ||  是英文而且第1个是中文
                if ((str[i] > 127 && isEnglish) || (str[i] < 127 && !isEnglish))
                {
                    return StringGeShi.EnglishChinaMix;
                }
            }

            if (isEnglish)
            {
                return StringGeShi.English;
            }
            else
            {
                return StringGeShi.China;
            }
        }


        /// <summary>
        /// 对（全中文/全英文/中英混合）格式
        ///  <例子>
        /// "thisIsCamelCase" -> "This Is Camel Case"
        /// "继承Object" -> "继承 Object"
        /// </例子>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FormatString(this string str)
        {
            StringGeShi geShi = GetStringGeShi(str);
            string tmp = str;
            switch (geShi)
            {
                case StringGeShi.English:
                    tmp = str.FormatEnglishString();
                    break;
                case StringGeShi.EnglishChinaMix:
                    tmp = str.FormatChinaString();
                    break;
            }
            return tmp;
        }



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



        #region 私有
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };





        /// <summary>
        /// 格式化英语字符串
        /// <例子>
        /// "thisIsCamelCase" -> "This Is Camel Case"
        /// </例子>
        /// </summary>
        private static string FormatEnglishString(this string str)
        {
            StringBuilder sb = new StringBuilder(str.Length);

            sb.Append(char.ToUpper(str[0]));                   // 第一个大写

            for (int i = 1; i < str.Length; i++)
            {
                char c = str[i];
                if (char.IsUpper(c) && !char.IsUpper(str[i - 1]))
                {
                    sb.Append(' ');
                }
                sb.Append(c);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 格式化字符串
        /// <例子>
        ///"继承Object" -> "继承 Object"
        /// </例子>
        /// </summary>
        private static string FormatChinaString(this string str)
        {
            StringBuilder sb = new StringBuilder();
            bool isEnglish = str[0] <= 127;
            for (int i = 0; i < str.Length; i++)
            {
                // 是汉字而且前面是英文
                if (str[i] > 127 && isEnglish)
                {
                    sb.Append(' ').Append(str[i]);
                    isEnglish = false;
                }
                else if (str[i] < 127 && !isEnglish)
                {
                    sb.Append(' ').Append(str[i]);
                    isEnglish = true;
                }
                else
                {
                    sb.Append(str[i]);
                }

            }
            return sb.ToString();
        }

        #endregion


    }

}

