/*
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PSPUtil.MyComponent
{
    [DisallowMultipleComponent]
    [AddComponentMenu("我的组件/Func_UI", 2)]
    public class Func_UI : Func_Base, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {

        //按组件修改----------------------------------------------------------------------------------
        public void SetToggleValue(bool value)
        {
            Toggle toggle = GetComponentNo2Log<Toggle>();
            toggle.isOn = value;
        }
        public void SetTextValue(string value)
        {
            Text text = GetComponentNo2Log<Text>();
            text.text = value;
        }


        //按组件添加----------------------------------------------------------------------------------
        public void AddButtOnClick(UnityAction action)
        {
            if (null != action)
            {
                Button btn = GetOrAddComponent<Button>();
                btn.onClick.AddListener(action);
            }

        }
        public void AddSliderOnValueChanged(UnityAction<float> action)
        {
            if (null != action)
            {
                Slider slider = GetComponentNo2Log<Slider>();
                slider.onValueChanged.AddListener(action);
            }
        }
        public void AddToggleOnValueChanged(UnityAction<bool> action)
        {
            if (null != action)
            {
                Toggle toggle = GetComponentNo2Log<Toggle>();
                toggle.onValueChanged.AddListener(action);
            }
        }
        public void AddInputOnValueChanged(UnityAction<string> action)
        {
            if (null != action)
            {
                InputField input = GetComponentNo2Log<InputField>();
                input.onValueChanged.AddListener(action);
            }
        }
        public void AddInputOnEndEdit(UnityAction<string> action)
        {
            if (null != action)
            {
                InputField input = GetComponentNo2Log<InputField>();
                input.onEndEdit.AddListener(action);
            }
        }


        //按接口添加----------------------------------------------------------------------------------
        public void AddOnMouseDown(Action<PointerEventData> action)
        {
            E_OnMouseDown += action;
        }
        public void AddOnMouseUp(Action<PointerEventData> action)
        {
            E_OnMouseUp += action;
        }
        public void AddOnClick(Action<PointerEventData> action)
        {
            E_OnClick += action;
        }
        public void AddOnBeginDrag(Action<PointerEventData> action)
        {
            E_OnBeginDrag += action;
        }
        public void AddOnDrag(Action<PointerEventData> action)
        {
            E_OnDrag += action;
        }
        public void AddOnEndDrag(Action<PointerEventData> action)
        {
            E_OnEndDrag += action;
        }
        public void AddOnOtherUIDragInThis(Action<PointerEventData> action)
        {
            E_OnOtherUIDragInThis += action;
        }

        //按组件删除----------------------------------------------------------------------------------
        public void RemoveButtOnClick(UnityAction action)
        {
            if (null != action)
            {
                Button btn = GetComponentNo2Log<Button>();
                btn.onClick.RemoveListener(action);
            }
        }
        public void RemoveButtOnClickAll()
        {
            Button btn = GetComponentNo2Log<Button>();
            btn.onClick.RemoveAllListeners();

        }
        public void RemoveSliderOnValueChanged(UnityAction<float> action)
        {
            if (null != action)
            {
                Slider slider = GetComponentNo2Log<Slider>();
                slider.onValueChanged.RemoveListener(action);
            }
        }
        public void RemoveSliderOnValueChangedAll()
        {
            Slider slider = GetComponentNo2Log<Slider>();
            slider.onValueChanged.RemoveAllListeners();
        }
        public void RemoveToggleOnValueChanged(UnityAction<bool> action)
        {
            if (null != action)
            {
                Toggle toggle = GetComponentNo2Log<Toggle>();
                toggle.onValueChanged.RemoveListener(action);
            }
        }
        public void RemoveToggleOnValueChangedAll()
        {
            Toggle toggle = GetComponentNo2Log<Toggle>();
            toggle.onValueChanged.RemoveAllListeners();
        }
        public void RemoveInputOnValueChanged(UnityAction<string> action)
        {
            if (null != action)
            {
                InputField input = GetComponentNo2Log<InputField>();
                input.onValueChanged.RemoveListener(action);
            }
        }
        public void RemoveInputOnValueChangedAll()
        {
            InputField input = GetComponentNo2Log<InputField>();
            input.onValueChanged.RemoveAllListeners();
        }
        public void RemoveInputOnEndEdit(UnityAction<string> action)
        {
            if (null != action)
            {
                InputField input = GetComponentNo2Log<InputField>();
                input.onEndEdit.RemoveListener(action);
            }
        }
        public void RemoveInputOnEndEditAll()
        {
            InputField input = GetComponentNo2Log<InputField>();
            input.onEndEdit.RemoveAllListeners();
        }



        //删除所有接口事件----------------------------------------------------------------------------------
        public void RmoveInterfaceEvent()
        {
            E_OnMouseDown = null;
            E_OnMouseUp = null;
            E_OnClick = null;
            E_OnBeginDrag = null;
            E_OnDrag = null;
            E_OnEndDrag = null;
            E_OnOtherUIDragInThis = null;

        }



        #region 私有

        private event Action<PointerEventData> E_OnMouseDown = null;
        private event Action<PointerEventData> E_OnMouseUp = null;
        private event Action<PointerEventData> E_OnClick = null;
        private event Action<PointerEventData> E_OnBeginDrag = null;
        private event Action<PointerEventData> E_OnDrag = null;
        private event Action<PointerEventData> E_OnEndDrag = null;
        private event Action<PointerEventData> E_OnOtherUIDragInThis = null;

        protected override void OnDestroy2Do()
        {
            base.OnDestroy2Do();
            RmoveInterfaceEvent();
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            if (null != E_OnMouseDown)
            {
                E_OnMouseDown(eventData);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (null != E_OnMouseUp)
            {
                E_OnMouseUp(eventData);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (null != E_OnClick)
            {
                E_OnClick(eventData);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (null != E_OnBeginDrag)
            {
                E_OnBeginDrag(eventData);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (null != E_OnDrag)
            {
                E_OnDrag(eventData);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (null != E_OnEndDrag)
            {
                E_OnEndDrag(eventData);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (null != E_OnOtherUIDragInThis)
            {
                E_OnOtherUIDragInThis(eventData);
            }
        }


        #endregion




    }
    
}

*/
