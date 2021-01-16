using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class EnvironmentPresenter : DebugBasePresenter
	{
	    private EnvironmentModel _model = new EnvironmentModel();
	    
	
	    public override void Show()
	    {
	        base.Show();
	        List<EnvironmentPieceInfo> toShows = _model.GetData();
	        
	        (_view as EnvironmentView).RefreshData(toShows);
	    }
	}
}
