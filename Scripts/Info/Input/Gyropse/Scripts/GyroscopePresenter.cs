using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class GyroscopePresenter : DebugBasePresenter
	{
	    private GyroscopeModel _model = new GyroscopeModel();
	    
	
	    protected bool isShowingEmpty;
	
	    
	    private void Awake()
	    {
	       ( _view as GyroscopeView).SetOnDisableClick(OnDisableClick);
	       (_view as GyroscopeView).SetOnEnableClick(OnEnableClick);
	    }
	    
	    public override void Show()
	    {
	        base.Show();
	        List<GyroscopePieceInfo> toShows = _model.GetData();
	        
	        (_view as GyroscopeView).RefreshData(toShows);
	    }
	    
	    protected override void UpdateShow()
	    {
	        base.UpdateShow();
	        if (Input.gyro.enabled)
	        {
	            List<GyroscopePieceInfo> toShows = _model.GetData();
	            (_view as GyroscopeView).RefreshData(toShows);
	            isShowingEmpty = false;
	        }
	        else
	        {
	            if (!isShowingEmpty)
	            {
	                isShowingEmpty = true;
	                (_view as GyroscopeView).ClearShow();
	            }
	        }
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
