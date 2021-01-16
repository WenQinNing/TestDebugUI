using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class CompassPresenter : DebugBasePresenter
	{
	    private CompassModel _model = new CompassModel();
	    
	
	    private void Awake()
	    {
	        (_view as CompassView).SetOnDisableClick(OnDisableClick);
	        (_view as CompassView).SetOnEnableClick(OnEnableClick);
	    }
	    
	    public override void Show()
	    {
	        base.Show();
	        List<CompassPieceInfo> toShows = _model.GetData();
	        
	        (_view as CompassView).RefreshData(toShows);
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
