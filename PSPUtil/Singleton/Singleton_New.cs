using PSPUtil.StaticUtil;

namespace PSPUtil.Singleton
{
    public abstract class Singleton_New<T>
        where T : class, new()
    {
        public static T Instance                                 //单例
        {
            get
            {
                if (null == m_Instance)
                {
                    m_Instance = new T();
                }
                return m_Instance;
            }
        }


        protected virtual void Init() { }                        //初始化，运行一次


        #region 私有
        protected Singleton_New()
        {
            if (null != m_Instance)
            {
                MyLog.Error("已存在的单例又再添加？ ——" + typeof(T));
                return;
            }
            Init();
        }

        private static T m_Instance = null;

        #endregion


    }

}
