using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppDebugger {	
	
	public class ScenePieceInfo
	{
	    private string name;
	    private string value;
	
	    public ScenePieceInfo(string name, string value)
	    {
	        this.name = name;
	        this.value = value;
	    }
	
	    public string Name => name;
	    public string Value => value;
	}
	
	public class SceneModel
	{
	    private List<ScenePieceInfo> _infos;
	
	    public List<ScenePieceInfo> GetData()
	    {
	        if (_infos == null)
	        {
	            _infos = new List<ScenePieceInfo>();
	            
	            _infos.Add(new ScenePieceInfo("Scene Count", SceneManager.sceneCount.ToString()));
	            _infos.Add(new ScenePieceInfo("Scene Count In Build Settings", SceneManager.sceneCountInBuildSettings.ToString()));
	
	            Scene activeScene = SceneManager.GetActiveScene();
	            _infos.Add(new ScenePieceInfo("Active Scene Name", activeScene.name));
	            _infos.Add(new ScenePieceInfo("Active Scene Path", activeScene.path));
	            _infos.Add(new ScenePieceInfo("Active Scene Build Index", activeScene.buildIndex.ToString()));
	            _infos.Add(new ScenePieceInfo("Active Scene Is Dirty", activeScene.isDirty.ToString()));
	            _infos.Add(new ScenePieceInfo("Active Scene Is Loaded", activeScene.isLoaded.ToString()));
	            _infos.Add(new ScenePieceInfo("Active Scene Is Valid", activeScene.IsValid().ToString()));
	            _infos.Add(new ScenePieceInfo("Active Scene Root Count", activeScene.rootCount.ToString()));
	        }
	        
	        return _infos;
	    }
	    
	  
	}
}
