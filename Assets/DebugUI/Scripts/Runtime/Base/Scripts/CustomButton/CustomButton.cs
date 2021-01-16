using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AppDebugger {	
	
	    public static class CustomButtonExtion
	    {
	    }
	
	    [RequireComponent(typeof(Button))]
	    public class CustomButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler
	    {
	        public int index;
	        private Button _button;
	
	        private Button button
	        {
	            get
	            {
	                if (_button == null)
	                {
	                    _button = GetComponent<Button>();
	                }
	
	                return _button;
	            }
	        }
	
	        public enum Status
	        {
	            Normal,
	            Selected,
	            Disabled,
	        }
	
	        public Status status;
	
	        public bool interactable
	        {
	            get => button.interactable;
	            set
	            {
	                if (button != null)
	                {
	                    button.interactable = value;
	                }
	            }
	        }
	
	        public UnityAction<bool> statusDidChange;
	        public bool autoSwitchStatus = true;
	        
	        public UnityAction onDown;
	        public UnityAction<CustomButton> onClick;
	        public UnityAction onUp;
	
	        protected override void Start()
	        {
	            base.Start();
	            if (button != null)
	            {
	                button.onClick.AddListener(OnClick);
	            }
	        }
	
	        public void SetStatus(Status aStatus, bool animation = false)
	        {
	            status = aStatus;
	            //interactable = status != Status.Disabled;
	            statusDidChange?.Invoke(animation);
	        }
	
	        public void SetStatusAndInvoke(Status aStatus)
	        {
	            status = aStatus;
	            onClick?.Invoke(this);
	        }
	
	        private void OnClick()
	        {
	            if (autoSwitchStatus)
	            {
	                if (status == Status.Normal)
	                {
	                    SetStatus(Status.Selected, true);
	                }
	                else if (status == Status.Selected)
	                {
	                    SetStatus(Status.Normal, true);
	                }
	            }
	            else
	            {
	                status = GetNextStatus();
	            }
	
	            onClick?.Invoke(this);
	        }
	
	        public void OnPointerDown(PointerEventData eventData)
	        {
	            onDown?.Invoke();
	        }
	        
	        public void OnPointerUp(PointerEventData eventData)
	        {
	            onUp?.Invoke();
	        }
	
#if UNITY_EDITOR
	        protected override void OnValidate()
	        {
	            base.OnValidate();
	            if (button != null)
	            {
	                button.transition = Button.Transition.None;
	                button.targetGraphic = null;
	                Navigation nav = Navigation.defaultNavigation;
	                nav.mode = Navigation.Mode.None;
	                button.navigation = nav;
	            }
	        }
#endif
	
	        public void SetNormalState(bool isNormal)
	        {
	            SetStatus(GetNormalState(isNormal));
	        }
	
	        public static Status GetSelectState(bool isSelect)
	        {
	            return isSelect ? Status.Selected : Status.Normal;
	        }
	
	        public static Status GetNormalState(bool isNormal)
	        {
	            return isNormal ? Status.Normal : Status.Disabled;
	        }
	
	        public Status GetNextStatus()
	        {
	            return status == Status.Normal ? Status.Selected : Status.Normal;
	        }
	    }
}
