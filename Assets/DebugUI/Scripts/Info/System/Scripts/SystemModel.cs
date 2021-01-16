using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class SystemPieceInfo
	{
	    private string name;
	    private string value;
	
	    public SystemPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class SystemModel
	{
	    private List<SystemPieceInfo> _infos;
	
	    public List<SystemPieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<SystemPieceInfo>();
	            _infos.Add(new SystemPieceInfo("Device Unique ID", SystemInfo.deviceUniqueIdentifier));
	            _infos.Add(new SystemPieceInfo("Device Name", SystemInfo.deviceName));
	            _infos.Add(new SystemPieceInfo("Device Model", SystemInfo.deviceModel));
	            _infos.Add(new SystemPieceInfo("Processor Type", SystemInfo.processorType));
	            _infos.Add(new SystemPieceInfo("Processor Count", SystemInfo.processorCount.ToString()));
	            _infos.Add(new SystemPieceInfo("Processor Frequency", $"{SystemInfo.processorFrequency.ToString()} MHz"));
	            _infos.Add(new SystemPieceInfo("System Memory Size", $"{SystemInfo.systemMemorySize.ToString()} MB"));
	            _infos.Add(new SystemPieceInfo("Operating System Family", SystemInfo.operatingSystemFamily.ToString()));
	            _infos.Add(new SystemPieceInfo("Operating System", SystemInfo.operatingSystem));
	            _infos.Add(new SystemPieceInfo("Battery Status", SystemInfo.batteryStatus.ToString()));
	            _infos.Add(new SystemPieceInfo("Battery Level", GetBatteryLevelString(SystemInfo.batteryLevel)));
	            _infos.Add(new SystemPieceInfo("Supports Audio", SystemInfo.supportsAudio.ToString()));
	            _infos.Add(new SystemPieceInfo("Supports Location Service", SystemInfo.supportsLocationService.ToString()));
	            _infos.Add(new SystemPieceInfo("Supports Accelerometer", SystemInfo.supportsAccelerometer.ToString()));
	            _infos.Add(new SystemPieceInfo("Supports Gyroscope", SystemInfo.supportsGyroscope.ToString()));
	            _infos.Add(new SystemPieceInfo("Supports Vibration", SystemInfo.supportsVibration.ToString()));
	            _infos.Add(new SystemPieceInfo("Genuine", Application.genuine.ToString()));
	            _infos.Add(new SystemPieceInfo("Genuine Check Available", Application.genuineCheckAvailable.ToString()));
	
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
