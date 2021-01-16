using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class ProfilerSummaryPresenter : DebugBasePresenter
	{
	
	    private ProfilerSummaryModel _model = new ProfilerSummaryModel();
	
	    public override void Show()
	    {
	        base.Show();
	
	        List<ProfilerSummaryPieceInfo> toShows = _model.GetData();
	        
	
	        (_view as ProfilerSummaryView).RefreshData(toShows);
	    }
	}
}
