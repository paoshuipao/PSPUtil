namespace PSPUtil.Extensions
{
    public static class Extensions_Float
    {

        public static string ToTiemStr(this float timeValue)
        {
            int minutes = (int)(timeValue / 60.0f);
            int seconds = (int)(timeValue % 60.0f);
            string strMinutes = "";
            string strSeconds = "";

            if (minutes < 10)
            {
                strMinutes += "0";
            }
            if (seconds < 10)
            {
                strSeconds += "0";
            }

            strMinutes += minutes;
            strSeconds += seconds;

            return string.Format("{0}:{1}", strMinutes, strSeconds);
        }




    }
}
