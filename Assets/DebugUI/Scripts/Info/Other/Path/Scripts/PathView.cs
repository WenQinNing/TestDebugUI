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
	public class PathView : DebugBaseView
	{
    #region 变量
	    [SerializeField]
	    private PathScrollRect _systemScrollRect;
	    
    #endregion
	    
	    public void RefreshData(List<PathPieceInfo> toShows)
	    {
	        _systemScrollRect.Show(toShows);
	    }
	
	
	
	
	    
	}
}
