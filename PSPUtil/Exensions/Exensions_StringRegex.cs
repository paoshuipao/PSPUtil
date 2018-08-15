
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PSPUtil.Exensions
{
    public static class Exensions_StringRegex            // string 扩展 （利用正则）
    {

        //——————————————————利用正则 ->判断——————————————————

        public static bool IsdEmailStr(this string emailString)           // 是否 e-mail 格式 
        {
            isInvalid = false;
            if (string.IsNullOrEmpty(emailString))
            {
                return false;
            }

            // Use IdnMapping class to convert Unicode domain names. 
            emailString = Regex.Replace(emailString, @"(@)(.+)$", DomainMapper, RegexOptions.None);

            if (isInvalid)
            {
                return false;
            }

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


        public static bool IsNum(this string str)                         // 是否全数字
        {
            return (!string.IsNullOrEmpty(str)) && (new Regex(@"^-?[0-9]*\.?[0-9]+$").IsMatch(str.Trim()));
        }


        public static bool IsContainsNume(this string str)                // 是否包含数字
        {
            return (!string.IsNullOrEmpty(str)) && (new Regex(@"[0-9]+").IsMatch(str));
        }


        //——————————————————利用正则 ->删除——————————————————


        public static string RemoveAllKongGe(this string str)            // 删除所有类型的空白字符（空格、制表符、换行符）
        {
            return Regex.Replace(str, @"\s", "");
        }

        #region 私有
        private static bool isInvalid;
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
