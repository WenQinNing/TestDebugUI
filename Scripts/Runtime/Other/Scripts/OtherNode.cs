using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public sealed class OtherNode 
	{
	    private DateTime _logTime;
	    private int _logFrameCount;
	    private string _logMessage;
	    
	    
	    public string LogMessage
	    {
	        get
	        {
	            return _logMessage;
	        }
	    }
	    
	    public int LogFrameCount
	    {
	        get
	        {
	            return _logFrameCount;
	        }
	    }
	    
	    public DateTime LogTime
	    {
	        get
	        {
	            return _logTime;
	        }
	    }
	   
	    public OtherNode(string logMessage, int logFrameCount)
	    {
	        _logTime = default(DateTime);
	        _logFrameCount = logFrameCount;
	        _logMessage = logMessage;
	    }
	    
	    public static OtherNode Create(string logMessage)
	    {
	        OtherNode node = new OtherNode(logMessage, Time.frameCount);
	        
	        return node;
	    }
	    
	   
	    
	    
	}
}
