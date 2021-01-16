using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class TouchPresenter : DebugBasePresenter
	{
	    private TouchModel _model = new TouchModel();
	    
	
	
	    public override void Show()
	    {
		    base.Show();
		    RefreshData();
	    }

	    private void RefreshData()
	    {
		    List<TouchPieceInfo> toShows = _model.GetData();

		    (_view as TouchView).RefreshData(toShows);
	    }


	    protected override void UpdateShow()
	    {
		    base.UpdateShow();
		    RefreshData();
	    }
	}
}
