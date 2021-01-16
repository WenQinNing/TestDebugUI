using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AppDebugger {	
	public class OtherView : DebugBaseView
	{
	
	   [SerializeField]
	   private OtherScrollRect _otherScrollRect;
	
	   
	    public void RefreshText(string text)
	    {
	        _otherScrollRect.RefreshText(text);
	
	    }
	
	
	}
}
