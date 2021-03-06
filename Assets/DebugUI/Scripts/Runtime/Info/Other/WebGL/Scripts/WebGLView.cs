﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace AppDebugger {	
	[RequireComponent(typeof(CanvasGroup))]
	public class WebGLView : DebugBaseView
	{
    #region 变量
	    [SerializeField]
	    private WebGLScrollRect _scrollRect;
	    
	    private WebGLModel _model = new WebGLModel();
	
	    private bool isShowing;
	
    #endregion
	    
	
	    public void RefreshData(List<WebGLPieceInfo> toShows)
	    {
	        _scrollRect.Show(toShows);
	    }
	
	
	    
	}
}
