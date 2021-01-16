using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace AppDebugger {	
	[RequireComponent(typeof(CanvasGroup))]
	public class GyroscopeView : DebugBaseView
	{
    #region 变量
	    [SerializeField]
	    private GyroscopeScrollRect _systemScrollRect;
	    
	    private bool isShowing;
	
	    [SerializeField]
	    private Button enableButton;
	
	
	    private UnityAction onEnableClick;
	    private UnityAction onDisableClick;
	
	    [SerializeField]
	    private Button disableButton;
    #endregion
	
	    private void Awake()
	    {
	        enableButton.onClick.AddListener(OnEnableClick);
	        disableButton.onClick.AddListener(OnDisableClick);
	    }
	
	    public void SetOnEnableClick(UnityAction onEnableClick)
	    {
	        this.onEnableClick = onEnableClick;
	    }
	    
	    public  void SetOnDisableClick(UnityAction onDisableClick)
	    {
	        this.onDisableClick = onDisableClick;
	    }
	
	    void OnEnableClick()
	    {
	        onEnableClick?.Invoke();
	    }
	    
	    void OnDisableClick()
	    {
	        onDisableClick?.Invoke();
	    }
	    
	
	    public void RefreshData(List<GyroscopePieceInfo> toShows)
	    {
	        _systemScrollRect.Show(toShows);
	    }
	    
	    public void ClearShow()
	    {
	        _systemScrollRect.ClearShow();
	    }
	}
}
