using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class SummaryPieceInfo
	{
	    private string name;
	    private string value;
	
	    public SummaryPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class SummaryModel
	{
	    private List<SummaryPieceInfo> _infos;
	
	    public List<SummaryPieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<SummaryPieceInfo>();
	            _infos.Add(new SummaryPieceInfo("Device Unique ID", SystemInfo.deviceUniqueIdentifier));
	            
	            _infos.Add(new SummaryPieceInfo("Back Button Leaves App", Input.backButtonLeavesApp.ToString()));
	            _infos.Add(new SummaryPieceInfo("Device Orientation", Input.deviceOrientation.ToString()));
	            _infos.Add(new SummaryPieceInfo("Mouse Present", Input.mousePresent.ToString()));
	            _infos.Add(new SummaryPieceInfo("Mouse Position", Input.mousePosition.ToString()));
	            _infos.Add(new SummaryPieceInfo("Mouse Scroll Delta", Input.mouseScrollDelta.ToString()));
	            _infos.Add(new SummaryPieceInfo("Any Key", Input.anyKey.ToString()));
	            _infos.Add(new SummaryPieceInfo("Any Key Down", Input.anyKeyDown.ToString()));
	            _infos.Add(new SummaryPieceInfo("Input String", Input.inputString));
	            _infos.Add(new SummaryPieceInfo("IME Is Selected", Input.imeIsSelected.ToString()));
	            _infos.Add(new SummaryPieceInfo("IME Composition Mode", Input.imeCompositionMode.ToString()));
	            _infos.Add(new SummaryPieceInfo("Compensate Sensors", Input.compensateSensors.ToString()));
	            _infos.Add(new SummaryPieceInfo("Composition Cursor Position", Input.compositionCursorPos.ToString()));
	            _infos.Add(new SummaryPieceInfo("Composition String", Input.compositionString));
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
