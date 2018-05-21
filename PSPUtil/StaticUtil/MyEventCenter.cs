using System;
using System.Collections.Generic;
using PSPUtil.StaticUtil;


namespace PSPUtil
{
    public delegate void Callback();
    public delegate void Callback<T>(T arg1);
    public delegate void Callback<T, U>(T arg1, U arg2);
    public delegate void Callback<T, U, V>(T arg1, U arg2, V arg3);
    public delegate void Callback<T, U, V, X>(T arg1, U arg2, V arg3, X arg4);

    public static class MyEventCenter
    {

        public static void AddListener(ushort id, Callback handler)
        {
            OnListenerAdding(id, handler);
            mEventTable[id] = (Callback)mEventTable[id] + handler;
        }

        public static void AddListener<T>(ushort id, Callback<T> handler)
        {
            OnListenerAdding(id, handler);
            mEventTable[id] = (Callback<T>)mEventTable[id] + handler;
        }

        public static void AddListener<T, U>(ushort id, Callback<T, U> handler)
        {
            OnListenerAdding(id, handler);
            mEventTable[id] = (Callback<T, U>)mEventTable[id] + handler;
        }

        public static void AddListener<T, U, V>(ushort id, Callback<T, U, V> handler)
        {
            OnListenerAdding(id, handler);
            mEventTable[id] = (Callback<T, U, V>)mEventTable[id] + handler;
        }

        public static void AddListener<T, U, V, X>(ushort id, Callback<T, U, V, X> handler)
        {
            OnListenerAdding(id, handler);
            mEventTable[id] = (Callback<T, U, V, X>)mEventTable[id] + handler;
        }

        public static void Send(ushort id)
        {
            Delegate d;
            if (mEventTable.TryGetValue(id, out d))
            {
                Callback callback = d as Callback;

                if (callback != null)
                {
                    callback();
                }
                else
                {
                    MyLog.Red("类型不同，看看参数是否一样");
                }
            }
        }

        public static void Send<T>(ushort id, T arg1)
        {
            Delegate d;
            if (mEventTable.TryGetValue(id, out d))
            {
                Callback<T> callback = d as Callback<T>;

                if (callback != null)
                {
                    callback(arg1);
                }
                else
                {
                    MyLog.Red("类型不同，看看参数是否一样");
                }
            }
        }

        public static void Send<T, U>(ushort id, T arg1, U arg2)
        {

            Delegate d;
            if (mEventTable.TryGetValue(id, out d))
            {
                Callback<T, U> callback = d as Callback<T, U>;

                if (callback != null)
                {
                    callback(arg1, arg2);
                }
                else
                {
                    MyLog.Red("类型不同，看看参数是否一样");
                }
            }
        }

        public static void Send<T, U, V>(ushort id, T arg1, U arg2, V arg3)
        {
            Delegate d;
            if (mEventTable.TryGetValue(id, out d))
            {
                Callback<T, U, V> callback = d as Callback<T, U, V>;

                if (callback != null)
                {
                    callback(arg1, arg2, arg3);
                }
                else
                {
                    MyLog.Red("类型不同，看看参数是否一样");
                }
            }
        }

        public static void Send<T, U, V, X>(ushort id, T arg1, U arg2, V arg3, X arg4)
        {
            Delegate d;
            if (mEventTable.TryGetValue(id, out d))
            {
                Callback<T, U, V, X> callback = d as Callback<T, U, V, X>;

                if (callback != null)
                {
                    callback(arg1, arg2, arg3, arg4);
                }
                else
                {
                    MyLog.Red("类型不同，看看参数是否一样");
                }
            }
        }



        #region 私有



        private static readonly Dictionary<ushort, Delegate> mEventTable = new Dictionary<ushort, Delegate>();

        private static readonly List<ushort> mPermanentMessages = new List<ushort>();


        private static void OnListenerAdding(ushort id, Delegate listenerBeingAdded)
        {
            if (!mEventTable.ContainsKey(id))
            {
                mEventTable.Add(id, null);
            }

            Delegate d = mEventTable[id];
            if (d != null && d.GetType() != listenerBeingAdded.GetType())
            {
                throw new ListenerException(d.GetType(), listenerBeingAdded.GetType());
            }
        }

        private static void OnListenerRemoving(ushort id, Delegate listenerBeingRemoved)
        {

            if (mEventTable.ContainsKey(id))
            {
                Delegate d = mEventTable[id];

                if (d == null)
                {
                    MyLog.Red("原来的事件为空！");
                }
                else if (d.GetType() != listenerBeingRemoved.GetType())
                {
                    throw new ListenerException(d.GetType(), listenerBeingRemoved.GetType());
                }
            }
            else
            {
                MyLog.Red("都没存在过，移除什么？");
            }
        }

        private static void OnListenerRemoved(ushort id)
        {
            if (mEventTable[id] == null)
            {
                mEventTable.Remove(id);
            }
        }


        #endregion

        public static void LodAllEvents()                            // 打印所有事件出来
        {
            foreach (KeyValuePair<ushort, Delegate> pair in mEventTable)
            {
                MyLog.Blue(pair.Key + "    " + pair.Value);
            }
        }


        public static void ClearAllEvents()                                // 把所有事件清除了
        {
            List<ushort> messagesToRemove = new List<ushort>();

            foreach (KeyValuePair<ushort, Delegate> pair in mEventTable)
            {
                bool wasFound = false;

                foreach (ushort message in mPermanentMessages)
                {
                    if (pair.Key == message)
                    {
                        wasFound = true;
                        break;
                    }
                }

                if (!wasFound)
                    messagesToRemove.Add(pair.Key);
            }

            foreach (ushort message in messagesToRemove)
            {
                mEventTable.Remove(message);
            }
        }


        public static void RemoveListener(ushort id, Callback handler)
        {
            OnListenerRemoving(id, handler);
            mEventTable[id] = (Callback)mEventTable[id] - handler;
            OnListenerRemoved(id);
        }

        public static void RemoveListener<T>(ushort id, Callback<T> handler)
        {
            OnListenerRemoving(id, handler);
            mEventTable[id] = (Callback<T>)mEventTable[id] - handler;
            OnListenerRemoved(id);
        }

        public static void RemoveListener<T, U>(ushort id, Callback<T, U> handler)
        {
            OnListenerRemoving(id, handler);
            mEventTable[id] = (Callback<T, U>)mEventTable[id] - handler;
            OnListenerRemoved(id);
        }

        public static void RemoveListener<T, U, V>(ushort id, Callback<T, U, V> handler)
        {
            OnListenerRemoving(id, handler);
            mEventTable[id] = (Callback<T, U, V>)mEventTable[id] - handler;
            OnListenerRemoved(id);
        }

        public static void RemoveListener<T, U, V, X>(ushort id, Callback<T, U, V, X> handler)
        {
            OnListenerRemoving(id, handler);
            mEventTable[id] = (Callback<T, U, V, X>)mEventTable[id] - handler;
            OnListenerRemoved(id);
        }


    }



    public class ListenerException : Exception
    {
        public ListenerException(Type oldType, Type newType)
        {
            MyLog.Red(string.Format("乱西甘加？上一个监听的是 {0},宜家加噶系 {1}", oldType, newType));
        }
    }

}

