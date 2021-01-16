using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class GraphicPresenter : DebugBasePresenter
	{
	    private GraphicModel _model = new GraphicModel();
	    
	    
	    public override void Show()
	    {
	        base.Show();
	        List<GraphicPieceInfo> toShows = _model.GetData();
	        
	        (_view as GraphicView).RefreshData(toShows);
	    }
	}
}
