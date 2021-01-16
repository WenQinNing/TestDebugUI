using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class LocationPresenter : DebugBasePresenter
	{ 
	    private LocationModel _model = new LocationModel();
	    
	    
	    private void Awake()
	    {
	        (_view as LocationView).SetOnDisableClick(OnDisableClick);
	        (_view as LocationView).SetOnEnableClick(OnEnableClick);
	    }
	    
	    public override void Show()
	    {
		    base.Show();
		    RefreshData();
	    }

	    private void RefreshData()
	    {
		    List<LocationPieceInfo> toShows = _model.GetData();

		    (_view as LocationView).RefreshData(toShows);
	    }

	    protected override void UpdateShow()
	    {
		    base.UpdateShow();
		    RefreshData();
	    }


	    void OnDisableClick()
	    {
	        Input.compass.enabled = false;
	    }
	
	    void OnEnableClick()
	    {
	        Input.compass.enabled = true;
	    }
	}
}
