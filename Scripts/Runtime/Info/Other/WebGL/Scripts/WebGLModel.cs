using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class WebGLPieceInfo
	{
	    private string name;
	    private string value;
	
	    public WebGLPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class WebGLModel
	{
	    private List<WebGLPieceInfo> _infos = new List<WebGLPieceInfo>();
	
	    public List<WebGLPieceInfo> GetData()
	    {
	        
	        _infos.Clear();
	        
	        
#if !UNITY_2017_2_OR_NEWER
	                    _infos.Add(new WebGLPieceInfo("Is Web Player", Application.isWebPlayer.ToString()));
#endif
	        _infos.Add(new WebGLPieceInfo("Absolute URL", Application.absoluteURL));
#if !UNITY_2017_2_OR_NEWER
	                    _infos.Add(new WebGLPieceInfo("Source Value", Application.srcValue));
#endif
#if !UNITY_2018_2_OR_NEWER
	                    _infos.Add(new WebGLPieceInfo("Streamed Bytes", Application.streamedBytes.ToString()));
#endif
#if UNITY_5_3 || UNITY_5_4
	                    _infos.Add(new WebGLPieceInfo("Web Security Enabled", Application.webSecurityEnabled.ToString()));
	                    _infos.Add(new WebGLPieceInfo("Web Security Host URL", Application.webSecurityHostUrl.ToString()));
#endif
	        
	        return _infos;
	    }
	    
	  
	  
	}
}
