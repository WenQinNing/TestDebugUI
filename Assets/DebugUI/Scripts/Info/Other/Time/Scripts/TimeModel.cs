using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AppDebugger {	
	
	public class TimePieceInfo
	{
	    private string name;
	    private string value;
	
	    public TimePieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class TimeModel
	{
	    private List<TimePieceInfo> _infos = new List<TimePieceInfo>();
	
	    public List<TimePieceInfo> GetData()
	    {
	        
	            _infos.Clear();
	            
	             _infos.Add(new TimePieceInfo("Time Scale", $"{Time.timeScale.ToString()} [{GetTimeScaleDescription(Time.timeScale)}]" ));
	             _infos.Add(new TimePieceInfo("Realtime Since Startup", Time.realtimeSinceStartup.ToString()));
	             _infos.Add(new TimePieceInfo("Time Since Level Load", Time.timeSinceLevelLoad.ToString()));
	             _infos.Add(new TimePieceInfo("Time", Time.time.ToString()));
	             _infos.Add(new TimePieceInfo("Fixed Time", Time.fixedTime.ToString()));
	             _infos.Add(new TimePieceInfo("Unscaled Time", Time.unscaledTime.ToString()));
#if UNITY_5_6_OR_NEWER
	             _infos.Add(new TimePieceInfo("Fixed Unscaled Time", Time.fixedUnscaledTime.ToString()));
#endif
	             _infos.Add(new TimePieceInfo("Delta Time", Time.deltaTime.ToString()));
	             _infos.Add(new TimePieceInfo("Fixed Delta Time", Time.fixedDeltaTime.ToString()));
	             _infos.Add(new TimePieceInfo("Unscaled Delta Time", Time.unscaledDeltaTime.ToString()));
#if UNITY_5_6_OR_NEWER
	             _infos.Add(new TimePieceInfo("Fixed Unscaled Delta Time", Time.fixedUnscaledDeltaTime.ToString()));
#endif
	             _infos.Add(new TimePieceInfo("Smooth Delta Time", Time.smoothDeltaTime.ToString()));
	             _infos.Add(new TimePieceInfo("Maximum Delta Time", Time.maximumDeltaTime.ToString()));
#if UNITY_5_5_OR_NEWER
	             _infos.Add(new TimePieceInfo("Maximum Particle Delta Time", Time.maximumParticleDeltaTime.ToString()));
#endif
	             _infos.Add(new TimePieceInfo("Frame Count", Time.frameCount.ToString()));
	             _infos.Add(new TimePieceInfo("Rendered Frame Count", Time.renderedFrameCount.ToString()));
	             _infos.Add(new TimePieceInfo("Capture Framerate", Time.captureFramerate.ToString()));
#if UNITY_2019_2_OR_NEWER
	             _infos.Add(new TimePieceInfo("Capture Delta Time", Time.captureDeltaTime.ToString()));
#endif
#if UNITY_5_6_OR_NEWER
	             _infos.Add(new TimePieceInfo("In Fixed Time Step", Time.inFixedTimeStep.ToString()));
#endif
	        
	        
	        return _infos;
	    }
	    
	    
	    private string GetTimeScaleDescription(float timeScale)
	    {
	        if (timeScale <= 0f)
	        {
	            return "Pause";
	        }
	
	        if (timeScale < 1f)
	        {
	            return "Slower";
	        }
	
	        if (timeScale > 1f)
	        {
	            return "Faster";
	        }
	
	        return "Normal";
	    }
	  
	}
}
