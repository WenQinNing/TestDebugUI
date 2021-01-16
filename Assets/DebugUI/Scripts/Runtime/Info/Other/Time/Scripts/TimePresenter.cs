using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class TimePresenter : DebugBasePresenter
	{
	    private TimeModel _model = new TimeModel();
	    
	
	    public override void Show()
	    {
	        base.Show();
	       
	        UpdateData();
	    }
	
	    private void UpdateData()
	    {
	        List<TimePieceInfo> toShows = _model.GetData();
	
	        (_view as TimeView).RefreshData(toShows);
	    }
	
	    protected override void UpdateShow()
	    {
	        base.UpdateShow();
	        UpdateData();
	    }
	
	  
	}
}
