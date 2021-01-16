using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class TouchPieceInfo
	{
	    private string name;
	    private string value;
	
	    public TouchPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class TouchModel
	{
	    private List<TouchPieceInfo> _infos = new List<TouchPieceInfo>();
	
	    public List<TouchPieceInfo> GetData()
	    {
	        
	            _infos.Clear();
	            
	            _infos.Add(new TouchPieceInfo("Touch Supported", Input.touchSupported.ToString()));
	            _infos.Add(new TouchPieceInfo("Touch Pressure Supported", Input.touchPressureSupported.ToString()));
	            _infos.Add(new TouchPieceInfo("Stylus Touch Supported", Input.stylusTouchSupported.ToString()));
	            _infos.Add(new TouchPieceInfo("Simulate Mouse With Touches", Input.simulateMouseWithTouches.ToString()));
	            _infos.Add(new TouchPieceInfo("Multi Touch Enabled", Input.multiTouchEnabled.ToString()));
	            _infos.Add(new TouchPieceInfo("Touch Count", Input.touchCount.ToString()));
	            _infos.Add(new TouchPieceInfo("Touches", GetTouchesString(Input.touches)));
	            
	        
	        
	        return _infos;
	    }
	    
	    private string GetTouchesString(Touch[] touches)
	    {
	        string[] touchStrings = new string[touches.Length];
	        for (int i = 0; i < touches.Length; i++)
	        {
	            touchStrings[i] = GetTouchString(touches[i]);
	        }
	
	        return string.Join("; ", touchStrings);
	    }
	    
	    private string GetTouchString(Touch touch)
	    {
	        return $"{touch.position.ToString()}, {touch.deltaPosition.ToString()}, {touch.rawPosition.ToString()}, {touch.pressure.ToString()}, {touch.phase.ToString()}";
	    }
	}
}
