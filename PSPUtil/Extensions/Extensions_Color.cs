
using UnityEngine;

namespace PSPUtil.Extensions
{
    public static class Extensions_Color
    {

        public static Color Lighter(this Color color)                    // 亮一点点
        {
            color.r += LightOffset;
            color.g += LightOffset;
            color.b += LightOffset;
            return color;
        }

        public static Color Darker(this Color color)                     // 暗一点点
        {
            color.r -= LightOffset;
            color.g -= LightOffset;
            color.b -= LightOffset;
            return color;
        }


        public static bool IsBlack(this Color color)                    // 是否 黑色或几乎为黑色
        {
            return color.r + color.g + color.b <= Mathf.Epsilon;
        }

        public static bool IsWhite(this Color color)                    // 是否 白色或几乎为白色
        {
            return color.r + color.g + color.b >= 1 - Mathf.Epsilon;
        }


        public static Color WithBrightness(this Color color, float brightness)  // new 一个 更亮点的 Color
        {
            if (color.IsBlack())
            {
                return new Color(brightness, brightness, brightness, color.a);
            }
            float factor = brightness / color.Brightness();
            float r = color.r * factor;
            float g = color.g * factor;
            float b = color.b * factor;
            float a = color.a;
            return new Color(r, g, b, a);
        }



        public static Color Invert(this Color color)                    // 返回一个新Color，它是此Color的反转
        {
            return new Color(1 - color.r, 1 - color.g, 1 - color.b, color.a);
        }


        #region 私有



        private const float LightOffset = 0.0625f;



        /// <summary>
        /// 返回颜色的亮度，定义为三个颜色通道的平均值
        /// </summary>
        private static float Brightness(this Color color)
        {
            return (color.r + color.g + color.b) / 3;
        }
        #endregion


    }
}
