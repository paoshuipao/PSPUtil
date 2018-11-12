using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PSPUtil.Extensions;
using PSPUtil.StaticUtil;

namespace PSPUtil.ShuJuJieGuo
{
    public class MyHuoCheTou<R, T>
    {

        //增----------------------------------------------------------------------------------
        public bool Add(R head, T value)
        {
            if (headK_NodeV.ContainsKey(head))                    //加过头的时候就向尾添加去
            {
                NodeBean node = headK_NodeV[head];
                while (node.NextNode != null)
                {
                    if (node.Bean.Equals(value))
                    {
                        MyLog.Red("添加包车头，出现同head，同value情况");
                        return false;
                    }
                    node = node.NextNode;
                }
                node.NextNode = new NodeBean(value);
            }
            else                                                 //没加过头就加个头
            {
                headK_NodeV.Add(head, new NodeBean(value));
            }
            return true;
        }


        //删----------------------------------------------------------------------------------
        public void RemoveOneValue(R head, T value)              // 移除 R 中一个值
        {
            if (headK_NodeV.Count == 0)
            {
                //                MyLog.Red("已经没有数据了，还Remove？");
                return;
            }
            if (headK_NodeV.ContainsKey(head))
            {
                NodeBean firstNode = headK_NodeV[head];
                if (firstNode.Bean.Equals(value))                //删除头节点
                {
                    if (firstNode.NextNode != null)              //头节点中后面还有数据
                    {
                        headK_NodeV[head] = firstNode.NextNode;  //指向头节点的指向下一个
                    }
                    else                                         //只有头节点后面没有跟，直接删除就行
                    {
                        headK_NodeV.Remove(head);
                    }
                }
                else                                              //这个节点在中间或者在尾部 
                {
                    while (!firstNode.NextNode.Bean.Equals(value) && firstNode.NextNode != null)
                    {
                        firstNode = firstNode.NextNode;
                    }
                    if (!firstNode.NextNode.Bean.Equals(value))
                    {
                        throw new Exception("怎么是不等于这个值？ 那删除有什么意义？" + value);
                    }
                    //此时要删除firstNode.NextNode的NodeData和firstNode.NextNode.NextNode变成
                    if (firstNode.NextNode.NextNode != null)     //表示是在中间
                    {
                        firstNode.NextNode = firstNode.NextNode.NextNode;
                    }
                    else                                        //是尾部，直接去掉
                    {
                        firstNode.NextNode = null;
                    }
                }
            }
            else
            {
                MyLog.Orange("都没有注册过这个火车头，Remove什么 —— " + head);
            }
        }


        public void RemoveOneHead(R head, Action<T> removeOne)   //移除 R 中所有值,每删除一个值调用一次 removeOne
        {
            if (headK_NodeV.Count == 0)
            {
                MyLog.Orange("已经没有数据了，还Remove？");
                return;
            }
            if (headK_NodeV.ContainsKey(head))
            {
                NodeBean node = headK_NodeV[head];
                while (node.NextNode != null)
                {
                    NodeBean curNode = node;
                    node = node.NextNode;
                    if (null != removeOne)
                    {
                        removeOne(curNode.Bean);
                    }
                }
                if (null != removeOne)
                {
                    removeOne(node.Bean);
                }
                headK_NodeV.Remove(head);
            }
            else
            {
                MyLog.Orange("都没有注册过这个火车头，Remove什么 —— " + head);
            }
        }
        #region 重载
        public void RemoveOneHead(R head)
        {
            RemoveOneHead(head, null);
        }

        #endregion


        public void RemoveLastHead()                             // 移除最后一个头
        {
            RemoveLastHead(null, null);
        }
        #region 重载
        public void RemoveLastHead(Action<T> removeTou, Action<T> removeWei) //removeTou：移除头的情况  removeWei：移除尾的情况
        {
            if (headK_NodeV.Count == 0)
            {
                MyLog.Orange("已经没有数据了，还Remove？");
                return;
            }
            List<R> l_Tmp = new List<R>(headK_NodeV.Keys);
            R lastOne = l_Tmp[l_Tmp.Count - 1];
            NodeBean node = headK_NodeV[lastOne];
            if (node.NextNode == null)    //移除头的情况
            {
                if (null != removeTou)
                {
                    removeTou(node.Bean);
                }
                headK_NodeV.Remove(lastOne);
            }
            else
            {
                //1 
                NodeBean proNode = node;
                //2
                NodeBean nextNode = proNode.NextNode;
                while (nextNode.NextNode != null)
                {
                    proNode = nextNode;
                    nextNode = proNode.NextNode;
                }
                if (null != removeWei)
                {
                    removeWei(nextNode.Bean);
                }
                proNode.NextNode = null;

            }

        }


        #endregion

        public void Clear()                                      // 清除所有
        {
            headK_NodeV.Clear();
        }



        //操作----------------------------------------------------------------------------------
        public void DoOneHead(R head, Action<T> action, bool isLogRed)  //对一个火车头做操作
        {
            if (null == action)
            {
                MyLog.Red("传个Null值进来有什么意义？");
                return;
            }

            if (headK_NodeV.ContainsKey(head))
            {
                NodeBean node = headK_NodeV[head];
                while (node.NextNode != null)
                {
                    NodeBean curNode = node;
                    node = node.NextNode;
                    action(curNode.Bean);
                }
                action(node.Bean);
            }
            else
            {
                if (isLogRed)
                {
                    MyLog.Red("这个火车头没有添加过 —— " + head);
                }
            }

        }


        public void DoAllValue(Action<T> action)                 //对所有Value作操作
        {
            if (null == action)
            {
                MyLog.Red("传个Null值进来有什么意义？");
                return;
            }
            foreach (R r in headK_NodeV.Keys)
            {
                NodeBean node = headK_NodeV[r];
                while (node.NextNode != null)
                {
                    NodeBean curNode = node;
                    node = node.NextNode;
                    action(curNode.Bean);
                }
                action(node.Bean);
            }
        }



        //查----------------------------------------------------------------------------------
        public bool ContainsKey(R head)                           //是否包含这个head
        {
            return headK_NodeV.ContainsKey(head);
        }


        //获得----------------------------------------------------------------------------------
        public ReadOnlyCollection<T> this[R head]                // 索引器
        {
            get
            {
                return Key(head);
            }
        }


        public ReadOnlyCollection<T> Key(R head)                  // 获得Key集合 给foreach
        {
            List<T> list = new List<T>();
            DoOneHead(head, (t) =>
            {
                list.Add(t);
            }, true);

            return list.AsReadOnly();
        }


        public int Count                                         // key数量
        {
            get { return headK_NodeV.Count; }
        }




        #region 私有

        private Dictionary<R, NodeBean> headK_NodeV = new Dictionary<R, NodeBean>();

        class NodeBean
        {
            public T Bean { get; private set; }
            public NodeBean NextNode { get; set; }

            public NodeBean(T bean)
            {
                Bean = bean;
                NextNode = null;
            }

        }


        #endregion


        //重写函数----------------------------------------------------------------------------------


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (headK_NodeV.Count == 0)
            {
                sb.Append("没有数据".AddYellow());
            }
            else
            {
                sb.Append("当前总数有：".AddGreen()).Append(headK_NodeV.Count).Append("\n");
                foreach (R r in headK_NodeV.Keys)
                {
                    NodeBean node = headK_NodeV[r];
                    while (node.NextNode != null)
                    {
                        NodeBean curNode = node;
                        node = node.NextNode;
                        sb.Append("火车头: ".AddGreen()).Append(r).Append("   数据:".AddGreen()).Append(curNode.Bean).Append("\n");
                    }
                    sb.Append("火车头: ".AddGreen()).Append(r).Append("   数据:".AddGreen()).Append(node.Bean).Append("\n");
                }
            }
            return sb.ToString();
        }



    }

}

