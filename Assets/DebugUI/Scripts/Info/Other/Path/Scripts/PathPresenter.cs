using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class PathPresenter : DebugBasePresenter
	{
	    private PathModel _model = new PathModel();
	    
	
	    public override void Show()
	    {
	        base.Show();
	        List<PathPieceInfo> toShows = _model.GetData();
	        
	        (_view as PathView).RefreshData(toShows);
	    }
	}
}
