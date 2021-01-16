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
	public class QualityView : DebugBaseView
	{
    #region 变量
	    [SerializeField]
	    private QualityScrollRect _scrollRect;
	
	
	    private UnityAction<QualityHeader> onHeaderSetCB;
	    
    #endregion
	
	    private void Awake()
	    {
	        _scrollRect.Init(OnSetHeader);
	    }
	
	    void OnSetHeader(GameObject headerGo)
	    {
	        QualityHeader header =  headerGo.GetComponent<QualityHeader>();
	        onHeaderSetCB?.Invoke(header);
	    }
	
	   public void SetHeaderCb(UnityAction<QualityHeader> onHeaderSetCB)
	    {
	        this.onHeaderSetCB = onHeaderSetCB;
	    }
	    
	    public void RefreshData(List<QualitySectionInfo> toShows)
	    {
	  
	        _scrollRect.Show(toShows);
	    }
	
	}
}
