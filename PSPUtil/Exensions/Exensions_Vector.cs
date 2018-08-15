
using System;
using System.Text;
using UnityEngine;

namespace PSPUtil.Exensions
{
    public static class Exensions_Vector
    {

        //——————————————————Vector2——————————————————
        public static string ToStr(this Vector2 v2)                       // ToString 打印
        {
            return "( " + v2.x + " ， " + v2.y + " )";
        }
         
        public static Vector2 AddXY(this Vector2 v2, float value)         // XY 都各自添加 value
        {
            v2.x += value;
            v2.y += value;
            return v2;
        }



        public static Vector2 Projection(this Vector2 v2, Vector2 @base)  // 相对@base的投影，比如：(2,5) 在 x轴（1，0）的投影是（2，0）
        {
            var direction = @base.normalized;
            var magnitude = Vector2.Dot(v2, direction);
            return direction * magnitude;
        }


        public static Vector2 Round(this Vector2 v2, int decimals = 1)    // 四舍五入
        {
            return new Vector2((float)Math.Round(v2.x, decimals), (float)Math.Round(v2.y, decimals));
        }



        //——————————————————Vector3——————————————————


        public static Vector3 AddXYZ(this Vector3 v3, float value)         // XYY 都各自添加 value
        {
            v3.x += value;
            v3.y += value;
            v3.z += value;
            return v3;
        }

        public static Vector3 Projection(this Vector3 v3, Vector3 @base)   // 投影
        {
            var direction = @base.normalized;
            var magnitude = Vector3.Dot(v3, direction);
            return direction * magnitude;
        }

        public static string ToStr(this Vector3 v3)                        // ToString 打印
        {
            StringBuilder sb =new StringBuilder();
            sb.Append("( ");
            sb.Append(v3.x);
            sb.Append(" ， ");
            sb.Append(v3.y);
            sb.Append(" ， ");
            sb.Append(v3.z);
            sb.Append(" )");
            return sb.ToString();
        }



        public static Vector3 Round(this Vector3 v3, int decimals = 1)     // 四舍五入
        {
            return new Vector3((float)Math.Round(v3.x, decimals), (float)Math.Round(v3.y, decimals), (float)Math.Round(v3.z, decimals));
        }



        //TODO Rect————————————————————————————————————




        public static Vector2 TopLeft(this Rect rect)
        {
            return new Vector2(rect.xMin, rect.yMin);
        }

        public static Rect ScaleSizeBy(this Rect rect, float scale)
        {
            return rect.ScaleSizeBy(scale, rect.center);
        }

        public static Rect ScaleSizeBy(this Rect rect, float scale, Vector2 pivotPoint)
        {
            Rect result = rect;
            result.x -= pivotPoint.x;
            result.y -= pivotPoint.y;
            result.xMin *= scale;
            result.xMax *= scale;
            result.yMin *= scale;
            result.yMax *= scale;
            result.x += pivotPoint.x;
            result.y += pivotPoint.y;
            return result;
        }

        public static Rect ScaleSizeBy(this Rect rect, Vector2 scale)
        {
            return rect.ScaleSizeBy(scale, rect.center);
        }

        public static Rect ScaleSizeBy(this Rect rect, Vector2 scale, Vector2 pivotPoint)
        {
            Rect result = rect;
            result.x -= pivotPoint.x;
            result.y -= pivotPoint.y;
            result.xMin *= scale.x;
            result.xMax *= scale.x;
            result.yMin *= scale.y;
            result.yMax *= scale.y;
            result.x += pivotPoint.x;
            result.y += pivotPoint.y;
            return result;
        }


    }
}
