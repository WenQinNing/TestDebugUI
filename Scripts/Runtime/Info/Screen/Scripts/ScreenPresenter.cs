using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class ScreenPresenter : DebugBasePresenter
	{
	    private ScreenModel _model = new ScreenModel();
	    
	
	    public override void Show()
	    {
	        base.Show();
	        List<ScreenPieceInfo> toShows = _model.GetData();
	        
	        (_view as ScreenView).RefreshData(toShows);
	    }
	}
}
