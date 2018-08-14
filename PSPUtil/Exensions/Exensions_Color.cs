
using UnityEngine;

namespace PSPUtil.Exensions
{
    public static class Exensions_Color
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



        //TODO————————————————————————————————————

        /// <summary>
        /// Returns the brightness of the Color, defined as the average off the three Color channels.
        /// </summary>
        /// <param name="color">The Color.</param>
        /// <returns>The new Color.</returns>
        public static float Brightness(this Color color)
        {
            return (color.r + color.g + color.b) / 3;
        }

        /// <summary>
        /// Returns a new Color with the RGB values scaled so that the color has the given brightness.
        /// <para>If the Color is too dark, a grey is returned with the right brighness.The alpha is left uncanged.</para> 
        /// </summary>
        /// <param name="color">The Color.</param>
        /// <param name="brightness">New brightness.</param>
        /// <returns>The new Color.</returns>
        public static Color WithBrightness(this Color color, float brightness)
        {
            if (color.IsApproximatelyBlack())
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

        /// <summary>
        /// Returns true if the Color is black or almost black, false otherwise.
        /// </summary>
        /// <param name="color">The Color.</param>
        /// <returns></returns>
		public static bool IsApproximatelyBlack(this Color color)
        {
            return color.r + color.g + color.b <= Mathf.Epsilon;
        }
        /// <summary>
        /// Returns true if the Color is white or almost white, false otherwise.
        /// </summary>
        /// <param name="color">The Color.</param>
        /// <returns></returns>
		public static bool IsApproximatelyWhite(this Color color)
        {
            return color.r + color.g + color.b >= 1 - Mathf.Epsilon;
        }
        /// <summary>
        /// Returns an opaque (no transparency) version of the given Color.
        /// </summary>
        /// <param name="color">The Color.</param>
        /// <returns></returns>
		public static Color Opaque(this Color color)
        {
            return new Color(color.r, color.g, color.b);
        }
        /// <summary>
        /// Returns a new Color that is the inversion of this Color.
        /// </summary>
        /// <param name="color">The Color.</param>
        /// <returns></returns>
        public static Color Invert(this Color color)
        {
            return new Color(1 - color.r, 1 - color.g, 1 - color.b, color.a);
        }

        /// <summary>
        /// Returns a new Color with the same settings and a new alpha.
        /// </summary>
        /// <param name="color">The Color.</param>
        /// <param name="alpha">Alpha for the Color.</param>
        /// <returns></returns>
        public static Color WithAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }

        #region 私有



        private const float LightOffset = 0.0625f;

        #endregion



    }
}
