using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class TimeCell : DebugBaseCell
	{
	
	    
	    
	    private TimePieceInfo data;
	    
	    public virtual void Init(TimePieceInfo data)
	    {
	        this.data = data;
	
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
