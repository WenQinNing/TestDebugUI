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
	public class SceneView : DebugBaseView
	{
    #region 变量
	    [SerializeField]
	    private SceneScrollRect _scrollRect;
	
    #endregion
	
	    public void RefreshData(List<ScenePieceInfo> toShows)
	    {
	        _scrollRect.Show(toShows);
	    }
	    
	}
}
