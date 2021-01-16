using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class PathPieceInfo
	{
	    private string name;
	    private string value;
	
	    public PathPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class PathModel
	{
	    private List<PathPieceInfo> _infos;
	
	    public List<PathPieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<PathPieceInfo>();
	            
	             _infos.Add(new PathPieceInfo("Data Path", Application.dataPath));
	             _infos.Add(new PathPieceInfo("Persistent Data Path", Application.persistentDataPath));
	             _infos.Add(new PathPieceInfo("Streaming Assets Path", Application.streamingAssetsPath));
	             _infos.Add(new PathPieceInfo("Temporary Cache Path", Application.temporaryCachePath));
#if UNITY_2018_3_OR_NEWER
	             _infos.Add(new PathPieceInfo("Console Log Path", Application.consoleLogPath));
#endif
	        }
	        
	        return _infos;
	    }
	    
	  
	}
}
