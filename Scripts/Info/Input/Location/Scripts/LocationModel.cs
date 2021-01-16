using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class LocationPieceInfo
	{
	    private string name;
	    private string value;
	
	    public LocationPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class LocationModel
	{
	    private List<LocationPieceInfo> _infos;
	
	    public List<LocationPieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<LocationPieceInfo>();
	
	           
	        }
	        _infos.Clear();
	        _infos.Add(new LocationPieceInfo("Is Enabled By User", Input.location.isEnabledByUser.ToString()));
	        _infos.Add(new LocationPieceInfo("Status", Input.location.status.ToString()));
	        if (Input.location.status == LocationServiceStatus.Running)
	        {
	            _infos.Add(new LocationPieceInfo("Horizontal Accuracy", Input.location.lastData.horizontalAccuracy.ToString()));
	            _infos.Add(new LocationPieceInfo("Vertical Accuracy", Input.location.lastData.verticalAccuracy.ToString()));
	            _infos.Add(new LocationPieceInfo("Longitude", Input.location.lastData.longitude.ToString()));
	            _infos.Add(new LocationPieceInfo("Latitude", Input.location.lastData.latitude.ToString()));
	            _infos.Add(new LocationPieceInfo("Altitude", Input.location.lastData.altitude.ToString()));
	            _infos.Add(new LocationPieceInfo("Timestamp", Input.location.lastData.timestamp.ToString()));
	        }
	
	        return _infos;
	    }
	    
	  
	}
}
