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
	public class CompassView : DebugBaseView
	{
    #region 变量
	    [SerializeField]
	    private CompassScrollRect _scrollRect;
	
	    [SerializeField]
	    private Button enableButton;
	    
	    [SerializeField]
	    private Button disableButton;
	
	    private UnityAction onEnableClick;
	    private UnityAction onDisableClick;
	    
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
	
	    public void RefreshData(List<CompassPieceInfo> toShows)
	    {
	        _scrollRect.Show(toShows);
	    }
	}
}
