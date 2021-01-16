using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class WebGLPresenter : DebugBasePresenter
	{
	    
	    private WebGLModel _model = new WebGLModel();
	  
	    
	    public override void Show()
	    {
	        base.Show();
	       
	        UpdateData();
	    }
	    
	    private void UpdateData()
	    {
	        List<WebGLPieceInfo> toShows = _model.GetData();
	
	        (_view as WebGLView).RefreshData(toShows);
	    }
	
	}
}
