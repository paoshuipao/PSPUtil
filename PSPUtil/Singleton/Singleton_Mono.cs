using PSPUtil.StaticUtil;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PSPUtil.Singleton
{

    static class ManagerBase
    {
        private static Transform m_Manager;

        public static Transform Manager
        {
            get
            {
                if (m_Manager == null)
                {
                    GameObject parent = new GameObject("Singleton");
                    Object.DontDestroyOnLoad(parent);
                    m_Manager = parent.transform;
                }

                return m_Manager;
            }
        }
    }

    public abstract class Singleton_Mono<T> : MonoBehaviour       //继承Mono的 单例
        where T : MonoBehaviour
    {

        public GameObject CacheGameObject
        {
            get
            {
                if (null== m_Go)
                {
                    m_Go = gameObject;
                }
                return m_Go;
            }
        }

        public Transform CacheTransform
        {
            get
            {
                if (null== m_Transform)
                {
                    m_Transform = transform;
                }
                return m_Transform;
            }

        }


        public static T Instance
        {
            get
            {
                if (null == m_Instance)
                {
        
                    GameObject go= new GameObject(typeof(T).Name);
                    go.transform.SetParent(ManagerBase.Manager);
                    m_Instance = go.AddComponent<T>();
                }
                return m_Instance;
            }
        }



        public void Clear()
        {
            OnDestroy2Do();
            SceneManager.activeSceneChanged -= E_OnSceneChanged;
            DestroyImmediate(this.gameObject);
            m_Instance = null;
            m_Go = null;
            m_Transform = null;
        }


        #region 私有

        private static T m_Instance = null;
        private GameObject m_Go;
        private Transform m_Transform;


        void Awake()
        {
            SceneManager.activeSceneChanged += E_OnSceneChanged;
            OnAwake();
        }


        private void E_OnSceneChanged(Scene scene1,Scene scene2)
        {
            OnJumpScene();
        }


        void Start()
        {
            if (null == m_Instance)
            {
                MyLog.Error("Mono 单例类不需要手动添加到场景中！—— " + typeof(T));
                return;
            }
            OnStart();
        }

        void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        void FixedUpdate()
        {
            OnFixedUpdata();
        }







        protected virtual void OnAwake() { }

        protected virtual void OnStart() { }

        protected virtual void OnUpdate(float deltaTime) { }

        protected virtual void OnFixedUpdata() { }


        #endregion


        protected virtual void OnJumpScene() { }

        protected virtual void OnDestroy2Do() { } 

    }

}

