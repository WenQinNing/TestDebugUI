using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class SummaryPresenter : DebugBasePresenter
	{
	    private SummaryModel _model = new SummaryModel();
	    
	
	    public override void Show()
	    {
		    base.Show();
		  
		    RefreshData();
	    }

	    private void RefreshData()
	    {
		    List<SummaryPieceInfo> toShows = _model.GetData();

		    (_view as SummaryView).RefreshData(toShows);
	    }

	    protected override void UpdateShow()
	    {
		    base.UpdateShow();
	    }
	}
}
