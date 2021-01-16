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
	public class GraphicView : DebugBaseView
	{
    #region 变量
	    [SerializeField]
	    private GraphicScrollRect _systemScrollRect;
	    
    #endregion
	    
	    public void RefreshData(List<GraphicPieceInfo> toShows)
	    {
	        _systemScrollRect.Show(toShows);
	    }
	    
	}
}
