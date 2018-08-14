using System;
using System.Globalization;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using PSPUtil.StaticUtil;

namespace PSPUtil.Exensions
{
    public static class Exensions_StringHard
    {

        //——————————————————加密——————————————————

        /// <summary>
        /// 带密码的加密字符串 如加密失败返回源串
        /// </summary>
        /// <param name="jiaMiString">加密字符串 </param>
        /// <param name="key">定义一个8位的密码串</param>
        /// <returns></returns>
        public static string AddPassword(this string jiaMiString, string key = "58741236")
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
        public static StringGeShi IsChinaStr(this string str)        // 是否中文
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
        public static string ChinaFormat(this string str)
        {
            StringGeShi geShi = IsChinaStr(str);
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



        //——————————————————判断正则——————————————————

        public static bool IsdEmailStr(this string emailString)       // 是否 e-mail 格式 
        {
            isInvalid = false;
            if (string.IsNullOrEmpty(emailString)) { return false; }

            // Use IdnMapping class to convert Unicode domain names. 
            emailString = Regex.Replace(emailString, @"(@)(.+)$", DomainMapper, RegexOptions.None);

            if (isInvalid) { return false; }

            // Return true if strIn is in valid e-mail format. 
            return Regex.IsMatch(emailString,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase);
        }





        public static bool IsIPAddressStr(this string str)                // 是否 IP 地址
        {
            return Regex.IsMatch(str, @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
        }




        #region 私有
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static bool isInvalid;

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


        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (Exception)
            {
                isInvalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        #endregion

    }
}
