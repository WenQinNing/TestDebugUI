using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class GyroscopePieceInfo
	{
	    private string name;
	    private string value;
	
	    public GyroscopePieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class GyroscopeModel
	{
	    private List<GyroscopePieceInfo> _infos;
	
	    public List<GyroscopePieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<GyroscopePieceInfo>();
	            
	            
	            _infos.Add(new GyroscopePieceInfo("Update Interval", Input.gyro.updateInterval.ToString()));
	            _infos.Add(new GyroscopePieceInfo("Attitude", Input.gyro.attitude.eulerAngles.ToString()));
	            _infos.Add(new GyroscopePieceInfo("Gravity", Input.gyro.gravity.ToString()));
	            _infos.Add(new GyroscopePieceInfo("Rotation Rate", Input.gyro.rotationRate.ToString()));
	            _infos.Add(new GyroscopePieceInfo("Rotation Rate Unbiased", Input.gyro.rotationRateUnbiased.ToString()));
	            _infos.Add(new GyroscopePieceInfo("User Acceleration", Input.gyro.userAcceleration.ToString()));
	            
	        }
	        
	        return _infos;
	    }
	    
	  
	}
}
