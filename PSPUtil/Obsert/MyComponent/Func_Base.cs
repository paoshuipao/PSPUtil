/*
using PSPUtil.Exensions;
using PSPUtil.StaticUtil;
using UnityEngine;

namespace PSPUtil.MyComponent
{
    [DisallowMultipleComponent]
    [AddComponentMenu("我的组件/Func_Base", 1)]
    public class Func_Base : MonoBehaviour
    {

        public void SetActive(bool isAcitve)                         // 设置这物体是激活还是不激活
        {
            CachedGameObject.SetActive(isAcitve);
        }


        public T GetOrAddComponent<T>()                              // 获得或者添加组件
            where T : UnityEngine.Component
        {
            return CachedGameObject.GetOrAddComponent<T>();
        }

        public T GetComponentNo2Log<T>()                              // 只能获得，没有打Log
            where T : UnityEngine.Component
        {
            return CachedGameObject.GetComponentNo2Log<T>();
        }


        public GameObject CachedGameObject                           //gameObject
        {
            get
            {
                if (!m_CachedGameObject)
                {
                    m_CachedGameObject = this.gameObject;
                }
                return m_CachedGameObject;
            }
        }

        public Transform CachedTransform                             //transform
        {
            get
            {
                if (!m_CachedTransform)
                {
                    m_CachedTransform = this.transform;
                }
                return m_CachedTransform;
            }
        }


        #region 私有

        private Transform m_CachedTransform;
        private GameObject m_CachedGameObject;

        void Awake()
        {
            MyGetComponent.RegistUIFunction(name, this);
        }

        void OnDestroy()
        {
            MyGetComponent.UnregistUIFunction(name);
            OnDestroy2Do();
        }

        protected virtual void OnDestroy2Do() { }

        #endregion

    }
}
*/
