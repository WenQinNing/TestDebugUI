using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class SystemPresenter : DebugBasePresenter
	{
	
	   
	    private SystemModel _model = new SystemModel();
	    
	    public override void Show()
	    {
	        base.Show();
	        List<SystemPieceInfo> toShows = _model.GetData();
	        
	        (_view  as SystemView).RefreshData(toShows);
	    }
	}
}
