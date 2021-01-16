using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace AppDebugger {	
	
	public class EnvironmentPieceInfo
	{
	    private string name;
	    private string value;
	
	    public EnvironmentPieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class EnvironmentModel
	{
	    private List<EnvironmentPieceInfo> _infos;
	
	    public List<EnvironmentPieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<EnvironmentPieceInfo>();
	            _infos.Add(new EnvironmentPieceInfo("Product Name", Application.productName));    
	            _infos.Add(new EnvironmentPieceInfo("Company Name", Application.companyName));    
	            _infos.Add(new EnvironmentPieceInfo("Game Identifier", Application.identifier));    
	            // _infos.Add(new EnvironmentPieceInfo("Game Framework Version", Version.GameFrameworkVersion));    
	            // _infos.Add(new EnvironmentPieceInfo("Game Version", Utility.Text.Format("{0} ({1})", Version.GameVersion, Version.InternalGameVersion.ToString())));    
	            // _infos.Add(new EnvironmentPieceInfo("Resource Version",
	            //     m_BaseComponent.EditorResourceMode ?
	            //         "Unavailable in editor resource mode" :
	            //         (string.IsNullOrEmpty(m_ResourceComponent.ApplicableGameVersion) ?
	            //             "Unknown" : Utility.Text.Format("{0} ({1})",
	            //                 m_ResourceComponent.ApplicableGameVersion,
	            //                 m_ResourceComponent.InternalResourceVersion.ToString()))));    
	            _infos.Add(new EnvironmentPieceInfo("Application Version", Application.version));    
	            _infos.Add(new EnvironmentPieceInfo("Unity Version", Application.unityVersion));    
	            _infos.Add(new EnvironmentPieceInfo("Platform", Application.platform.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("System Language", Application.systemLanguage.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Cloud Project Id", Application.cloudProjectId));    
	            _infos.Add(new EnvironmentPieceInfo("Build Guid", Application.buildGUID));    
	            _infos.Add(new EnvironmentPieceInfo("Target Frame Rate", Application.targetFrameRate.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Internet Reachability", Application.internetReachability.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Background Loading Priority", Application.backgroundLoadingPriority.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Is Playing", Application.isPlaying.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Splash Screen Is Finished", SplashScreen.isFinished.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Run In Background", Application.runInBackground.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Install Name", Application.installerName));    
	            _infos.Add(new EnvironmentPieceInfo("Install Mode", Application.installMode.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Sandbox Type", Application.sandboxType.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Is Mobile Platform", Application.isMobilePlatform.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Is Console Platform", Application.isConsolePlatform.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Is Editor", Application.isEditor.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Is Focused", Application.isFocused.ToString()));    
	            _infos.Add(new EnvironmentPieceInfo("Is Batch Mode", Application.isBatchMode.ToString()));
	
	
	
	
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
