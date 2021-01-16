using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class MemBaseHeader : MonoBehaviour
	{
    #region 变量
	   
	    [SerializeField]
	    private CanvasGroup _canvasGroup;
	
	    [SerializeField]
	    private Button button;
	
	    private UnityAction onClick;
	
	    [SerializeField]
	    private Text text;
	    
    #endregion
	
	    private void Start()
	    {
	        _canvasGroup = GetComponent<CanvasGroup>();
	        _canvasGroup.blocksRaycasts = true;
	        _canvasGroup.interactable = true;
	        
	        transform.localScale =Vector3.one;
	        button.onClick.AddListener(OnClick);
	    }
	
	    void OnClick()
	    {
	        onClick?.Invoke();
	    }
	
	    public void SetOnClickAct(UnityAction onClick)
	    {
	        this.onClick = onClick;
	    }
	
	    public void SetText(string text)
	    {
	        this.text.text = text;
	    }
	   
	}
}
