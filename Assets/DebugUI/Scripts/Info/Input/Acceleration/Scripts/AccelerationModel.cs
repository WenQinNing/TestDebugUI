using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class AccelerationPieceInfo
	{
	    private string name;
	    private string value;
	
	    public AccelerationPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class AccelerationModel
	{
	    private List<AccelerationPieceInfo> _infos= new List<AccelerationPieceInfo>();
	
	    public List<AccelerationPieceInfo> GetData()
	    {
	        
	            _infos.Clear();
	            
	           
	            _infos.Add(new AccelerationPieceInfo("Acceleration", Input.acceleration.ToString()));
	            _infos.Add(new AccelerationPieceInfo("Acceleration Event Count", Input.accelerationEventCount.ToString()));
	            _infos.Add(new AccelerationPieceInfo("Acceleration Events", GetAccelerationEventsString(Input.accelerationEvents)));
	        
	        
	        return _infos;
	    }
	    
	    private string GetAccelerationEventString(AccelerationEvent accelerationEvent)
	    {
	        return $"{accelerationEvent.acceleration.ToString()}, {accelerationEvent.deltaTime.ToString()}";
	    }
	    
	    private string GetAccelerationEventsString(AccelerationEvent[] accelerationEvents)
	    {
	        string[] accelerationEventStrings = new string[accelerationEvents.Length];
	        for (int i = 0; i < accelerationEvents.Length; i++)
	        {
	            accelerationEventStrings[i] = GetAccelerationEventString(accelerationEvents[i]);
	        }
	
	        return string.Join("; ", accelerationEventStrings);
	    }
	  
	}
}
