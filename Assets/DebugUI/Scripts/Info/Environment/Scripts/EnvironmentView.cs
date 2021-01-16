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
	public class EnvironmentView : DebugBaseView
	{
    #region 变量
	    [SerializeField]
	    private EnvironmentScrollRect _scrollRect;
	
    #endregion
	    
	    public void RefreshData(List<EnvironmentPieceInfo> toShows)
	    {
	        _scrollRect.Show(toShows);
	    }
	}
}
