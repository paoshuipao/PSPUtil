using PSPUtil.ErrorException;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PSPUtil.Singleton
{
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
                    GameObject parent= GameObject.Find("Manager");
                    if (null == parent)
                    {
                        parent=new GameObject("Manager");
                        DontDestroyOnLoad(parent);
                    }
                    GameObject go= new GameObject(typeof(T).Name);
                    go.transform.SetParent(parent.transform);
                    m_Instance = go.AddComponent<T>();
                }
                return m_Instance;
            }
        }

        #region 私有
        private static T m_Instance = null;
        private GameObject m_Go;
        private Transform m_Transform;


        void Awake()
        {
            SceneManager.activeSceneChanged += (scene1, scene2) =>
            {
                OnJumpScene();
            };
            OnAwake();
        }


        void Start()
        {
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

        void OnDestroy()
        {
            OnDestroy2Do();
            m_Instance = null;
        }


        #endregion


        protected virtual void OnJumpScene() { }

        protected virtual void OnDestroy2Do() { } 

    }

}

