using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppDebugger {	
	public class MemSumModel : MemBaseModel<Object>
	{   
	    protected override string GetName(Object t)
	    {
	        return t.GetType().Name;
	    }
	}
}
