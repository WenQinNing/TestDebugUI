using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace AppDebugger {	
	
	public class ScreenPieceInfo
	{
	    private string name;
	    private string value;
	
	    public ScreenPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class ScreenModel
	{
	    private List<ScreenPieceInfo> _infos;
	
	    public List<ScreenPieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<ScreenPieceInfo>();
	
	            _infos.Add(new ScreenPieceInfo("Current Resolution",
	                GetResolutionString(Screen.currentResolution)));
	            _infos.Add(new ScreenPieceInfo("Screen Width", 
	                $"{Screen.width.ToString()} px / {GetInchesFromPixels(Screen.width).ToString("F2")} in / { GetCentimetersFromPixels(Screen.width).ToString("F2")} cm"
	                ));
	            _infos.Add(new ScreenPieceInfo("Screen Height", $"{Screen.height.ToString()} px / {GetInchesFromPixels(Screen.height).ToString("F2")} in / {GetCentimetersFromPixels(Screen.height).ToString("F2")} cm"));
	            _infos.Add(new ScreenPieceInfo("Screen DPI", Screen.dpi.ToString("F2")));
	            _infos.Add(new ScreenPieceInfo("Screen Orientation", Screen.orientation.ToString()));
	            _infos.Add(new ScreenPieceInfo("Is Full Screen", Screen.fullScreen.ToString()));
#if UNITY_2018_1_OR_NEWER
	            _infos.Add(new ScreenPieceInfo("Full Screen Mode", Screen.fullScreenMode.ToString()));
#endif
	            _infos.Add(new ScreenPieceInfo("Sleep Timeout", GetSleepTimeoutDescription(Screen.sleepTimeout)));
#if UNITY_2019_2_OR_NEWER
	            _infos.Add(new ScreenPieceInfo("Brightness", Screen.brightness.ToString("F2")));
#endif
	            _infos.Add(new ScreenPieceInfo("Cursor Visible", Cursor.visible.ToString()));
	            _infos.Add(new ScreenPieceInfo("Cursor Lock State", Cursor.lockState.ToString()));
	            _infos.Add(new ScreenPieceInfo("Auto Landscape Left", Screen.autorotateToLandscapeLeft.ToString()));
	            _infos.Add(new ScreenPieceInfo("Auto Landscape Right", Screen.autorotateToLandscapeRight.ToString()));
	            _infos.Add(new ScreenPieceInfo("Auto Portrait", Screen.autorotateToPortrait.ToString()));
	            _infos.Add(new ScreenPieceInfo("Auto Portrait Upside Down", Screen.autorotateToPortraitUpsideDown.ToString()));
#if UNITY_2017_2_OR_NEWER && !UNITY_2017_2_0
	            _infos.Add(new ScreenPieceInfo("Safe Area", Screen.safeArea.ToString()));
#endif
#if UNITY_2019_2_OR_NEWER
	            _infos.Add(new ScreenPieceInfo("Cutouts", GetCutoutsString(Screen.cutouts)));
#endif
	            _infos.Add(new ScreenPieceInfo("Support Resolutions", GetResolutionsString(Screen.resolutions)));
	        }
	        
	        return _infos;
	    }
	    
	    
	    private string GetResolutionsString(Resolution[] resolutions)
	    {
	        string[] resolutionStrings = new string[resolutions.Length];
	        for (int i = 0; i < resolutions.Length; i++)
	        {
	            resolutionStrings[i] = GetResolutionString(resolutions[i]);
	        }
	
	        return string.Join("; ", resolutionStrings);
	    }
	    
	    private string GetCutoutsString(Rect[] cutouts)
	    {
	        string[] cutoutStrings = new string[cutouts.Length];
	        for (int i = 0; i < cutouts.Length; i++)
	        {
	            cutoutStrings[i] = cutouts[i].ToString();
	        }
	
	        return string.Join("; ", cutoutStrings);
	    }
	    
	    public static float GetInchesFromPixels(float pixels)
	    {
	        return pixels / Screen.dpi;
	    }
	    
	    private string GetSleepTimeoutDescription(int sleepTimeout)
	    {
	        if (sleepTimeout == SleepTimeout.NeverSleep)
	        {
	            return "Never Sleep";
	        }
	
	        if (sleepTimeout == SleepTimeout.SystemSetting)
	        {
	            return "System Setting";
	        }
	
	        return sleepTimeout.ToString();
	    }
	    
	    private string GetResolutionString(Resolution resolution)
	    {
	        return $"{resolution.width.ToString()} x {resolution.height.ToString()} @ {resolution.refreshRate.ToString()}Hz";
	    }
	    
	    public static float GetCentimetersFromPixels(float pixels)
	    {
	        return 2.54f * pixels / Screen.dpi;
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
