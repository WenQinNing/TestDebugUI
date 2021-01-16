using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	public class ConsoleModel
	{
	    private List<ConsoleNode> _logNode = new List<ConsoleNode>();

	    private List<ConsoleNode> _toShow = new List<ConsoleNode>() ;
	    
	    private int maxDataCount;
	
	    public void Init(int maxDataCount)
	    {
	       this.maxDataCount = maxDataCount ;
	    }
	    
	    public void Enqueue(LogType logType, string logMessage,
	        string stackTrace)
	    {
	        ConsoleNode node = ConsoleNode.Create(logType, logMessage, stackTrace);

	        _logNode.Add(node);
	        
	        while (_logNode.Count > maxDataCount)
	        {
		        _logNode.RemoveAt(0);
		        // Debug.Log("ConsoleModel " + _logNode[0].LogMessage);
	        }
	    }
	
	    public List<ConsoleNode> GetToShow(bool isWarningOn, bool isErrorOn,
	        bool isInfoOn, bool isAssertOn, bool isExceptionOn)
	    {
	        _toShow.Clear();
	
	        for (int i = 0; i < _logNode.Count; i++)
	        {
		        if ((isWarningOn && _logNode[i].LogType == LogType.Warning)||
		            (isErrorOn && _logNode[i].LogType == LogType.Error)||
		            (isInfoOn && _logNode[i].LogType == LogType.Log)||
		            (isExceptionOn && _logNode[i].LogType == LogType.Exception)||
		            (isAssertOn && _logNode[i].LogType == LogType.Assert))
		        {
			        _toShow.Add(_logNode[i]);
		        }
	        }
	        
	        return _toShow;
	    }
	
	    
	

	    
	
	}
}
