using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class GyroscopeCell : DebugBaseCell
	{
	
	    
	    
	    private GyroscopePieceInfo data;
	    
	    public virtual void Init(GyroscopePieceInfo data)
	    {
	        base.Init();
	        
	        this.data = data;
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
