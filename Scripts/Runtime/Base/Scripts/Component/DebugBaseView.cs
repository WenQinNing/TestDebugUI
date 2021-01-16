using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AppDebugger {	
	
	
	[RequireComponent(typeof(CanvasGroup))]
	public class DebugBaseView : MonoBehaviour
	{
	    private CanvasGroup _windowCanvasGroup;
	
	   protected  CanvasGroup WindowCanvasGroup
	    {
	        get
	        {
	            if (_windowCanvasGroup == null)
	            {
	                _windowCanvasGroup = GetComponent<CanvasGroup>();
	            }
	
	          return  _windowCanvasGroup;
	        }
	    }
	
	
	   public virtual void Init()
	   {
	       
	   }
	
	   public virtual void Show(UnityAction onShow = null)
	    {
	        WindowCanvasGroup.alpha = 1;
	        WindowCanvasGroup.interactable = true;
	        WindowCanvasGroup.blocksRaycasts = true;
	        gameObject.SetActive(true);
	        onShow?.Invoke();
	    }
	    
	    public virtual void Hide(UnityAction onHide = null)
	    {
	        WindowCanvasGroup.alpha = 0;
	        WindowCanvasGroup.interactable = false;
	        WindowCanvasGroup.blocksRaycasts = false;
	        gameObject.SetActive(false);
	        onHide?.Invoke();
	    }
	}
}
