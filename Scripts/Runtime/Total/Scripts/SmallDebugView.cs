using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class SmallDebugView : DebugBaseView
	{
    #region 变量区
	
	    [SerializeField]
	    private Button _openButton;
	
	    private UnityAction onClick;
	
	    [SerializeField]
	    private Text label;
	    
    #endregion
	
	    
	    private void Awake()
	    {
	        _openButton.onClick.AddListener(OnOpenClick);
	    }
	
	    public void SetOnClick(UnityAction onClick)
	    {
	        this.onClick = onClick;
	    }
	    
	    void OnOpenClick()
	    {
	        onClick?.Invoke();
	        Hide();
	    }
	
	
	    public void RefreshText(int _realtimeFPS)
	    {
	        label.text = _realtimeFPS.ToString();
	            
	        if (_realtimeFPS >= 35)
	        {
	            label.color = new Color(8f / 255f, 180f / 255f, 10f / 255f, 1f);
	        } else if (_realtimeFPS >= 25)
	        {
	            label.color = new Color(1, 111f / 255f, 0f, 1f);
	        }
	        else
	        {
	            label.color = Color.red;
	        }
	    }
	    
	    
	    
	}
}
