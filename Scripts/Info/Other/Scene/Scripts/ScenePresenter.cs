using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class ScenePresenter : DebugBasePresenter
	{
	    private SceneModel _model = new SceneModel();
	    
	
	    public override void Show()
	    {
	        base.Show();
	        List<ScenePieceInfo> toShows = _model.GetData();
	        
	        (_view as SceneView).RefreshData(toShows);
	    }
	}
}
