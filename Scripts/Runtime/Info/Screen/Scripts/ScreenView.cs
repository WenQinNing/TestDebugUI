using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace AppDebugger {	
	public class ScreenView : DebugBaseView
	{
	
    #region 变量
	    [SerializeField]
	    private ScreenScrollRect _scrollRect;
	    
    #endregion
	    
	
	    public void RefreshData(List<ScreenPieceInfo> toShows)
	    {
	        _scrollRect.Show(toShows);
	    }
	
	}
}
