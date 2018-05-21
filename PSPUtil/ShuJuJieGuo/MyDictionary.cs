using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PSPUtil.Exensions;
using PSPUtil.StaticUtil;


namespace PSPUtil.ShuJuJieGuo
{

    [Serializable]
    public class MyDictionary<TKey, TValue> : IEnumerable        //Key 和 Value 都不能相同，可通过Value查找Key
    {
        //增----------------------------------------------------------------------------------
        public void Add(TKey key, TValue value)                  //添加
        {
            if (l_Key.Contains(key))
            {
                throw new Exception("已经包含这个Key ——" + key);
            }
            if (l_Value.Contains(value))
            {
                throw new Exception("已经包含这个Value ——" + value);
            }
            l_KeyValue.Add(new MyDictionaryKeyValue<TKey, TValue>(key, value));
            l_Key.Add(key);
            l_Value.Add(value);

        }


        //删----------------------------------------------------------------------------------
        public void Clear()                                      //清除
        {
            l_Key.Clear();
            l_Value.Clear();
            l_KeyValue.Clear();
        }


        public void RemoveAt(int index)                          //通过索引来Remove
        {
            if (index > Count)
            {
                MyLog.Red(String.Format("要移除的索引- {0} -超出了自身的最大值- {1} -", index, Count));
                return;
            }
            l_Key.RemoveAt(index);
            l_Value.RemoveAt(index);
            l_KeyValue.RemoveAt(index);
        }


        public void RemoveByKey(TKey key)
        {
            if (l_Key.Contains(key))
            {
                int index = l_Key.IndexOf(key);
                RemoveAt(index);
            }
            else
            {
                MyLog.Red("都不存在这个Key，Remove个蛋蛋");
            }
        }                     //通过Key来Remove


        public void RemoveByValue(TValue value)
        {
            if (l_Value.Contains(value))
            {
                int index = l_Value.IndexOf(value);
                RemoveAt(index);
            }
            else
            {
                MyLog.Red("都不存在这个Value，Remove个蛋蛋");
            }
        }               //通过Value来Remove


        //查----------------------------------------------------------------------------------
        public int Count                                         //当前总长度 
        {
            get { return l_KeyValue.Count; }

        }


        public int IndexOf(TKey key)                             //根据Key获取索引
        {
            if (l_Key.Contains(key))
            {
                return l_Key.IndexOf(key);
            }
            else
            {
                MyLog.Red("这个Key都没有注册过 返回-1 —— " + key);
                return -1;
            }
        }


        public int IndexOf(TValue value)                         //根据Value获取索引
        {
            if (l_Value.Contains(value))
            {
                return l_Value.IndexOf(value);
            }
            else
            {
                MyLog.Red("这个Value都没有注册过 返回-1 —— " + value);
                return -1;
            }
        }



        //取数据----------------------------------------------------------------------------------
        public TValue GetValueByKey(TKey key)                    //根据Key获得Value
        {
            if (l_Key.Contains(key))
            {
                int index = l_Key.IndexOf(key);
                return l_Value[index];
            }
            else
            {
                return default(TValue);
            }
        }


        public TKey GetKeyByValue(TValue value)                  //根据Value获得Key
        {
            if (l_Value.Contains(value))
            {
                int index = l_Value.IndexOf(value);
                return l_Key[index];
            }
            else
            {
                return default(TKey);
            }
        }


        public ReadOnlyCollection<TKey> Key                      //Key的集合
        {
            get { return l_Key.AsReadOnly(); }
        }

        public ReadOnlyCollection<TValue> Value                  //Value的集合
        {
            get { return l_Value.AsReadOnly(); }
        }


        public MyDictionaryKeyValue<TKey, TValue>? Get(int index)//根据索引获取 MyDictionaryKeyValue 没有返回 Null
        {
            if (index < 0 || index >= Count)
            {
                MyLog.Red(index + " 索引超过，当前最大值为".AddBlue() + Count);
                return null;
            }
            return l_KeyValue[index];
        }


        public MyDictionaryKeyValue<TKey, TValue>? this[int index]
        {
            get
            {
                return Get(index);
            }

        }

        #region 私有

        private readonly List<TKey> l_Key = new List<TKey>();
        private readonly List<TValue> l_Value = new List<TValue>();
        private readonly List<MyDictionaryKeyValue<TKey, TValue>> l_KeyValue = new List<MyDictionaryKeyValue<TKey, TValue>>();



        #endregion


        //重写函数----------------------------------------------------------------------------------
        public IEnumerator GetEnumerator()
        {
            return l_KeyValue.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (MyDictionaryKeyValue<TKey, TValue> keyValue in l_KeyValue)
            {
                sb.Append(keyValue).Append("\n");
            }
            return sb.ToString();
        }


    }


    #region MyDictionaryKeyValue
    [Serializable]
    public struct MyDictionaryKeyValue<TKey, TValue>
    {
        public TKey Key { get; private set; }

        public TValue Value { get; private set; }

        public MyDictionaryKeyValue(TKey key, TValue value) : this()
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return "[Key] ".AddBlue() + Key + "   |   [Value] ".AddBlue() + Value;
        }
    }
    #endregion  



}
