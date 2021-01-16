using System.Collections;
using System.Collections.Generic;
using Iyourcar.Components.RecycleTableView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AppDebugger {	
	public class TouchCell : DebugBaseCell
	{
	
	    
	    
	    private TouchPieceInfo data;
	    
	    public virtual void Init(TouchPieceInfo data)
	    {
	        this.data = data;
	
	        _nameText.text = data.Name;
	        _valueText.text = data.Value;
	    }
	}
}
