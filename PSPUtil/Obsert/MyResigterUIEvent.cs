/*
using System;
using PSPUtil.MyComponent;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace PSPUtil.StaticUtil
{
    public static class MyResigterUIEvent
    {
        //链式添加----------------------------------------------------------------------------------
        public static Func_UI GetFuncUI(string name)
        {
            Func_UI funcUi = MyGetComponent.GetFunc(name) as Func_UI;
            if (null == funcUi)
            {
                throw new Exception("添加 Func_UI 组件到对应 UI 上 —— " + name);
            }
            return funcUi;

        }
        public static Func_UI SetToggleOnValueChanged(this Func_UI ui, UnityAction<bool> action)
        {
            ui.AddToggleOnValueChanged(action);
            return ui;
        }

        public static Func_UI SetToggleValue(this Func_UI ui,bool value)
        {
            ui.SetToggleValue(value);
            return ui;
        }




        //按组件添加----------------------------------------------------------------------------------
        public static void AddButtOnClick(string name, UnityAction onClick)
        {
            GetFuncUI(name).AddButtOnClick(onClick);
        }
        public static void AddSliderOnValueChanged(string name, UnityAction<float> action)
        {
            GetFuncUI(name).AddSliderOnValueChanged(action);
        }
        public static void AddToggleOnValueChanged(string name, UnityAction<bool> action)
        {
            GetFuncUI(name).AddToggleOnValueChanged(action);

        }
        public static void AddInputOnValueChanged(string name, UnityAction<string> action)
        {
            GetFuncUI(name).AddInputOnValueChanged(action);

        }
        public static void AddInputOnEndEdit(string name, UnityAction<string> action)
        {
            GetFuncUI(name).AddInputOnEndEdit(action);

        }

        //按接口添加----------------------------------------------------------------------------------

        public static void AddOnMouseDown(string name,                      //鼠标按下
            Action<PointerEventData> action)
        {
            GetFuncUI(name).AddOnMouseDown(action);
        }
        public static void AddOnMouseUp(string name,                        //鼠标放开（可以不在UI身上）
            Action<PointerEventData> action)
        {
            GetFuncUI(name).AddOnMouseUp(action);
        }
        public static void AddOnClick(string name,                          //鼠标点击
            Action<PointerEventData> action)
        {
            GetFuncUI(name).AddOnClick(action);
        }
        public static void AddOnBeginDrag(string name,                      //在 AddOnDrag 前调用一次
            Action<PointerEventData> action)
        {
            GetFuncUI(name).AddOnBeginDrag(action);
        }
        public static void AddOnDrag(string name,                           //拖动,每移动一点距离就调用一次
            Action<PointerEventData> action)
        {
            GetFuncUI(name).AddOnDrag(action);
        }
        public static void AddOnEndDrag(string name,                        //拖动结束
            Action<PointerEventData> action)
        {
            GetFuncUI(name).AddOnEndDrag(action);
        }
        public static void AddOnOtherUIDragInThis(string name,              //别的UI拖动到自己这里调用
            Action<PointerEventData> action)
        {
            GetFuncUI(name).AddOnOtherUIDragInThis(action);
        }


        //按组件删除----------------------------------------------------------------------------------
        public static void RemoveButtOnClick(string name, UnityAction action)
        {
            GetFuncUI(name).RemoveButtOnClick(action);
        }
        public static void RemoveButtOnClickAll(string name)
        {
            GetFuncUI(name).RemoveButtOnClickAll();
        }
        public static void RemoveSliderOnValueChanged(string name, UnityAction<float> action)
        {
            GetFuncUI(name).RemoveSliderOnValueChanged(action);
        }
        public static void RemoveSliderOnValueChangedAll(string name)
        {
            GetFuncUI(name).RemoveSliderOnValueChangedAll();
        }
        public static void RemoveToggleOnValueChanged(string name, UnityAction<bool> action)
        {
            GetFuncUI(name).RemoveToggleOnValueChanged(action);
        }
        public static void RemoveToggleOnValueChangedAll(string name)
        {
            GetFuncUI(name).RemoveToggleOnValueChangedAll();
        }
        public static void RemoveInputOnValueChanged(string name, UnityAction<string> action)
        {
            GetFuncUI(name).RemoveInputOnValueChanged(action);
        }
        public static void RemoveInputOnValueChangedAll(string name)
        {
            GetFuncUI(name).RemoveInputOnValueChangedAll();
        }
        public static void RemoveInputOnEndEdit(string name, UnityAction<string> action)
        {
            GetFuncUI(name).RemoveInputOnEndEdit(action);
        }
        public static void RemoveInputOnEndEditAll(string name)
        {
            GetFuncUI(name).RemoveInputOnEndEditAll();
        }

        //删除所有接口事件----------------------------------------------------------------------------------

        public static void RmoveInterfaceEvent(string name)
        {
            GetFuncUI(name).RmoveInterfaceEvent();
        }

        #region 私有



        #endregion

    }

}

*/
