using PSPUtil.StaticUtil;
using UnityEngine;

namespace PSPUtil.Exensions
{
    public static class Exensions_Transform                                        
    {

        /// <summary>
        /// 检测入侵者是否入侵范围内 （指甲刀展开正前范围，判断是否夏提雅进来了）
        /// </summary>
        /// <param name="ranger">展开范围者</param>
        /// <param name="rightRang">左右各多少米</param>
        /// <param name="forward">前方多少米</param>
        /// <param name="ruQinZhe">入侵者</param>
        /// <returns></returns>
        public static bool IsAttackRange(this Transform ranger, float rightRang, float forward, Transform ruQinZhe)
        {
            byte tmpCount = 0;
            Vector3 ranger2RuQinZhe = ruQinZhe.position - ranger.position; //范围者指向入侵者的向量
            float length = ranger2RuQinZhe.magnitude;                      //指向入侵者的向量的长度
            float rightAngle = Vector3.Dot(ranger.right.normalized, ranger2RuQinZhe.normalized);
            if (rightAngle > 0)                                        // 表示他在右边
            {
                float rigthDistance = rightAngle * length;           // 投射在 rigth 轴上长度
                if (rigthDistance <= rightRang)                       // 在右边的距离上
                {
                    tmpCount++;
                }
            }

            //下面同理 向上
            float forwardAngle = Vector3.Dot(ranger.forward.normalized, ranger2RuQinZhe.normalized);
            if (forwardAngle > 0)                                      // 表示他在右边
            {
                float forwardDistance = forwardAngle * length;       // 投射在 forward 轴上长度
                if (forwardDistance <= forward)                      // 在前方的距离上
                {
                    tmpCount++;
                }
            }

            //下面同理 向左
            float leftAngle = Vector3.Dot(-ranger.right.normalized, ranger2RuQinZhe.normalized);
            if (leftAngle > 0)
            {
                float leftDistance = leftAngle * length;
                if (leftDistance <= rightRang)
                {
                    tmpCount++;
                }
            }


            return tmpCount == 2;
        }


        public static T GetComponentNo2Log<T>(this Transform transform)    // 获得这个组件，没有打Log
            where T : Component
        {
            T tmp = transform.GetComponent<T>();
            if (null == tmp)
            {
                MyLog.Red("没有添加过这个组件 —— " + typeof(T), transform);
            }
            return tmp;
        }


        public static void SetX(this Transform transform, float x)        // 设置 transform.position.x  
        {
            Vector3 newPosition = new Vector3(x, transform.position.y, transform.position.z);
            transform.position = newPosition;

        }
        #region 类似

        public static void SetY(this Transform transform, float y)        // 设置 transform.position.y
        {
            Vector3 newPosition = new Vector3(transform.position.x, y, transform.position.z);

            transform.position = newPosition;
        }

        public static void SetZ(this Transform transform, float z)         // 设置 transform.position.z
        {
            var newPosition = new Vector3(transform.position.x, transform.position.y, z);
            transform.position = newPosition;
        }
        public static void SetXY(this Transform transform, float x, float y)
        {
            var newPosition = new Vector3(x, y, transform.position.z);
            transform.position = newPosition;
        }
        public static void SetXZ(this Transform transform, float x, float z)
        {
            var newPosition = new Vector3(x, transform.position.y, z);
            transform.position = newPosition;
        }
        public static void SetYZ(this Transform transform, float y, float z)
        {
            var newPosition = new Vector3(transform.position.x, y, z);
            transform.position = newPosition;
        }
        public static void SetXYZ(this Transform transform, float x, float y, float z)
        {
            var newPosition = new Vector3(x, y, z);
            transform.position = newPosition;
        }


        #endregion

        public static void Reset(this Transform transform)                // 重置
        {
            transform.localRotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
        }




    }
}
