
namespace PSPUtil.Exensions
{
    public static class Exensions_Bool
    {
        public static int ToInt(this bool value)                  // true ->1  false->0
        {
            return value ? 1 : 0;
        }

        public static string ToLowerString(this bool value)       // 小写(正常 ToString:False)  ->现是 false
        {
            return value.ToString().ToLower();
        }


        public static string ToStr(this bool value, string trueString, string falseString)    // ToString 打印
        {
            return value.ToValue<string>(trueString, falseString);
        }


        public static T ToValue<T>(this bool value, T trueValue, T falseValue)               // 三元表达式
        {
            return value ? trueValue : falseValue;
        }




    }
}
