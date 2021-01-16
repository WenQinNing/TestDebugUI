using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace AppDebugger {	
	[RequireComponent(typeof(CanvasGroup))]
	public class TimeView : DebugBaseView
	{
    #region 变量
	    [SerializeField]
	    private TimeScrollRect _scrollRect;
	    
	    private TimeModel _model = new TimeModel();
	
    #endregion
	    
	
	
	    public void RefreshData(List<TimePieceInfo> toShows)
	    {
	        _scrollRect.Show(toShows);
	    }
	
	
	    
	}
}
