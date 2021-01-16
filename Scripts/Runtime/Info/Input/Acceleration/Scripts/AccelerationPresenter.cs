using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class AccelerationPresenter : DebugBasePresenter
	{
	    private AccelerationModel _model = new AccelerationModel();
	    
	  
	
	    public override void Show()
	    {
		    base.Show();
		    RefreshData();
	    }

	    private void RefreshData()
	    {
		    List<AccelerationPieceInfo> toShows = _model.GetData();

		    (_view as AccelerationView).RefreshData(toShows);
	    }


	    protected override void UpdateShow()
	    {
		    base.UpdateShow();
		    RefreshData();
	    }
	}
}
