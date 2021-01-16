using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class MemSummaryPresenter : MemBasePresenter<Object>
	{
	    public override void Init()
	    {
	        base.Init();
	        _model = new MemSumModel();
	    }
	    
	}
}
