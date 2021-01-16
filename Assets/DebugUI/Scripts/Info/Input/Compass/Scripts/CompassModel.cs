
namespace AppDebugger {	
using System.Collections.Generic;
using UnityEngine;
	
	
	public class CompassPieceInfo
	{
	    private string name;
	    private string value;
	
	    public CompassPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class CompassModel
	{
	    private List<CompassPieceInfo> _infos;
	
	    public List<CompassPieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<CompassPieceInfo>();
	            
	            
	            
	            _infos.Add(new CompassPieceInfo("Enabled", Input.compass.enabled.ToString()));
	            if (Input.compass.enabled)
	            {
	                _infos.Add(new CompassPieceInfo("Heading Accuracy", Input.compass.headingAccuracy.ToString()));
	                _infos.Add(new CompassPieceInfo("Magnetic Heading", Input.compass.magneticHeading.ToString()));
	                _infos.Add(new CompassPieceInfo("Raw Vector", Input.compass.rawVector.ToString()));
	                _infos.Add(new CompassPieceInfo("Timestamp", Input.compass.timestamp.ToString()));
	                _infos.Add(new CompassPieceInfo("True Heading", Input.compass.trueHeading.ToString()));
	            }
	
	        }
	        
	        return _infos;
	    }
	    
	    
	    private string GetBatteryLevelString(float batteryLevel)
	    {
	        if (batteryLevel < 0f)
	        {
	            return "Unavailable";
	        }
	
	        return batteryLevel.ToString("P0");
	    }
	
	}
}
